using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        #region Data Fields
        private List<Item> items = new List<Item>(); //List of items
        #endregion

        #region Methods
        public List<Item> GetItems()
        {
            return items; //Method used to get the items
        }

        public void AddItem(object newItem)
        {
            // Adding the item to list.
            if (newItem is Item)
            {
                try
                {
                    // Casting and adding to list.
                    Item item = newItem as Item;

                    if (item.Name == null || item.Location == null)
                        return;
                    if (item.MinQuantity == 0)
                        return;

                    items.Add(item);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Unable to add item", e);
                }
            }
        }
        public void RemoveItem(int index)
        {
            // Removing the item from list
            try
            {
                items.RemoveAt(index);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Unable to add item", e);
            }
        }
        public void UpdateItem(object newItem, string type)
        {
            if (newItem is Item)
            {
                try
                {
                    // Casting and adding to list.
                    Item item = newItem as Item;

                    //Updating quantities based on the option selected (plus or minus)
                    if (type == "decrease")
                        item.AvailableQuantity -= 1;
                    if (type == "increase")
                        item.AvailableQuantity += 1;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Unable to update item", e);
                }
            }
        }
        public void GeneralReport()
        {
            try
            {
                StringBuilder generalReport = new StringBuilder();

                foreach (Item item in items)
                {
                    //Append item name and quantities for all the existing items
                    generalReport.AppendLine(string.Format($"Item Name: {item.Name}\n\tAvailable QTY: {item.AvailableQuantity}\n\tMin QTY: {item.MinQuantity}"));
                }
                //Create general report file
                File.WriteAllText("./generalReport.txt", generalReport.ToString());
            }
            catch (Exception e)
            {
                throw new ArgumentException("Unable to create general report", e);
            }
        }
        public void ShoppingList()
        {
            try
            {
                StringBuilder report = new StringBuilder();

                foreach (Item item in items)
                {
                    // Check if there's enough quantity.
                    if (item.AvailableQuantity < item.MinQuantity)
                    {
                        //Append item information for all the items needed
                        report.AppendLine(string.Format($"Item Name: {item.Name}\n\tAvailable QTY: {item.AvailableQuantity}\n\tMin QTY: {item.MinQuantity}" +
                        $"\n\tLocation: {item.Location}\n\tSupplier: {item.Supplier}\n\tCategory: {item.Category}"));
                    }
                }
                //Create shopping list file
                File.WriteAllText("./shoppingList.txt", report.ToString());
            }
            catch (Exception e)
            {
                throw new ArgumentException("Unable to create shopping list", e);
            }
        }
        public void LoadItems(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        //String split: An item object from the list has name, available qty, min qty, location, supplier and category.
                        Item item = new Item()
                        {
                            Name = lines[i].Split(',')[0],
                            AvailableQuantity = Int32.Parse(lines[i].Split(',')[1]),
                            MinQuantity = Int32.Parse(lines[i].Split(',')[2]),
                            Location = lines[i].Split(',')[3],
                            Supplier = (Item.Suppliers)Enum.Parse(typeof(Item.Suppliers), lines[i].Split(',')[4]),
                            Category = (Item.Categories)Enum.Parse(typeof(Item.Categories), lines[i].Split(',')[5])
                        };
                        //Add each item from the csv file to the items list
                        items.Add(item);
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("File does not exist", e);
                }
            }
        }
        public void SaveItems(string saveLocation)
        {
            StringBuilder itemsInfo = new StringBuilder();

            foreach (Item item in items)
            {
                //Append item information for each existing item
                itemsInfo.AppendLine($"{item.Name},{item.AvailableQuantity},{item.MinQuantity},{item.Location},{item.Supplier},{item.Category}");
            }
            //Save all the items to a csv file at the selected location
            File.WriteAllText(saveLocation, itemsInfo.ToString());
        }
        #endregion
    }
}
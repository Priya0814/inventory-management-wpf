using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Items class
    /// </summary>
    public class Item
    {
        #region Data fields
        //Name of the item
        private string name;

        //Quantity available in store
        private int availableQuantity;

        //Minimum quantity that a stores should always have at all times
        private int minQuantity;

        //Information on where the item is located in the store
        private string location;

        //Supplier name.
        private Suppliers supplier;

        //Category of item
        private Categories category;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set
            { 
                name = value;
            }
        }

        //available quantity cannot be less than 0
        public int AvailableQuantity
        {
            get { return availableQuantity; }
            set
            {   if(value < 0)
                {
                    throw new ArgumentException("Available quantity cannot be a negative value", "avaiableQuantity");
                }
               availableQuantity = value;
            }
        }

        //minimum quantity cannot be less than 1
        public int MinQuantity
        {
            get { return minQuantity; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Minimum quantity cannot be less than 1", "minQuantity");
                }
                minQuantity = value;
            }
        }
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
            }
        }
        public Suppliers Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        public Categories Category
        {
            get { return category; }
            set
            {
                category = value;
            }
        }
        #endregion

        #region Enums
        //enum for all suppliers
        public enum Suppliers
        {
            Walmart,
            IGA,
            Costco,
            Provigo,
            Adonis,
            Metro,
            Other
        }

        //enum for all types of categories
        public enum Categories
        {
            Pantry, 
            Dairy, 
            Drinks, 
            FrozenFood,
            FruitVegetable,
            Bakery,
            CleaningSupplies,
            Other
        }
        #endregion
    }
}
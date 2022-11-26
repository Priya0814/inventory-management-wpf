using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InventoryManagement.Models;
using Microsoft.Win32;
using System.IO;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data Fields
        Inventory inventory = new Inventory();

        //Saving variables
        private string saveLocation = string.Empty;
        private bool saved = false;
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            //Adding color to the quantity update buttons
            BtnPlus.Background = new SolidColorBrush(Color.FromRgb(60, 179, 113));
            BtnMinus.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            //Bind
            dgItems.ItemsSource = inventory.GetItems();
        }
        #endregion


        #region About Us 
        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PRP Inventory Management System\nMade by: Priya Govil, Resham Moocheet and Payal Rathod", "PIII Final Project");
        }

        #endregion

        #region Add, Remove & Update buttons
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            saved = false;

            Item item = new Item();
            ItemsWindow itemsWindow = new ItemsWindow(item, true);
            itemsWindow.ShowDialog();
            
            inventory.AddItem(item); //using inventory 

            dgItems.Items.Refresh();

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            saved = false;

            Item item = dgItems.SelectedItem as Item;

            if (item != null)
            {
                int itemIndex = dgItems.Items.IndexOf(dgItems.SelectedItem);

                inventory.RemoveItem(itemIndex);

                dgItems.SelectedItem = null;
                dgItems.Items.Refresh();
            }
            else
                MessageBox.Show("Please select the item you want to remove before clicking the remove button");
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            saved = false;

            Item item = dgItems.SelectedItem as Item;

            if (item != null)
            {
                ItemsWindow itemsWindow = new ItemsWindow(item, false);
                itemsWindow.ShowDialog();

                dgItems.SelectedItem = null;
            }
            else
                MessageBox.Show("Please select the item you want to update before clicking the update button");
        }
        #endregion

        #region Update quantities buttons
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            saved = false;

            string type = "decrease";
            Item item = dgItems.SelectedItem as Item;

            if (item != null)
            {
                inventory.UpdateItem(item, type);

                dgItems.Items.Refresh();
            }
            else
                MessageBox.Show("Please select the item you want to modify before clicking the subtract button");
        }
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            saved = false;

            string type = "increase";
            Item item = dgItems.SelectedItem as Item;

            if (item != null)
            {
                inventory.UpdateItem(item, type);

                dgItems.Items.Refresh();
            }
            else
                MessageBox.Show("Please select the item you want to modify before clicking the plus button");
        }
        #endregion

        #region Save Button
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveLogic();
        }
        private void SaveLogic()
        {
            if (inventory.GetItems().Count != 0)
            {
                if (!saved)
                {
                    try
                    {
                        //Check save location
                        if (string.IsNullOrEmpty(saveLocation))
                        {
                            SaveFileDialog save = new SaveFileDialog();
                            save.Filter = "CSV files (*.csv)|*.csv";
                            if (save.ShowDialog() == true)
                            {
                                saveLocation = save.FileName;
                            }
                            else
                                return;
                        }
                        inventory.SaveItems(saveLocation);

                        saved = true;
                        MessageBox.Show("Items have been saved");
                    }
                    catch (Exception e)
                    {

                        throw new ArgumentException("Unable to save items", e);
                    }
                }
            }
            else
                MessageBox.Show("There's no item to save!");
        }
        #endregion

        #region Search & Load buttons
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (inventory.GetItems().Count != 0)
            {
                SearchWindow searchWindow = new SearchWindow(inventory.GetItems());
                searchWindow.Show();
            }
            else
                MessageBox.Show("There's no item to search for!");
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            saved = false;

            string filePath;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV files (*.csv)|*.csv";
            if (open.ShowDialog() == true)
            {
                filePath = open.FileName;
                saveLocation = open.FileName;
            }
            else
                return;

            inventory.LoadItems(filePath);

            if (inventory.GetItems() != null)
            {
                dgItems.ItemsSource = inventory.GetItems();
                dgItems.Items.Refresh();
            }
            else
                MessageBox.Show("File didn't have any valid items");
        }
        #endregion

        #region Window Closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CheckBeforeOpen();
        }
        private bool CheckBeforeOpen()
        {
            if (inventory.GetItems().Count == 0)
                return true;

            if (saved)
                return true;

            MessageBoxResult result =
            MessageBox.Show("Do you want to save changes?", "Unsaved data", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return true;

            if (result == MessageBoxResult.Cancel)
                return false;


            //YES
            if (result == MessageBoxResult.Yes)
                SaveLogic();

            return saved;
        }
        #endregion

        #region Reports
        private void BtnGeneralReport_Click(object sender, RoutedEventArgs e)
        {
            if (inventory.GetItems().Count != 0)
            {
                inventory.GeneralReport();
                GeneralReportWindow generalReportWindow = new GeneralReportWindow();
                generalReportWindow.Show();
            }
            else
            {
                MessageBox.Show("Add items in order to create a general report");
                return;
            }
        }

        private void BtnShoppingList_Click(object sender, RoutedEventArgs e)
        {
            if (inventory.GetItems().Count != 0)
            {
                inventory.ShoppingList();
                ShoppingListWindow shoppingListWindow = new ShoppingListWindow();
                shoppingListWindow.Show();
            }
            else
            {
                MessageBox.Show("Add items in order to create a shopping list");
                return;
            }
        }
        #endregion
    }
}
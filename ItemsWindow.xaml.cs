using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InventoryManagement.Models;
using System.Text.RegularExpressions;
using System.Linq;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        #region Data Fields
        private Item item;
        #endregion

        #region Constructors
        public ItemsWindow()
        {
            InitializeComponent();

            //Bind
            cmbSuppliers.ItemsSource = Enum.GetValues(typeof(Item.Suppliers)).Cast<Item.Suppliers>().ToList();
            cmbCategories.ItemsSource = Enum.GetValues(typeof(Item.Categories)).Cast<Item.Categories>().ToList();
        }

        public ItemsWindow(Item emptyItem, bool isNewItem)
        {
            InitializeComponent();

            //easy binding that allows us to update/remove items later on
            item = emptyItem;
            this.DataContext = item;

            //Changing button and title when updating an item instead of adding
            if (isNewItem == false)
            {
                BtnAddItem.Content = "Update";
                txtTitle.Text = "Update Item";
            }
            //Bind
            cmbSuppliers.ItemsSource = Enum.GetValues(typeof(Item.Suppliers)).Cast<Item.Suppliers>().ToList();
            cmbCategories.ItemsSource = Enum.GetValues(typeof(Item.Categories)).Cast<Item.Categories>().ToList();

            grContent.Background = new SolidColorBrush(Color.FromRgb(203, 233, 242));
        }
        #endregion

        #region Buttons
        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUserInput())
            {
                if(item.MinQuantity < 1)
                    MessageBox.Show("Minimum quantity cannot be less than 1", "Item not added", MessageBoxButton.OK, MessageBoxImage.Error);

                this.Close(); //Close the window once the item is added
            }
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (object uiItem in grContent.Children) //clearing all the fields
            {
                if (uiItem is TextBox)
                    (uiItem as TextBox).Clear();
                else if (uiItem is ComboBox)
                    (uiItem as ComboBox).SelectedIndex = -1;
            }
        }
        #endregion

        #region Validation
        //Validate input to make sure all the fields are filled
        private bool CheckUserInput()
        {
            StringBuilder msg = new StringBuilder();
            //Item Name
            if (string.IsNullOrEmpty(txtItemName.Text))
                msg.AppendLine("Item Name is a required field.");
            //Available Quantity
            if (string.IsNullOrEmpty(txtAvailableQuantity.Text))
                msg.AppendLine("Available Quantity is a required field.");
            //Minimum Quantity
            if (string.IsNullOrEmpty(txtMinQuantity.Text))
                msg.AppendLine("Minimum Quantity is a required field.");
            //Location
            if (string.IsNullOrEmpty(txtLocation.Text))
                msg.AppendLine("Location is a required field.");
            //Supplier
            if (cmbSuppliers.SelectedIndex == -1)
                msg.AppendLine("Supplier is a required field.");
            //Category
            if (cmbCategories.SelectedIndex == -1)
                msg.AppendLine("Category is a required field.");
            if (string.IsNullOrEmpty(msg.ToString()))
                return true;

            MessageBox.Show(msg.ToString(), "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        //Prevent users from entering letters into the quantity fields
        private void TxtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion
    }
}
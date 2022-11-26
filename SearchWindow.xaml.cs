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

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        #region Constructor
        public SearchWindow(List<Item> items)
        {
            InitializeComponent();

            //Binding 
            cmbItemName.ItemsSource = items;
            cmbItemName.DisplayMemberPath = "Name";
        }
        #endregion

        #region Methods
        private void cmbItemName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Display information based on the item selected
            Item v = cmbItemName.SelectedItem as Item;
            spDetails.DataContext = v;
        }
        #endregion
    }
}

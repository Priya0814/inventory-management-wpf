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
using System.Diagnostics;
using System.Windows.Navigation;
using System.IO;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for GeneralReportWindow.xaml
    /// </summary>
    public partial class GeneralReportWindow : Window
    {
        #region Constructor
        public GeneralReportWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Get full path to open the file
            string filepath = System.IO.Path.Combine(Directory.GetCurrentDirectory() + "\\generalReport.txt");

            Hyperlink hyperlink = sender as Hyperlink;
            Process.Start(new ProcessStartInfo()
            {
                FileName = filepath,
                UseShellExecute = true
            });
            Close(); //Close the window once the file is opened
        }
        #endregion
    }
}
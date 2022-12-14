#pragma checksum "..\..\..\ItemsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B42474EF0B788F35CACF52ED5B319DF3A9114DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InventoryManagement;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace InventoryManagement {
    
    
    /// <summary>
    /// ItemsWindow
    /// </summary>
    public partial class ItemsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grContent;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItemName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAvailableQuantity;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMinQuantity;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLocation;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSuppliers;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\ItemsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCategories;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InventoryManagement;component/itemswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ItemsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtItemName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtAvailableQuantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\ItemsWindow.xaml"
            this.txtAvailableQuantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtAvailableQuantity_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtMinQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtLocation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmbSuppliers = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cmbCategories = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 63 "..\..\..\ItemsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 70 "..\..\..\ItemsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


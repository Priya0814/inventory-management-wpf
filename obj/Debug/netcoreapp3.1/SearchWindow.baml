   M S B A M L   `   `   `  ????N  JInventoryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InventoryManagementInventoryManagement  5   	   &     InventoryManagement.SearchWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:InventoryManagement     5   	     ? Title$  Search For Items??5   	   $	??450??6"   $	??350??6/   ???#cbe9f2 ? 
ResizeMode$ NoResize=?6P   .??5	      ? -   5         ?Name$ grMain??5	      .+?5   
   ?? -   5         ??Name$ 	spDetails??5   !   $??20q?6   .+?5      ?? $??	Item Name??6   $??20(?6)   $??Center=?67   $
??Bold"?6T   $??0,0,0,5q?6f   ??5      ?? 5      -   5        MySolidColorBrush?? ?? Color$ Black??5   A    ? Triggers 5      :? 5       :? RoutedEvent$ TextBlock.Loaded??6#   .[?5      ?? .??5      ?? .??5   "   ??  ?? 
TargetName$ MySolidColorBrush??61    ?? TargetProperty$ Color?6[   	 ?? From	 
Aquamarine6}   	
 ?? To
 DarkMagenta6?    g? Duration$ 0:0:1.7D?6?    g? AutoReverse$
 True??6?    g? RepeatBehavior$ Forever??6?   5      5      5      5      ?? 5      -   5         ??Name$ cmbItemName??5       ?? 
IsEditable$
 True??6]   $??0,0,0,5q?6o   ?? 5      $??Name:??6   $
??Bold"?6%   $??5q?67   ?? 5      $??5q?6.   ??6   ?? *Name+6.   ?? 5       $??Available Quantity:??6   $
??Bold"?63   $??5q?6E   ?? 5!      $??5q?6;   ??6   ?? *AvailableQuantity+6;   ?? 5"      $??Minimum Quantity:??6   $
??Bold"?61   $??5q?6C   ?? 5#      $??5q?65   ??6   ?? *MinQuantity+65   ?? 5$      $??	Location:??6   $
??Bold"?6)   $??5q?6;   ?? 5%      $??5q?62   ??6   ?? *
Location+62   ?? 5&      $??	Supplier:??6   $
??Bold"?6)   $??5q?6;   ?? 5'      $??5q?62   ??6   ?? *
Supplier+62   ?? 5(      $??	Category:??6   $
??Bold"?6)   $??5q?6;   ?? 5)      $??5q?62   ??6   ?? *
Category+62   5*      5+      5,      
   M S B A M L   `   `   `  ����N  JGlennsReportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GlennsReportManagerGlennsReportManager  5   	   S.clr-namespace:GlennsReportManager.UserControls GlennsReportManager.UserControls  5   	   "    GlennsReportManager.settings   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GlennsReportManager     5   	   GUserControls.clr-namespace:GlennsReportManager.UserControls     5   	   -   5          � Title$  GJRM: Settings��5	   	   $	��720��6    $��426.5��6-    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � Icon$ .\Icons\cog.ico��6�   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��19* �6   �� 5      $	��23* �6    � RowDefinitions 5   
   �� 5      $	��650 �6   �� 5      $��* �6   .+�5   
   �� $��10 10 10 10q�6   $��0��6*   $��2��67   .@�5      �� $��Sales Report��6   .��5      ��  �� Orientation$ Vertical=�6   .+�5      � $��Center=�6   $��Center=�68    5      �� 5      $
��400* �6/    5       �� 5!      $
��400* �6,   �� 5"      $
��100* �6,   .+�5&      4   .GlennsReportManager.UserControls.DataContainer  -   5          Name$ 
TaxContain��5&   5   $��0��6I   $��0��6Y   $��0 15 0 0q�6f   $	��370��6x   $	��250��6�   �� 5(      $ 
Horizontal=�6%   $��1��6>   $��1��6N   .+�5)      �� -   5        $��BTSRTAdd��5)   %   $	��New��65   $��	25 0 25 0q�6[   $��0 5 0 5q�6o   �� 5*      -   5        $��	BTSRTEdit��5*   %   $��Edit Selected��66   $��	25 0 25 0q�6g   $��5 5 0 5q�6{   �� 5+      -   5        $��BTSRTDelete��5+   %   $��Delete Selected��68   $��	25 0 25 0q�6m   $��5 5 0 5q�6�   5,      5-      � 51      $��Center=�6   $��Center=�68    52      �� 53      $
��400* �6/    55      �� 56      $
��400* �6,   �� 57      $
��100* �6,   .+�5;        -   5        $ TypeContain��5;   5   $��0��6J   $��0��6Z   $��0 15 0 0q�6g   $	��370��6y   $	��250��6�   �� 5=      $ 
Horizontal=�6%   $��1��6>   $��1��6N   .+�5>      �� -   5        $��BTSRAdd��5>   %   $	��New��64   $��	25 0 25 0q�6Y   $��0 5 0 5q�6m   �� 5?      -   5        $��BTSREdit��5?   %   $��Edit Selected��65   $��	25 0 25 0q�6e   $��5 5 0 5q�6y   �� 5@      -	   5        $��
BTSRDelete��5@   %   $��Delete Selected��67   $��	25 0 25 0q�6k   $��5 5 0 5q�6   5A      5B      5C      5D      5E      �� 5G   
   $ 
Horizontal=�6   $��1��6.   $��2��6;   .+�5H      �� -
   5        $��BTSave��5H      $
��Save��6#   $��	25 0 25 0q�6G   $��5 5 0 5q�6[   �� 5I      -   5        $��BTCan��5I      $��Cancel��6"   $��	25 0 25 0q�63   $��	235 5 0 5q�6G    �� IsCancel . 6Z   5J      5K      5L      
   M S B A M L   `   `   `  ����N  JGlennsReportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:GlennsReportManager.SReportGlennsReportManager.SReport  5   	   ;    5GlennsReportManager.SReport.SRConfigTranAddEditWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:GlennsReportManager.SReport     5   	     � Title$  SRConfigTranAddEditWindow��5   	   $	��200��6+   $��327.5��68    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   .+�5      �� $��Transaction Type:��6   $��Center=�61   $��5 0 0 0q�6L   �� 5      -   5         ��Name$ TXTType��5      $	��200��6'   $��18��63   $��10 0 0 0q�6?   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��2��6;   .+�5      �� $��Taxable:��6   $��Center=�6(   $��5 0 0 0q�6C   �� 5      -   5         ��Name$ CKTax��5      $��Center=�6&   $��10 0 0 0q�6A   5      �� 5    
   $��2��6   $ 
Horizontal=�6"   $��2��6;   .+�5!      �� $��Commissionable:��6   $��Center=�6/   $��5 0 0 0q�6J   �� 5"      -   5        $ CKComm��5"      $��Center=�6'   $��10 0 0 0q�6B   6T   5#      �� 5%   
   $��3��6   $ 
Horizontal=�6"   $��2��6;   .+�5&      �� $��Commission Rate:��6   $��Center=�60   $��5 0 0 0q�6K   �� 5'      -   5        $ TXTRate��5'      $	��200��6'   $��18��63   $��10 0 0 0q�6?   6}   5(      �� 5*   
   $��4��6   $ 
Horizontal=�6"   $��2��6;   .+�5+      �� -   5        $��Transaction Minimum:��5+      $��Center=�64   $��5 0 0 0q�6O   6�   �� 5,      -   5        $ TXTMin��5,      $	��177��6&   $��18��62   $��10,4,0,3q�6>   5-      �� 50   
   $��5��6   $ 
Horizontal=�6"   $��2��6;   .+�51      �� -   5         ��Name$ BTSave��51      $
��Save��6:   $��Center=�6I   $��	20 5 20 5q�6d   $��5 0 0 0q�6x   �� 52      -   5        $ BTCan��52      $��Cancel��6%   $��Center=�66   $��	20 5 20 5q�6Q   $��	158 0 0 0q�6e   	 �� IsCancel	 . 6x   53      54      55      
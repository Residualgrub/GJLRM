   M S B A M L   `   `   `  ���� N  JGlennsReportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GlennsReportManagerGlennsReportManager  S.clr-namespace:GlennsReportManager.UserControls GlennsReportManager.UserControls  "    GlennsReportManager.settings   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:GlennsReportManager     GUserControls.clr-namespace:GlennsReportManager.UserControls     -     � Title$  GJRM: Settings��$	��720��$��426.5�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ .\Icons\cog.ico��.���  � ColumnDefinitions �� $	��19* ��� $	��23* � � RowDefinitions �� $	��650 ��� $��* �.+��� $��10 10 10 10q�$��0��$��2��.@��� $��Sales Report��.����  �� Orientation$ Vertical=�.+�� $��Center=�$��Center=� �� $
��400* � �� $
��400* ��� $
��100* �.+�4   .GlennsReportManager.UserControls.DataContainer  -     Name$ 
TaxContain��$��0��$��0��$��0 15 0 0q�$	��370��$	��250���� $ 
Horizontal=�$��1��$��1��.+��� -   $��BTSRTAdd��$	��New��$��	25 0 25 0q�$��0 5 0 5q��� -   $��	BTSRTEdit��$��Edit Selected��$��	25 0 25 0q�$��5 5 0 5q��� -   $��BTSRTDelete��$��Delete Selected��$��	25 0 25 0q�$��5 5 0 5q�� $��Center=�$��Center=� �� $
��400* � �� $
��400* ��� $
��100* �.+�  -   $ TypeContain��$��0��$��0��$��0 15 0 0q�$	��370��$	��250���� $ 
Horizontal=�$��1��$��1��.+��� -   $��BTSRAdd��$	��New��$��	25 0 25 0q�$��0 5 0 5q��� -   $��BTSREdit��$��Edit Selected��$��	25 0 25 0q�$��5 5 0 5q��� -	   $��
BTSRDelete��$��Delete Selected��$��	25 0 25 0q�$��5 5 0 5q��� $ 
Horizontal=�$��1��$��2��.+��� -
   $��BTSave��$
��Save��$��	25 0 25 0q�$��5 5 0 5q��� -   $��BTCan��$��Cancel��$��	25 0 25 0q�$��	235 5 0 5q� �� IsCancel . 
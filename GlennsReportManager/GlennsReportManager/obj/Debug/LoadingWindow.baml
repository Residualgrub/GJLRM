   M S B A M L   `   `   `  ����N  JGlennsReportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GlennsReportManagerGlennsReportManager  5   	   '    !GlennsReportManager.LoadingWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   -local!clr-namespace:GlennsReportManager  5   	     � Title$  LoadingWindow��5	   	   $	��230��6   $	��437��6,    � WindowStyle$
 None=�68    � 
ResizeMode$ NoResize=�6K    � WindowStartupLocation$ CenterScreen=�6a    � Topmost . ��5
      �� 5   
    �� ImageSource$ images/loadbg.png��6   .��5      � $��0,10,0,0q�6    � ColumnDefinitions 5   
   �� 5      $
��180* �6   �� 5      $
��257* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��LBLLoad��5      $��Connecting to Database��6#   $��Center=�6A   $��Center=�6\   
�������$��24(�6�   $��2��6�   $
��Wrap=�6�   �� 5   
   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ images/loading.gif��6   $��1��6F   $��2��6S   5      5      
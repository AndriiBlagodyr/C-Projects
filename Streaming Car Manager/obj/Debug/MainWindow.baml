   M S B A M L   `   `   `  ����  BaseOfCarsRemadeVersion(    "BaseOfCarsRemadeVersion.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Application��5   	    � Title$ Database of cars��5   	   $	��350��6"   $	��475��6/    � 
ResizeMode$ NoResize=�6;   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5	      $��* �6   6)   .+�5      o� $��0��6   $��Right=�6    $	��469��6<   .@�5      m� $
��File��6   $��2q�6)   $��	20 2 10 2q�65   .@�5      m� -   5        $��Delete All Cars��5      6W   m� 5      -   5        $��Open Cars' File��5      6U   m� 5      -   5        $��Save Cars' File��5      6U   �� 5      6"   m� 5      -   5        $
��Exit��5      6B   5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��	AddButton��5      $��5q�6&   $��Bottom=�5      $��10 9 9 9q�5      $��Add Car��5      5      �� 5      -   5        $��DeleteButton��5      $��5q�6)   $��Bottom=�5      $��9q�5      $��
Delete Car��5      5      �� 5      -   5        $��TextBox��5      $	��120��5       $��25��5!       �� TextAlignment$
 Left=�5"      $��Center=�5#      .��6,   5$      �� 5%      -	   5        $��FinderButton��5%      $��15, 5, 15, 5q�6)   $��Bottom=�5&      $��9q�5'      $
��Find��5(      5)      �� 5*      -
   5        $��
ShowButton��5*      $��5q�6'   $��Bottom=�5+      $��5 9 9 9q�5,      $��Show All Data��5-      5.      5/      &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ DataGrid��50      $��2��6%   $��
10 0 10 10q�51      ���	#22009BFF53      54      55      
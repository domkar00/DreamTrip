   M S B A M L   `   `   `  ����L  HDreamTrip.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DreamTrip.Desktop.ViewsDreamTrip.Desktop.Views  5      K*clr-namespace:DreamTrip.Desktop.ViewModelsDreamTrip.Desktop.ViewModels  5      (    "DreamTrip.Desktop.Views.CitiesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:DreamTrip.Desktop.Views     5      9dc*clr-namespace:DreamTrip.Desktop.ViewModels     5      $	��400��5	      $	��500��6     � DataContext  5      3   -DreamTrip.Desktop.ViewModels.CietiesViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��SelectAgency��5      $��Create��5       $��1��5!      $��5q�5"      6   �� 5#   
   -   5        $��	AddAgency��5#      $
��Edit��5$      $��2��5%      $��5q�5&      6   �� 5'   
   -   5        $��
DeleteThis��5'      $��Delete��5(      $��3��5)      $��5q�5*      6   ]� 5,   
   $��1��6   $��4��6!   .+�5-      �� -   5        $��Cities��5-      ��5.      �� 5/      .R�50      ��  �� Orientation$ 
Horizontal=�6%   .+�51      �� ��6$   �� *Id+�� 52      $
��Bold"�54   !   ��53   !   �� *Name+54   !   55      56      58      59      5:      5;      
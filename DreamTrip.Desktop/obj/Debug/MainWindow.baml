   M S B A M L   `   `   `  ����L  HDreamTrip.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DreamTrip.Desktop.ViewModelsDreamTrip.Desktop.ViewModels  5   	   5clr-namespace:DreamTrip.DesktopDreamTrip.Desktop  5   	   "    DreamTrip.Desktop.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9dc*clr-namespace:DreamTrip.Desktop.ViewModels     5   	   1localclr-namespace:DreamTrip.Desktop     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5      6   0DreamTrip.Desktop.ViewModels.MainWindowViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��180 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6   $��1q�6b   y�6/   ��  �� Path$ 	IsVisible� �� Mode$ TwoWay=�._�5      �� -   5        $��MainMenu��5      .+�5      �� $��15,65,14.6,10q�5      $��50��6,   $��Users��5   7   ��6   �� *OpenUsersView+67   �� 5      $��15 10 15 10q�5      $��50��6*   $��Agencies��5   8   ��6   �� *OpenAgencyView+68   �� 5#      $��15 10 15 10q�5$      $��50��6*   $��Cities��5%   6   ��6   �� *OpenCityView+66   �� 5&      $��15 10 15 10q�5'      $��50��6*   $��	Countries��5(   9   ��6   �� *OpenCountryView+69   5,      5/      �� 50   
   $��1��6   $��Center=�51   I   $��Center=�6f   ��6   �� *CurrentContent+$ TwoWay=�6f   �� 54   
   -   5        $��SingI1��54      $��	Username:��6   $��1��62   $
��Left=�6B   $��171,184,0,0q�6]   $	��Top=�6r   �� 55   
   -   5        $��SingI2��55      $��	Password:��6   $��1��62   $
��Left=�6B   $��171,221,0,0q�6]   $	��Top=�6r   �� 56   
   -   5        $��SingI3��56      $��Sign in��6   $��1��61   $
��Left=�6A   $��231,129,0,0q�6\   $	��Top=�6q   $��16(�6�   $
��Bold"�6�   �� 57   
   -   5        $��SingI4��57      
������ $
��Left=�66   $	��190��6Q   
���   �$	��Top=�6m   $	��254��6�   $��1��6�   $��137,116,0,0q�6�   �� 58   
   -   5        $��UsernameBox��58      $��1��6%   $
��Left=�65   $��23��6P   $��251,188,0,0q�6\    �� TextWrapping$
 Wrap=�6q   $��Username��6�   $	��Top=�6�   $	��120��6�   G� 59   
   -   5        $��PasswordBox��59      $��1��6)   $
��Left=�69   $��23��6T   $��251,225,0,0q�6`   $	��Top=�6u   $	��120��6�   �� 5;   
   -   5        $��SingI5��5;      $��Sign in��6   $��1��61   $
��Left=�6A   $��171,264,0,0q�6\   $	��Top=�6q   $	��200��6�   6�   5>      5?      
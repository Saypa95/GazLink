   M S B A M L   `   `   `  ����B  >GazLink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GazLink.PagesGazLink.Pages  5          GazLink.Pages.AccountPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      'localclr-namespace:GazLink.Pages  5        N� Title$  AccountPage��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�5      $��20 5 0 0q�62   $��0��6D   .+�5      "  FontAwesome.WPF.ImageAwesome     Icon$ 
UserCircle=�6      
Foreground �#3B3B3B$��Center=�5   "   $��16��5   "   �� 5      $��Мои данные��6      MontserratMedium#��[  5      ���#3B3B3B$��Center=�5   1   $��16(�5       $	��5 0q�6*   5!        5#   
   $
 User=�6   $��1��6&   $��2��5$      $	��150��5%       �#3B3B3B5&      � 5(   
   $��1��6   $��0��5)       5*      �� 5+      $��1* �6#   �� 5,      $��1* �6#    5.      �� 5/      $��1* �6    �� 50      $��1* �6    .+�52      �� $ Vertical=�6   $��0��53      $��0��54      $��20,0,0,0q�55      $��Center=�56      $
��Left=�57      .+�58      �� $ 
Horizontal=�6   $��Center=�59      $��Right=�5:      $��0 0 0 10q�5;      .+�5<      �� $��Фамилия: ��6      MontserratReg#��[ 5=      ���#3B3B3B$��16(�5?      �� 5@      -   5         ��Name$ 
tbLastName��5@       #��[  5A      ���#3B3B3B$��16(�5C      5D      �� 5E      $ 
Horizontal=�6   $��Center=�5F      $��Right=�5G      $��0 0 0 10q�5H      .+�5I      �� $��Имя: ��6    #��[ 5J      ���#3B3B3B$��16(�5L      �� 5M      -   5        $ tbFirstName��5M       #��[  5N      ���#3B3B3B$��16(�5P      5Q      �� 5R      $ 
Horizontal=�6   $��Center=�5S      $��Right=�5T      $��0 0 0 10q�5U      .+�5V      �� $��Отчество: ��6    #��[ 5W      ���#3B3B3B$��16(�5Y      �� 5Z      -   5        $ tbMiddleName��5Z       #��[  5[      ���#3B3B3B$��16(�5]      5^      5_      �� 5a      $ Vertical=�6   $��0��5b      $��1��5c      $��20,0,0,0q�5d      $��Center=�5e      $
��Left=�5f      .+�5g      �� $ 
Horizontal=�6   $��Center=�5h      $��Right=�5i      $��0 0 0 10q�5j      .+�5k      �� $��Логин: ��6    #��[ 5l      ���#3B3B3B$��16(�5n      �� 5o      -   5        $ tblLogin��5o       #��[  5p      ���#3B3B3B$��16(�5r      5s      �� 5t      $ 
Horizontal=�6   $��Center=�5u      $��Right=�5v      $��0 0 0 10q�5w      .+�5x      �� $��Пароль: ��6    #��[ 5y      ���#3B3B3B$��16(�5{      �� 5|      -   5        $ tblPassword��5|       #��[  5}      ���#3B3B3B$��16(�5      5�      5�      �� 5�      $��1��6   $
��20 0q�5�      $	��150��5�      $/��)Изменить логин/пароль:��5�      $	��Top=�5�        MaterialDesignGroupBox#��[ 5�      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=�5�         
Background �#FFCC57	   
Foreground	 �#3B3B3B#��[  5�      $��2��6F   .��5�      �� $ Vertical=�6   .+�5�      �� $ 
Horizontal=�6!   $	��Top=�5�   !   .+�5�      �� -   5        $��tbLogin��5�   "   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Логин��5�   "      
Foreground �#FFCC57#��[ 5�   "   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#FFCC57���#3B3B3B % !MaterialDesignFloatingHintTextBox#��[ 5�   "   $	��150��5�   "   5�   "   �� 5�      -   5        $��
tbPassword��5�   &   $
 Пароль��5�   "    �#FFCC57#��[ 5�   &    �#FFCC57���#3B3B3B#��[ 5�   &   $��	100 0 0 0q�5�   &   $	��150��5�   &   5�   &   5�      �� 5�      -   5        $��btnSave��5�      ���#FFCC57���#3B3B3B$��Сохранить��5�      #��[  5�      $��30��5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5�      $��Center=�5�      $��Bottom=�5�      $��0 30 0 0q�5�      ��5�      Z� 5�   ,   5�      5�      5�      5�      5�      
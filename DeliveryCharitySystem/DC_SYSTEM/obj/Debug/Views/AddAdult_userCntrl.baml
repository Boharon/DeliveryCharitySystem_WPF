   M S B A M L   `   `   `  ����D  @DC_SYSTEM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DC_SYSTEM.ViewsDC_SYSTEM.Views  5      3clr-namespace:DC_SYSTEM.ModelsDC_SYSTEM.Models  6:   ;"clr-namespace:DC_SYSTEM.ViewModelsDC_SYSTEM.ViewModels  6c   (    "DC_SYSTEM.Views.AddAdult_userCntrl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullZ VMaterialDesignThemes.MahApps, Version=0.1.4.1513, Culture=neutral, PublicKeyToken=nullHMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      +localclr-namespace:DC_SYSTEM.Views   5      (mclr-namespace:DC_SYSTEM.Models   6:   -m1"clr-namespace:DC_SYSTEM.ViewModels   6c     � 	Resources  5	       �� 
TargetType   MaterialDesignTextBox �� BasedOn �� Property �� Value �� CornerRadius � ToolTip �� ElementName �� Path��%  '��       7   �� 5
   
   " ��6   8   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      ]� .+�5      �� 
���  ��$��right=�66   $��5,0,0,0q�6M   $��20��6^   $��20��6i   $ 10��6u    5   %   �� $ customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5   #   5      �� 5      $��customAdorner��68   $��Center=�6M   5      5      5      5      5      .��5      � .+�5    
   � ���#CEAA6A	 � RowDefinitions	 5!      �� 5"      $	��38* �6    �� 5#      $��7* �6    .+�5%      �� $��Center=�6   $��0,30,0,-0.4q�67   $��2��6L   $	��300��6]   .+�5&      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�67   $��0 20 0 0q�6U   .+�5'      �� -   5         ��Name$ 	IdTextBox��5'      $��Center=�61   $
��Left=�6O   $��RightToLeft=�6q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ תעודת זהות��6�   $��Center=�5(   p   $��90��6�   ��6   �� *
Adult.Id+ �� NotifyOnValidationError .  �� ValidatesOnDataErrors . 6�   '  !MaterialDesignThemes.Wpf.PackIcon  5)         Kind$ 
Identifier=�6.   $��Center=�6@   $��Center=�6]   5*      �� 5,      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�5-      �� -   5        $ FirstNameTextBox��5-      $��Center=�68   $
��Left=�6V   $��RightToLeft=�6x   $ שם פרטי��6�   $��Center=�5.   w   $��90��6�   ��6   �� *Adult.FirstName+ .  . 6�     5/      $ Account=�6.   $��Center=�6=   $��Center=�6Z   50      �� 51      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�53      �� -   5        $ LastNameTextBox��53      $��Center=�67   $
��Left=�6U   $��RightToLeft=�6w   $ שם משפחה��54   x   $��Center=�6�   $��90��6�   ��6   �� *Adult.LastName+ .  . 6�     55      $ Account=�6.   $��Center=�6=   $��Center=�6Z   56      �� 57      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�59      �� -   5        $ PhoneNumTextBox��59      $��Center=�67   $
��Left=�6U   $��RightToLeft=�5:   z   $ 
טלפון��6�   $��Center=�6�   $��90��6�   ��6   �� *Adult.PhoneNumber+ .  . 6�     5;      $ 	Telephone=�6.   $��Center=�6?   $��Center=�6\   5<      �� 5=      $
 
Horizontal=�6   $��Center=�66   $��0 30 0 0q�6T   .+�5?      �� -   5        $ NumberNumTextBox��5?      $��Center=�68   $
��Left=�6V   $��RightToLeft=�6x   $ מספר��6�   $��Center=�5@   M   $��90��6h   ��6   �� *Adult.Address.BuildingNumber+6h     5B      $
 Home=�6.   $��Center=�6:   $��Center=�6W   �� 5C      -   5         ��Name$ 
CmbBx_City��5C      $��Center=�63   $
��Left=�6Q   $��RightToLeft=�6s    �� 
IsEditable .  �� Text$ בחר עיר��6�    �� SelectedItem 6�   �� $ Adult.Address.City�6�     5F      $ CityVariant=�6.   $��Center=�6A   $��Center=�6^   �� 5H      -   5        $ CmbBx_Street��5H      $��RightToLeft=�67   $
��Left=�6S   $��Center=�6v    . $ בחר רחוב��6�    6�   �� $ Adult.Address.Street�6�     5K      $ AddressMarker=�6.   $��Center=�6C   $��Center=�6`   5L      �� 5M      $
 
Horizontal=�6   $��center=�67   $��	0 40 10 0q�6U   $	��280��6h   .+�5N      �� -   5         ��Name$
 food��5N      $��מזון��6-   $��Right=�6<   $��RightToLeft=�6Z   $	��100��5O   @   $��40��6L   
���   � d� 	IsChecked 6   �� *
Adult.Food+6X     5P      $ 
Restaurant=�6.   $��Center=�6@   $��Center=�6]   �� 5Q      -	   5        $ 	medicines��5Q      $��תרופות��62   $��Right=�6D   
���   �$��RightToLeft=�5R   X   $	��111��6u   $��40��6�    6   �� *Adult.Medicine+6�     5S      $ Medicine=�6.   $��Center=�6>   $��Center=�6[   5T      5U      �� 5V      $��שמור��6   $��1��6$   $
��Left=�6U   $��93,0,0,28.6q�6p   $	��108��6�   ��62   �� *Adult+��6�   �� *AddAdultCMD+5W      5X      5\      
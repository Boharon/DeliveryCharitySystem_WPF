   M S B A M L   `   `   `  ����D  @DC_SYSTEM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DC_SYSTEM.ViewsDC_SYSTEM.Views  5      .    (DC_SYSTEM.Views.Add_DeliverMan_UserCntrl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:DC_SYSTEM.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullZ VMaterialDesignThemes.MahApps, Version=0.1.4.1513, Culture=neutral, PublicKeyToken=nullHMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   6:     � 	Resources  5
       �� 
TargetType   MaterialDesignTextBox �� BasedOn �� Property �� Value �� CornerRadius � ToolTip �� ElementName �� Path��%  '��       7   �� 5   
   " ��6   8   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      ]� .+�5      �� 
���  ��$��right=�66   $��5,0,0,0q�6M   $��20��6^   $��20��6i   $ 10��6u    5   %   �� $ customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5   #   5      �� 5      $��customAdorner��68   $��Center=�6M   5      5      5      5      5      .��5       � .+�5!   
   � ���#CEAA6A	 � RowDefinitions	 5"      �� 5#      $	��38* �6    �� 5$      $��7* �6    .+�5&      �� $��Center=�6   $��0,30,0,-0.4q�67   $��2��6L   $	��300��6]   .+�5'      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�67   $��0 20 0 0q�6U   .+�5(      �� -   5         ��Name$ 	IdTextBox��5(      $��Center=�61   $
��Left=�6O   $��RightToLeft=�6q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ תעודת זהות��6�   $��Center=�5)   v   $��90��6�   ��6   �� *DeliveryMan.Id+ �� NotifyOnValidationError .  �� ValidatesOnDataErrors . 6�   '  !MaterialDesignThemes.Wpf.PackIcon  5*         Kind$ 
Identifier=�6.   $��Center=�6@   $��Center=�6]   5+      �� 5-      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�5.      �� -   5        $ FirstNameTextBox��5.      $��Center=�68   $
��Left=�6V   $��RightToLeft=�6x   $ שם פרטי��6�   $��Center=�5/   }   $��90��6�   ��6   �� *DeliveryMan.FirstName+ .  . 6�     50      $ Account=�6.   $��Center=�6=   $��Center=�6Z   51      �� 52      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�54      �� -   5        $ LastNameTextBox��54      $��Center=�67   $
��Left=�6U   $��RightToLeft=�6w   $ שם משפחה��55   ~   $��Center=�6�   $��90��6�   ��6   �� *DeliveryMan.LastName+ .  . 6�     56      $ Account=�6.   $��Center=�6=   $��Center=�6Z   57      �� 58      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�5:      �� -   5        $ PhoneNumTextBox��5:      $��Center=�67   $
��Left=�6U   $��RightToLeft=�5;   �   $ 
טלפון��6�   $��Center=�6�   $��90��6�   ��6   �� *DeliveryMan.PhoneNumber+ .  . 6�     5<      $ 	Telephone=�6.   $��Center=�6?   $��Center=�6\   5=      �� 5>      $
 
Horizontal=�6   $��Center=�66   $��0 20 0 0q�6T   .+�5@      �� -   5        $ EmailTextBox��5@      $��Center=�64   $
��Left=�6R   $��RightToLeft=�5A   z   $ אימייל��6�   $��Center=�6�   $��90��6�   ��6   �� *DeliveryMan.Email+ .  . 6�     5B      $ Email=�6.   $��Center=�6;   $��Center=�6X   5C      �� 5E      $
 
Horizontal=�6   $��Center=�66   $��0 30 0 0q�6T   .+�5G      �� -   5        $ NumberNumTextBox��5G      $��Center=�68   $
��Left=�6V   $��RightToLeft=�6x   $ מספר��6�   $��Center=�5H   S   $��90��6n   ��6   �� *$"DeliveryMan.Address.BuildingNumber+6n     5J      $
 Home=�6.   $��Center=�6:   $��Center=�6W   �� 5K      -   5         ��Name$ 
CmbBx_City��5K      $��Center=�63   $
��Left=�6Q   $��RightToLeft=�6s    �� 
IsEditable . $ בחר עיר��6@   �� SelectedItem 6�   �� $ DeliveryMan.Address.City� �� Text 6�   �� $ DeliveryMan.Address.City� .  . 6j    5N      $ CityVariant=�6.   $��Center=�6A   $��Center=�6^   �� 5P      -   5        $ CmbBx_Street��5P      $��RightToLeft=�67   $
��Left=�6S   $��Center=�6v    . $ בחר רחוב��6�    6�   �� $  DeliveryMan.Address.Street�6�     5S      $ AddressMarker=�6.   $��Center=�6C   $��Center=�6`   5T      5V      �� 5W      $��שמור��6   $��1��6$   $
��Left=�6[   $��93,0,0,28.6q�6v   $	��108��6�   ��62   �� *DeliveryMan+��6�   �� *AddDeliveryManCMD+5X      5Y      5Z      
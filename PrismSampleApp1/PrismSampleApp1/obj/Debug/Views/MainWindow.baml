   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5       PrismSampleApp1&    PrismSampleApp1.Views.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Y UPrism.Unity.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5      $	��630��5   /   $	��900��6<    � Title 6   �� *Title+ � 	Resources 5         teamLogo �� 	UriSource�� 5	   
   %<   &	        �� 5
      $ ../Images/customLogo.jpg?�6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $	��150 �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��5 �6   .+�5   
   � $��1��6   $��1��6   
������� 5      �� 5      $��5 �6    �� 5      $��80 �6    �� 5      $��40 �6    �� 5       $��40 �6    �� 5!      $��40 �6    .+�5$      �� #��[  6   $��1��5%      $��50��5&      $��50��6    $
��Left=�6+   $��10 0 0 0q�5'      �� 5(      $��2��6   
�������$��15(�5)      $
��Bold"�6&    � Cursor$
 Hand��68   $
��Left=�5*      $��10 0 0 0q�63   ��5(   8   �� *SettingMenu+ J� InputBindings 5+      d� 5,       �� CommandParameter$ SettingView��5-   #   	 d� MouseAction$	 	LeftClicke�6B   
 �� Command
 5,   #   �� *NavigateCommand+5-   B   5/      �� 50      $��3��6   
�������$��15(�51      $
��Bold"�6&   $
 Hand��68   $
��Left=�52      $��10 0 0 0q�63   ��50   8   �� *
GameRecord+ 53      d� 54      $ 
GameRecord��55   #   $	 	LeftClicke�6A   
 54   #   �� *NavigateCommand+55   A   57      �� 58      $��4��6   
�������$��15(�59      $
��Bold"�6&   $
 Hand��68   $
��Left=�5:      $��10 0 0 0q�63   ��58   8   �� *GameResults+ 5;      d� 5<      $ GameResults��5=   #   $	 	LeftClicke�6B   
 5<   #   �� *NavigateCommand+5=   B   5?      5@      � 5A   
   $��3��6   $��1��6   
�������.+�5B      �� !  Prism.Regions.RegionManager   
RegionName$ ContentRegion��6   $��5q�6L   5C      5D      5E      
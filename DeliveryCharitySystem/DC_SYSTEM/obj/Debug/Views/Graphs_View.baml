   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      D @DC_SYSTEM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DC_SYSTEM.ViewsDC_SYSTEM.Views 5      !   DC_SYSTEM.Views.Graphs_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      /localclr-namespace:DC_SYSTEM.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullZ VMaterialDesignThemes.MahApps, Version=0.1.4.1513, Culture=neutral, PublicKeyToken=nullHMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      .��5      � 
�������  � RowDefinitions  5   
   �� 5      $��8* �6   �� 5      $	��57* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6#   $��16q�65   $��64��6B   .��5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . $��0,0,20,0q�6�   .+�5      ��  &  "MaterialDesignToolForegroundButton#���   5   	   $��8 0 20 0q�5   	    K� ZIndex$ 0��5   	   ��6   �� *
Graphs_CMD+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Send=�5      $
��Left=�6   $	��Top=�62   $��RightToLeft=�6J   5      �� 5      -   5        $��cmbDWM��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ בחר ��6-   $��99��6�   $��RightToLeft=�6�   $��0,0,20,2q�6�   $��30��6  $y�	Collapsed=�6  -  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode 6S   ��  �� ElementName$ ClassicModeCheckBox��	 �� SelectedIndex	 6�   �� *Choice+.@�5      �� .��6'   
יומי5      �� 5      .��6'   
שבועי5!      �� 5"      .��6'   
חודשי5$      5%      �� 5&      -   5        
 ��Name$
 combCity��5&      $��0,0,30,2q�60   $ בחר עיר��5'      $��RightToLeft=�6,   $��Right=�5(      $��92��66   $y�	Collapsed=�6B   ��6    �� *City+6B   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ FutureDatePicker��5+   !   $	��Top=�6;   $	��100��6S   $��0 0 20 0q�6_   $ בחר תאריך��6q   $��RightToLeft=�6�   $��30��6�   $y�	Collapsed=�6�      SelectedDate 6�   �� *SelectedDate+6�   �� 5.      -   5        $��option��5.      $ בחר��6-   $	��111��6�   $��RightToLeft=�6�   $	��0,2q�6$   6�   �� $ ClassicModeCheckBox��	 6�   �� *PrisaOption+.@�5/      �� .��6'   פריסה ארצית51      �� 52      .��6'   פריסה מקומית54      55      56      58      59      �� 5:   
   $��2��6   .+�5;      #   LiveCharts.Wpf.CartesianChart  -   5        $��CartesianChart��5;   "   $y�	Collapsed=�68   &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6s   $	��414��6�   $��	10,50,0,0q�6�      Series 6O   �� *SeriesCollection+   AxisX 5=      	   LiveCharts.Wpf.Axis	   	  Title$ יום��6    	  Labels 6+   �� *Labels+   AxisY 5@      	  $ חלוקות��6    	  LabelFormatter 6/   �� *	Formatter+5B      5C      �� 5D   
   $��2��6   .+�5E      
   LiveCharts.Wpf.PieChart
  -   5        $��PieChart��5E      $y�	Collapsed=�6+   $ Bottom=�6B      	Hoverable .  $	��456��6�      DataTooltip 6�   Z�  5G         LiveCharts.Wpf.PieSeries     LiveCharts.Wpf.Series   Title$$ חבילות שלא חולקו��6$      Fill �	#FF038080   
DataLabels .    Values 5I   #   �� *Count_Done_Pie+   
LabelPoint 5J      �� *
PointLabel+  5K      $ חבילות שחולקו��6$   
 ����� .  6L   �� *Count_UnDone_Pie+ 5L      �� *
PointLabel+5N      5O      5R      5S      
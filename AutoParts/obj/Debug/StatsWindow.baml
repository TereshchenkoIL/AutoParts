   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts  5   	       AutoParts.SortsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AutoParts     5   	   p lDotNetProjects.DataVisualization.Toolkit, Version=6.0.85.0, Culture=neutral, PublicKeyToken=79778c5f2eed289bWchartingToolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit  5   	     � Icon$  Images/Parts.png��5	   	    � Title$ Статистика��5
   	   $	��552��6   $	��800��6)   .��5      � $��0,0,0,2q�6   .+�5   
   �� $)��#Вибрати статистику��6   $
��Left=�6-   $��	27,75,0,0q�6H   $	��Top=�6[   �� 5   
   -   5         ��Name$ 	Stats_Box��5      $
��Left=�6&   $��
165,80,0,0q�6A   $	��Top=�6U   $	��120��6m   .@�5      �� .��6   20Найбільш популярний товар66   �� 5      .��6   Виручка6$   �� 5      .��6   Середній чек6)   �� 5      .��6   Продані товари6+   �� 5      .��6   $"Виручка по місяцям6/   �� 5      .��6   MKВитрачена сума клієнтів за певний період6E   �� 5      .��6   A?Виручка від продажу товару по дням6?   �� 5      .��6   FDКількість відгуків по певному товару6A   �� 5      .��6   +)Найкрупніший покупець62   �� 5      .��6   Частка типів6)   5      �� 5   
   $ ��За який період��6   $
��Left=�6)   $��
330,79,0,0q�6D   $	��Top=�6X   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	From_Date��5      $
��Left=�6&   $��
470,80,0,0q�6A   $	��Top=�6U   $	��110��6m   �� 5   
   $
��По��6   $
��Left=�6   $��
597,79,0,0q�68   $	��Top=�6L   �� 5   
   $��З��6   $
��Left=�6   $��
435,79,0,0q�67   $	��Top=�6K     5   
   -   5          Name$ To_Date��5      $
��Left=�6&   $��
630,80,0,0q�6A   $	��Top=�6U   $	��110��6m   �� 5   
   -   5         ��Name$ Show_Button��5      $)��#Показати результат��6&   $��Center=�6C   $	��Top=�6a   $	��180��6y   $��30��6�   $��0,35,0,0q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Result_Grid��5      $
��Left=�6(   $	��360��6C   $��	5,130,0,0q�6P   $	��Top=�6c   $	��300��6{   � 5    
   $��315,135,0,24q�6   .+�5!      >  8System.Windows.Controls.DataVisualization.Charting.Chart  -   5          Name$ Chart��5!   $   $��0q�63      Title$ Графік��6>      Series. 5"      E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries	   DependentValuePath$	 Value��6T   
   IndependentValuePath$	
 Key��6o      ItemsSource 60   ��  �� Mode$ OneWay=�6�   B  <System.Windows.Controls.DataVisualization.Charting.PieSeries  5#      $	 Value��6Q   $	
 Key��6l    6-   �� $ OneWay=�6�   5$      5%      �� 5&   
   -   5        $ ReportButton��5&      $/��)Надрукувати результат��6'   $
��Left=�6G   $��30��6b   $��
585,35,0,0q�6n   $	��Top=�6�   $	��190��6�   6�   5'      5(      
   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts      AutoParts.SortsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:AutoParts     p lDotNetProjects.DataVisualization.Toolkit, Version=6.0.85.0, Culture=neutral, PublicKeyToken=79778c5f2eed289bWchartingToolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit    � Icon$  Images/Parts.png�� � Title$ Статистика��$	��552��$	��800��.��� $��0,0,0,2q�.+��� $)��#Вибрати статистику��$
��Left=�$��	27,75,0,0q�$	��Top=��� -    ��Name$ 	Stats_Box��$
��Left=�$��
165,80,0,0q�$	��Top=�$	��120��.@��� .��20Найбільш популярний товар�� .��Виручка�� .��Середній чек�� .��Продані товари�� .��$"Виручка по місяцям�� .��MKВитрачена сума клієнтів за певний період�� .��A?Виручка від продажу товару по дням�� .��FDКількість відгуків по певному товару�� .��+)Найкрупніший покупець�� .��Частка типів�� $ ��За який період��$
��Left=�$��
330,79,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��	From_Date��$
��Left=�$��
470,80,0,0q�$	��Top=�$	��110���� $
��По��$
��Left=�$��
597,79,0,0q�$	��Top=��� $��З��$
��Left=�$��
435,79,0,0q�$	��Top=�  -     Name$ To_Date��$
��Left=�$��
630,80,0,0q�$	��Top=�$	��110���� -    ��Name$ Show_Button��$)��#Показати результат��$��Center=�$	��Top=�$	��180��$��30��$��0,35,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ Result_Grid��$
��Left=�$	��360��$��	5,130,0,0q�$	��Top=�$	��300��� $��315,135,0,24q�.+�>  8System.Windows.Controls.DataVisualization.Charting.Chart  -     Name$ Chart��$��0q�   Title$ Графік��   Series. E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries	   DependentValuePath$	 Value��
   IndependentValuePath$	
 Key��   ItemsSource ��  �� Mode$ OneWay=�B  <System.Windows.Controls.DataVisualization.Charting.PieSeries  $	 Value��$	
 Key�� �� $ OneWay=��� -   $ ReportButton��$/��)Надрукувати результат��$
��Left=�$��30��$��
585,35,0,0q�$	��Top=�$	��190��
   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  "    AutoParts.View.EnginesWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$ Двигуни��$	��450��$
��1000��.��� .+��  � RowDefinitions �� �� $��3* � � ColumnDefinitions �� $	��20* ��� $
��105* ��� $
��360* ��� $
��397* ��� $
��110* �.+��� -    ��Name$ Edit_Button��$��Редагувати��$
��Left=�$	��Top=�$��95�� J� RenderTransformOrigin$ 	0.533,0.5&�$��0,75,0,0q�$��1��$��25���� -   $ 
Add_Button��$��Додати��$
��Left=�$	��Top=�$��95��$ 0.5,0.5&�$��0,40,0,0q�$��1��$��25���� -   $��Видалити��$
��Left=�$	��Top=�$��95��$ 	0.533,0.5&�$��0,10,0,0q�$��1��$��25���� -   $ Search_Button��$��0q�$
��Left=�$	��Top=�$	��100��
�������$��2��$��1,2,0,0q�$	��103��.����  �� Orientation$ Vertical=�.+��� $��../Images/Search.jpg��$��75��$��83���� $��Знайти���� -    ��Name$ 	SearchBox��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��209��$��2��$��	107,7,0,0q��� $��2��$��105,30,10,0q�.���� -   	 ��Name$	 
Search_Box��.+��� -   
 ��Name$
 	AllFields�� d� 	IsChecked$ FalseY�$��20��$��По всім полям���� -   $
 ByName��$
 TrueY�$��20��$��По назві���� -	   $
 ByPower��$��20��$��За потужністю���� -
   $
 ByVolume��$��20��$��За об'ємом���� -   $
 ByType��$��20��$��За типом��� $��3��$��0��$��0,0,52,0q�.+��� $��77,0,0,0q�.��� $��0q�$	��290��.+��� $��
Назва��$
��Left=�$��5,35,0,0q�$	��Top=��� -   $ NameBox��$
��Left=�$��23��$��	75,37,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Потужність��$
��Left=�$��0,61,0,0q�$	��Top=��� -   $ PowerBox��$
��Left=�$��23��$��	75,65,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��По об'єму��$
��Left=�$��5,90,0,0q�$	��Top=��� -   $ 	VolumeBox��$
��Left=�$��23��$��	75,95,0,0q�$	��Top=�$	��165���� $��По типу��$
��Left=�$��	5,125,0,0q�$	��Top=��� -   $ TypeBox��$
��Left=�$��23��$��
75,125,0,0q�$	��Top=�$	��165���� -   $ Filter_Button��$��Фільтрувати��$
��Left=�$��	-5,40,0,0q�$	��Top=�$��75���� $!��Сортировать по��$��4��$
��Left=�$��3,5,0,0q�$	��Top=�$��26��$��98���� -   $
��Sort��$��0��$��3��$��349,30,7,45q�$��2��.@��� .��По назві�� .��За потужністю�� .��За об'ємом&   System.Windows.Controls.DataGrid  -     Name$
 Grid��   EnableRowVirtualization .     
IsReadOnly . $
��Left=�$	��290��$��	10,15,0,0q�$��1��$	��Top=�$	��970��$��5���� -   $	 Asc��$
��Left=�$	��Top=�$��30��
�������$��4��$��3,65,0,0q�
������ $��34��$ 0.5,0.5&���Z� .���� $ Vertical=�.+��� $��../Images/ASC.png��$��30���� -   $	 Dsc��$
��Left=�$	��Top=�$��30��
�������$��4��$��	58,66,0,0q�
������ $��34����Z� .���� $ Vertical=�.+��� $��../Images/DESC.png��$��30��
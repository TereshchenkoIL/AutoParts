   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View      AutoParts.View.CarsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$ Автомобілі��$	��450��$
��1000��.���  � RowDefinitions �� �� $��3* � � ColumnDefinitions �� $��0* ��� $
��125* ��� $
��360* ��� $
��345* ��� $
��162* �.+��� -    ��Name$ Edit_Button��$��Редагувати��$
��Left=�$	��Top=�$	��105�� J� RenderTransformOrigin$ 0.5,0.5&�$��	10,75,0,0q�$��25��$��1���� -   $ 
Add_Button��$��Додати��$
��Left=�$	��Top=�$	��100��$ 0.5,0.5&�$��	10,45,0,0q�$��25��$��1���� -   $��Видалити��$
��Left=�$	��Top=�$	��100��$ 	0.533,0.5&�$��	10,15,0,0q�$��25��$��1���� -   $ Search_Button��$
��Left=�$	��Top=�$	��100��
�������$��2��$��1,2,0,0q�$	��103����Z� .����  �� Orientation$ Vertical=�.+��� $��../Images/Search.jpg��$��75��$��83���� $��Знайти���� -    ��Name$ 	SearchBox��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��209��$��2��$��	107,7,0,0q��� $��2��$��105,30,10,0q�.���� -   	 ��Name$	 
Search_Box��.+��� -   
 ��Name$
 	AllFields�� d� 	IsChecked$ FalseY�$��20��$��По всім полям���� -   $
 ByMark��$
 TrueY�$��20��$��По марці���� -	   $
 ByModel��$��20��$��По моделі���� -
   $
 ByYear��$��20��$%��Року виробництва���� -   $
 ByType��$��20��$��По типу��� $��3��$��0��.+��� $��	77,0,10,0q�.��� $��0q�.+��� $��
Марка��$
��Left=�$��5,35,0,0q�$	��Top=��� -   $ MarkBox��$
��Left=�$��23��$��	75,37,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Рік ��$
��Left=�$��7,61,0,0q�$	��Top=�$��55���� -   $ YearBox��$
��Left=�$��23��$��	75,65,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Модель��$
��Left=�$��5,90,0,0q�$	��Top=��� -   $ ModelBox��$
��Left=�$��23��$��	75,95,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Тип��$
��Left=�$��	5,120,0,0q�$	��Top=��� -    ��Name$ TypeBox��$
��Left=�$��
75,125,0,0q�$	��165��$��22��$	��Top=��� -   $
 Is_Type_Filtered��$�� ��$
��Left=�$��
57,125,0,0q�$	��Top=�$��16���� -   $ Filter_Button��$��Фільтрувати��$
��Left=�$��	-1,45,0,0q�$	��Top=�$��75���� $!��Сортировать по��$��4��$
��Left=�$��3,5,0,0q�$	��Top=�$��24��$��96���� -   $
��Sort��$��30��$��0��$��4��$��	4,30,7,45q�.@��� .��Маркою�� .��Моделлю�� .��
Роком�� .��
Типом&   System.Windows.Controls.DataGrid  -     Name$
 Grid��   EnableRowVirtualization .     
IsReadOnly . $
��Left=�$	��290��$��0,15,0,0q�$��1��$	��Top=�$	��970��$��4��$��1���� -   $	 Asc��$
��Left=�$	��Top=�$��30��
�������$��4��$��3,65,0,0q�
������ $��34����Z� .���� $ Vertical=�.+��� $��../Images/ASC.png��$��30���� -   $	 Dsc��$
��Left=�$	��Top=�$��30��
�������$��4��$��	58,66,0,0q�
������ $��34����Z� .���� $ Vertical=�.+��� $��../Images/DESC.png��$��30��
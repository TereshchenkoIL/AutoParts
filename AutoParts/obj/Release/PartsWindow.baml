   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts      AutoParts.PartsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:AutoParts       � Icon$  Images/Parts.png�� � Title$ Запчастини��$	��450��$
��1000��.���  � RowDefinitions �� �� $��3* � � ColumnDefinitions �� $
��101* ��� $	��98* ��� $
��326* ��� $
��355* ��� $
��110* �.+��� -    ��Name$ Edit_Button��$��Редагувати��$
��Left=�$	��Top=�$	��105�� J� RenderTransformOrigin$ 0.5,0.5&�$��
100,75,0,0q�$��25��$��3���� -   $ 
Add_Button��$��0q�$��Додати��$
��Left=�$	��Top=�$	��100��$ 0.5,0.5&�$��
100,45,0,0q�$��25��$��3���� -   $��Видалити��$
��Left=�$	��Top=�$	��100��$ 	0.533,0.5&�$��
100,15,0,0q�$��25��$��3���� -   $ Report_Button��
���������Z� .����  �� Orientation$ Vertical=�.+��� $��Images/Print.jpg��$��75��$��83���� $��Накладна���� -   $ Search_Button��$��0q�$
��Left=�$	��Top=�$	��100��
�������$��2��$��1,2,0,0q���Z� .���� $ Vertical=�.+��� $��Images/Search.jpg��$��75��$��83���� $��Знайти���� -    ��Name$ 	SearchBox��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��209��$��2��$��	107,7,0,0q��� $��2��$��105,30,10,0q�.���� -   	 ��Name$	 
Search_Box��.+��� -   
 ��Name$
 	AllFields�� d� 	IsChecked$ FalseY�$��20��$��По всім полям���� -	   $
 ByName��$
 TrueY�$��20��$��По назві���� -
   $
 ByDesc��$��20��$��По опису���� -   $
 ByProd��$��20��$��По виробнику��� $��3��$��0��.+��� $��	77,0,10,0q�.��� $��0q�.+��� $��Ціна��$
��Left=�$��5,10,0,0q�$	��Top=��� $��Від��$
��Left=�$��55,5,0,0q�$	��Top=��� $
��До��$
��Left=�$��	150,5,0,0q�$	��Top=��� -   $ 
From_Price��$
��Left=�$��23��$��	85,10,0,0q�$
 Wrap=�$	��Top=�$��60���� -   $ To_Price��$
��Left=�$��23��$��
175,10,0,0q�$
 Wrap=�$	��Top=�$��65���� $��
Назва��$
��Left=�$��5,35,0,0q�$	��Top=��� -   $ Name_box��$
��Left=�$��23��$��	75,37,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Гарантія��$
��Left=�$��5,60,0,0q�$	��Top=��� -   $ 
Warrantbox��$
��Left=�$��23��$��	75,65,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Виробник��$
��Left=�$��5,90,0,0q�$	��Top=��� -   $ ProducerBox��$
��Left=�$��23��$��	75,95,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Тип��$
��Left=�$��	5,120,0,0q�$	��Top=��� -    ��Name$ TypeBox��$
��Left=�$��
75,125,0,0q�$	��165��$��22��$	��Top=��� -   $
 Is_Type_Filtered��$�� ��$
��Left=�$��
57,125,0,0q�$	��Top=�$��16���� -   $ Filter_Button��$��Фільтрувати��$
��Left=�$��	-1,45,0,0q�$	��Top=�$��75���� $!��Сортировать по��$��4��$
��Left=�$��3,5,0,0q�$	��Top=��� -   $
��Sort��$��30��$��0��$��3��$��349,30,7,45q�$��2��.@��� .��
Ціні�� .��Гарантії&   System.Windows.Controls.DataGrid  -     Name$
 Grid��   EnableRowVirtualization .     
IsReadOnly . $
��Left=�$	��290��$��	10,15,0,0q�$��1��$	��Top=�$	��970��$��5���� -   $	 Asc��$
��Left=�$	��Top=�$��30��
�������$��4��$��3,65,0,0q�
������ ��Z� .���� $ Vertical=�.+��� $��Images/ASC.png��$��30���� -   $	 Dsc��$
��Left=�$	��Top=�$��30��
�������$��4��$��	58,66,0,0q�
������ ��Z� .���� $ Vertical=�.+��� $��Images/DESC.png��$��30��
   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts      AutoParts.OrdersWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:AutoParts       � Icon$  Images/Parts.png�� � Title$ Закази��$	��450��$
��1000��.���  � RowDefinitions �� �� $��3* � � ColumnDefinitions �� $
��101* ��� $	��98* ��� $
��326* ��� $
��355* ��� $
��110* �.+��� -    ��Name$ Report_Button��
���������Z� .����  �� Orientation$ Vertical=�.+��� $��Images/Print.jpg��$��75��$��83���� $#��Надрукувати чек���� -   $ Edit_Button��$��Редагувати��$
��Left=�$	��Top=�$��95�� J� RenderTransformOrigin$ 	0.533,0.5&�$��4,70,0,0q�$��1��$��25��$��2���� -   $ 
Add_Button��$��Додати��$
��Left=�$	��Top=�$��95��$ 0.5,0.5&�$��4,40,0,0q�$��1��$��25��$��2���� -   $��Видалити��$
��Left=�$	��Top=�$��95��$ 	0.533,0.5&�$��4,10,0,0q�$��1��$��25��$��2���� -   $ Search_Button��$
��Left=�$	��Top=�$	��100��
�������$��2��$��1,2,0,0q���Z� .���� $ Vertical=�.+��� $��Images/Search.jpg��$��75��$��83���� $��Знайти���� -    ��Name$ 	SearchBox��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��209��$��2��$��	107,7,0,0q��� $��2��$��105,30,10,0q�.���� -   	 ��Name$	 
Search_Box��.+��� -   
 ��Name$
 	AllFields�� d� 	IsChecked$ FalseY�$��20��$��По всім полям���� -	   $
 ByDate��$
 TrueY�$��20��$��По даті���� -
   $
 ByCurr��$��20��$��По валюті���� -   $
 ByUser��$��20��$!��По користувачу��� $��3��$��0��.+��� $��	77,0,10,0q�.��� $��0q�.+��� $��
Сумма��$
��Left=�$��5,10,0,0q�$	��Top=��� $��Від��$
��Left=�$��55,5,0,0q�$	��Top=��� $
��До��$
��Left=�$��	150,5,0,0q�$	��Top=��� -   $ From_Sum��$
��Left=�$��23��$��	85,10,0,0q�$
 Wrap=�$	��Top=�$��60���� -   $ To_Sum��$
��Left=�$��23��$��
175,10,0,0q�$
 Wrap=�$	��Top=�$��65���� $��Власник��$
��Left=�$��5,35,0,0q�$	��Top=��� -   $ User_box��$
��Left=�$��23��$��	75,37,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Валюта��$
��Left=�$��5,60,0,0q�$	��Top=��� -   $ Currbox��$
��Left=�$��23��$��	75,65,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��	Дата ��$
��Left=�$��	5,90,0,-1q�$	��Top=��� $��Від��$
��Left=�$��	55,90,0,0q�$	��Top=��� $
��До��$
��Left=�$��
150,90,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -     Name$ 	From_Date��$
��Left=�$��	80,90,0,0q�$	��Top=�$��72��  -   $ To_Date��$
��Left=�$��
177,91,0,0q�$	��Top=�$��72���� -   $ Filter_Button��$��Фільтрувати��$
��Left=�$��	-1,45,0,0q�$	��Top=�$��75���� $!��Сортировать по��$��4��$
��Left=�$��3,5,0,0q�$	��Top=��� -   $
��Sort��$��30��$��0��$��3��$��349,30,7,45q�$��2��.@��� .��
Сумі�� .��Даті створення�� .��Часу створення&   System.Windows.Controls.DataGrid  -     Name$
 Grid��   EnableRowVirtualization .     
IsReadOnly . $
��Left=�$	��290��$��	10,15,0,0q�$��1��$	��Top=�$	��970��$��5���� -   $	 Asc��$
��Left=�$	��Top=�$��30��
�������$��4��$��3,65,0,0q�
������ ��Z� .���� $ Vertical=�.+��� $��Images/ASC.png��$��30���� -   $	 Dsc��$
��Left=�$	��Top=�$��30��
�������$��4��$��	58,66,0,0q�
������ ��Z� .���� $ Vertical=�.+��� $��Images/DESC.png��$��30��
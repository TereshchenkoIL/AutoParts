   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  '    !AutoParts.View.ModificationWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$ Модифікації��$	��450��$
��1019��.���  � RowDefinitions �� �� $��3* � � ColumnDefinitions �� $	��20* ��� $
��107* ��� $
��353* ��� $
��419* ��� $
��112* �.+��� -    ��Name$ Edit_Button��$��Редагувати��$
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
 TrueY�$��20��$��По назві���� -	   $
 
ByComplect��$��20��$#��По комплектації���� -
   $
 ByEngine��$��20��$��По двигуну���� -   $
 ByCar��$��20��$��По Автомобілю���� -   $
 ByType��$��20��$"��По Типу приводу��� $��3��$��0��$��0,0,74,0q�.+��� $��77,0,0,0q�.��� $��0q�$	��290��.+��� $��
Назва��$
��Left=�$��5,35,0,0q�$	��Top=��� -   $ NameBox��$
��Left=�$��23��$��	75,37,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��Комплект��$
��Left=�$��0,61,0,0q�$	��Top=��� -   $ ComplectcBox��$
��Left=�$��23��$��	75,65,0,0q�$
 Wrap=�$	��Top=�$	��165���� $��По двигуну��$
��Left=�$��
-2,105,0,0q�$	��Top=��� -    ��Name$ 	EngineBox��$
��Left=�$��33��$��	75,95,0,0q�$	��Top=�$	��165���� $��По автомобілю��$
��Left=�$��	0,140,0,0q�$	��Top=��� -   $ CarBox��$
��Left=�$��28��$��
80,135,0,0q�$	��Top=�$	��165���� $��Тип приводу��$
��Left=�$��	5,180,0,0q�$	��Top=��� -   $ TypeBox��$
��Left=�$��23��$��
75,180,0,0q�$
 Wrap=�$	��Top=�$	��165���� -   $ Filter_Button��$��Фільтрувати��$
��Left=�$��	-5,25,0,0q�$	��Top=�$��75���� -   $ Cast_Button��$��Скинути��$
��Left=�$��
-10,65,0,0q�$	��Top=�$��85���� $!��Сортировать по��$��4��$
��Left=�$��3,5,0,0q�$	��Top=�$��26��$��98���� -   $
��Sort��$��0��$��3��$��349,31,7,46q�$��2��$��28��.@��� .��По назві�� .��По комплектації�� .��По двигуну�� .��По автомобілі&   System.Windows.Controls.DataGrid  -     Name$
 Grid��   EnableRowVirtualization .     
IsReadOnly . $
��Left=�$	��290��$��	10,15,0,0q�$��1��$	��Top=�$	��970��$��5���� -   $	 Asc��$
��Left=�$	��Top=�$��30��
�������$��4��$��3,65,0,0q�
������ $��34��$ 0.5,0.5&���Z� .���� $ Vertical=�.+��� $��../Images/ASC.png��$��30���� -   $	 Dsc��$
��Left=�$	��Top=�$��30��
�������$��4��$��	58,66,0,0q�
������ $��34����Z� .���� $ Vertical=�.+��� $��../Images/DESC.png��$��30��
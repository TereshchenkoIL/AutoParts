   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts      AutoParts.EditOrder   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:AutoParts       � Icon$  Images/Parts.png�� � Title$) #Редагування заказу��$	��427��$	��694��.��� .+��� $��Користувач��$
��Left=�$��	35,42,0,0q�$	��Top=��� $��Час створення��$
��Left=�$��	40,76,0,0q�$	��Top=��� $!��Дата створення��$
��Left=�$��
40,120,0,0q�$	��Top=��� $��Валюта��$
��Left=�$��
44,155,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -     Name$ Date_picker��$
��Left=�$��160,125,0,0q�$	��Top=�$	��145���� -    ��Name$ Time_Box��$
��Left=�$��23��$��
160,77,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��145���� -   $ Curr_Box��$
��Left=�$��23��$��160,157,0,0q�$
 Wrap=�$	��Top=�$	��145���� -    ��Name$ User_Box��$
��Left=�$��
160,45,0,0q�$	��Top=�$	��145���� $+��%Додати товар в заказ��$
��Left=�$��
454,25,0,0q�$	��Top=��� $��
Товар��$
��Left=�$��
397,55,0,0q�$	��Top=��� -   $ Part_Box��$
��Left=�$��
455,60,0,0q�$	��Top=�$	��150���� $��Кількість��$
��Left=�$��
385,90,0,0q�$	��Top=��� -   $ 
Amount_Box��$
��Left=�$��23��$��
455,92,0,0q�$
 Wrap=�$	��Top=�$	��150���� -   $��Додати��$
��Left=�$��385,140,0,0q�$	��Top=�$��85��&   System.Windows.Controls.DataGrid  -     Name$ 	Part_Grid��$
��Left=�$	��190��$��385,190,0,0q�$	��Top=�$	��285���� -	    ��Name$ Complete_Button��$!��Зберігти зміни��$
��Left=�$��
10,281,0,0q�$	��Top=�$	��135���� -
   $ Cancel_Button��$��Відмінити��$
��Left=�$��170,280,0,0q�$	��Top=�$	��110���� -   $��Видалити��$
��Left=�$��505,138,0,0q�$	��Top=�$	��100��
   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  !    AutoParts.View.Order_Detail   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$, &Інформація про заказ��$	��450��$	��409��.��� .+��� -    ��Name$ Report_Button��
�������$��280,40,6,249q���Z� .����  �� Orientation$ Vertical=�.+��� $��../Images/Print.jpg��$��75��$��83���� $#��Надрукувати чек���� $��Користувач��$
��Left=�$��	26,25,0,0q�$	��Top=��� $��Час створення��$
��Left=�$��	25,60,0,0q�$	��Top=��� $!��Дата створення��$
��Left=�$��	19,95,0,0q�$	��Top=��� $��Валюта��$
��Left=�$��
35,130,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -     Name$ Date_picker��$
��Left=�$��
125,96,0,0q�$	��Top=�$	��145���� -    ��Name$ Time_Box��$
��Left=�$��23��$��
125,62,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��145���� -   $ Curr_Box��$
��Left=�$��23��$��125,132,0,0q�$
 Wrap=�$	��Top=�$	��145��&   System.Windows.Controls.DataGrid  -     Name$ 	Part_Grid��$
��Left=�$	��210��$��
15,175,0,0q�$	��Top=�$	��365���� -   $ UserBox��$
��Left=�$��23��$��
125,20,0,0q�$
 Wrap=�$	��Top=�$	��145��
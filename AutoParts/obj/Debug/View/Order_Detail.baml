   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	   !    AutoParts.View.Order_Detail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Icon$  ../Images/Parts.png��5   	    � Title$, &Інформація про заказ��5	   	   $	��450��6&   $	��409��63   .��5
      � .+�5   
   �� -   5         ��Name$ Report_Button��5   "   
�������$��280,40,6,249q�6h   ��6   Z� .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��../Images/Print.jpg��6   $��75��65   $��83��6@   �� 5      $#��Надрукувати чек��6   5      5      �� 5   
   $��Користувач��6   $
��Left=�6%   $��	26,25,0,0q�6@   $	��Top=�6S   �� 5   
   $��Час створення��6   $
��Left=�6(   $��	25,60,0,0q�6C   $	��Top=�6V   �� 5   
   $!��Дата створення��6   $
��Left=�6)   $��	19,95,0,0q�6D   $	��Top=�6W   �� 5   
   $��Валюта��6   $
��Left=�6!   $��
35,130,0,0q�6<   $	��Top=�6P   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ Date_picker��5      $
��Left=�6*   $��
125,96,0,0q�6E   $	��Top=�6Y   $	��145��6q   �� 5   
   -   5         ��Name$ Time_Box��5      $
��Left=�6$   $��23��6?   $��
125,62,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6t   $	��145��6�   �� 5   
   -   5        $ Curr_Box��5      $
��Left=�6$   $��23��6?   $��125,132,0,0q�6K   $
 Wrap=�6`   $	��Top=�6u   $	��145��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	Part_Grid��5      $
��Left=�6&   $	��210��6A   $��
15,175,0,0q�6N   $	��Top=�6b   $	��365��6z   �� 5   
   -   5        $ UserBox��5      $
��Left=�6#   $��23��6>   $��
125,20,0,0q�6J   $
 Wrap=�6^   $	��Top=�6s   $	��145��6�   5      5      
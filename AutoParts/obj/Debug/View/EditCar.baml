   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	       AutoParts.View.EditCar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Icon$  ../Images/Parts.png��5   	    � Title$/ )Редагувати автомобілі��5	   	   $	��322��6'   $	��359��64   .��5
      � .+�5   
   �� $��
Марка��6   $
��Left=�6    $��25��6;   $��	35,45,0,0q�6G   $	��Top=�6Z   $��55��6r   �� 5   
   $��Модель��6   $
��Left=�6!   $��25��6<   $��	30,85,0,0q�6H   $	��Top=�6[   $��55��6s   �� 5   
   $#��Рік виробництва��6   $
��Left=�6*   $��25��6E   $��
30,125,0,0q�6Q   $	��Top=�6e   $	��105��6}   �� 5   
   $��Тип��6   $
��Left=�6   $��25��69   $��
30,160,0,0q�6E   $	��Top=�6Y   $	��105��6q   �� 5   
   $
��Left=�5   '   $��25��6B   $��
150,85,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6w   $	��165��6�   ��5      ��  �� Path$ Model� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditCarL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5   �   �� 5   
   $
��Left=�5   '   $��25��6B   $��
150,45,0,0q�6N   $
 Wrap=�6b   $	��Top=�6w   $	��165��6�   ��5      �� $
 Mark� �� *FindAncestor+$ local:EditCarL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   $
��Left=�5   '   $��25��6B   $��150,125,0,0q�6N   $
 Wrap=�6c   $	��Top=�6x   $	��165��6�   ��5      �� $
 Year� �� *FindAncestor+$ local:EditCarL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   -   5         ��Name$ TypeBox��5      $
��Left=�6$   $��150,162,0,0q�6?   $	��Top=�6T   $	��165��6l   6x   �� 5   
   -   5        	 ��Name$	 CompleteButton��5      $��Зберігти��6)   $
��Left=�6<   $��50��6W   $��
80,210,0,0q�6c   $	��Top=�6w   $	��190��6�   6�   �� 5   
   $��Додати Авто��6   $
��Left=�6&   $��25��6A   $��
125,10,0,0q�6M   $	��Top=�6a   $��80��6y   5      5       
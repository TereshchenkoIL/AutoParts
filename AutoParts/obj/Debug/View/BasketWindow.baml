   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	   !    AutoParts.View.BasketWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Title$  Корзина��5   	   $	��450��6   $	��449��6&    � Icon$ ../Images/Parts.png��5	   	   .��5
      � .+�5   
   �� $��Корзина��6   $
��Left=�6"   $��30��6=   $��
175,10,0,0q�6I   $	��Top=�6]   $��75��6u   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 Grid��5         AutoGenerateColumns .  $
��Left=�6=   $	��295��6X   $��	10,40,0,0q�6e   $	��Top=�6x   $	��420��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Назва��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$
 Name�6R     5      $ Кількість��6%   $	 100 6Z    68   �� $ Quantity�6Z     5      $ Ціна��6%   $ 80 6R    63   �� $ Price�6R   5      �� 5   
   $��Загальна сума��6   $
��Left=�6(   $��30��6C   $��
40,375,0,0q�6O   $	��Top=�6c   $	��105��6{   �� 5   
   -   5        	 ��Name$	 
TotalLabel��5      $
��Left=�6$   $��235,375,0,0q�6?   $	��Top=�6T   
 J� RenderTransformOrigin$
 0.5,0.5&�6l   $	��140��6�   5      �� 5   
   -   5         ��Name$ DeleteButton��5      $��Видалити��6'   $
��Left=�6:   $��25��6U   $��
40,345,0,0q�6a   $	��Top=�6u   $	��105��6�   6�   �� 5   
   -   5        $ CompleteButton��5      $��Оформити��6)   $
��Left=�6<   $��25��6W   $��310,345,0,0q�6c   $	��Top=�6x   $	��115��6�   6�   5      5      
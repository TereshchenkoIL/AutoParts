   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  !    AutoParts.View.BasketWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Title$  Корзина��$	��450��$	��449�� � Icon$ ../Images/Parts.png��.��� .+��� $��Корзина��$
��Left=�$��30��$��
175,10,0,0q�$	��Top=�$��75��&   System.Windows.Controls.DataGrid  -     Name$
 Grid��   AutoGenerateColumns .  $
��Left=�$	��295��$��	10,40,0,0q�$	��Top=�$	��420��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Назва��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$
 Name�  $ Кількість��$	 100  �� $ Quantity�  $ Ціна��$ 80  �� $ Price��� $��Загальна сума��$
��Left=�$��30��$��
40,375,0,0q�$	��Top=�$	��105���� -   	 ��Name$	 
TotalLabel��$
��Left=�$��235,375,0,0q�$	��Top=�
 J� RenderTransformOrigin$
 0.5,0.5&�$	��140���� -    ��Name$ DeleteButton��$��Видалити��$
��Left=�$��25��$��
40,345,0,0q�$	��Top=�$	��105���� -   $ CompleteButton��$��Оформити��$
��Left=�$��25��$��310,345,0,0q�$	��Top=�$	��115��
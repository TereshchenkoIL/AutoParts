   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	   #    AutoParts.View.Cars_Selection   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Title$  Каталог��5   	   $	��500��6   $
��1000��6&    � Icon$ ../Images/Parts.png��5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $
��130* �6   6,   �� 5      $
��339* �6   6,    � ColumnDefinitions 5   
   �� 5      $
��115* �6   6.   �� 5      $
��310* �6   �� 5      $
��295* �6   6.   �� 5      $
��272* �6   .+�5   
   �� -   5         ��Name$ Report_Button��5      
�������$
��Auto��6W   $��0,5,0,0q�6e   .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��../Images/Print.jpg��6   $��75��65   $��83��6@   �� 5      $��Накладна��6   
���   �6,   5      5      �� 5   
   -   5        $ Search_Button��5      $
��Left=�6)   $	��Top=�6D   $��94��6\   
�������$��1��6z   $��1,2,0,0q�6�   $	��128��6�   $��0q�6�   .��5      �� $ Vertical=�6   .+�5      �� $��../Images/Search.jpg��6   $��75��66   $��83��6A   �� 5       $��Знайти��6   
���   �6*   5!      5"      �� 5$   
   -   5         ��Name$ 	SearchBox��5$      $
��Left=�6%   $��23��6@    �� TextWrapping$
 Wrap=�6L   $	��Top=�6a   $	��150��6y   $��1��6�   $��	105,5,0,0q�6�   �� 5%   
   $��1��6   $��105,30,74,0q�6'   .��5&      �� -   5         ��Name$ 
Search_Box��5&      .+�5'      �� -   5        	 ��Name$	 	AllFields��5'      
 d� 	IsChecked$
 FalseY�6/   $��20��6A   $��По всім полям��6M   �� 5(      -   5        $	 ByName��5(      $

 TrueY�6,   $��20��6=   $��По назві��6I   �� 5)      -   5        $	 ByProd��5)      $��20��6-   $��По виробнику��69   �� 5*      -   5        $	 ByType��5*      $��20��6-   $��По типу��69   �� 5+      -	   5        $	 ByСar��5+      $��20��6,   $��По автомобілю��68   5,      5-      � 5.   
   $��2��6   $��0��6   $��	5,35,10,0q�6,   .+�5/      �� $��0,0,10,0q�6    J� RenderTransformOrigin$ 0.5,0.5&�6-   z�50      V� 51      .~�52      �� �� 53       �� AngleX$ -0.535Q�6(   �� 54      T� 55       T� X$ -0.491Q�6-   56      .��58      � $��0q�6   .+�59      �� $��Ціна��6   $
��Left=�6+   $��5,10,0,0q�6F   $	��Top=�6X   �� 5:      $��Від��6   $
��Left=�6*   $��55,5,0,0q�6E   $	��Top=�6W   �� 5;      $
��До��6   $
��Left=�6)   $��	150,5,0,0q�6D   $	��Top=�6W   �� 5<      -
   5        $ 
From_Price��5<      $
��Left=�62   $��23��6M   $��	85,10,0,0q�6Y   $
 Wrap=�6l   $	��Top=�6�   $��60��6�   �� 5=      -   5        $ To_Price��5=      $
��Left=�60   $��23��6K   $��
175,10,0,0q�6W   $
 Wrap=�6k   $	��Top=�6�   $��65��6�   �� 5>      $��
Назва��6   $
��Left=�6,   $��5,35,0,0q�6G   $	��Top=�6Y   �� 5?      -   5        $ Name_box��5?      $
��Left=�60   $��23��6K   $��	75,37,0,0q�6W   $
 Wrap=�6j   $	��Top=�6   $	��165��6�   �� 5@      $��Гарантія��6   $
��Left=�6/   $��5,60,0,0q�6J   $	��Top=�6\   �� 5A      -   5        $ 
Warrantbox��5A      $
��Left=�62   $��23��6M   $��	75,65,0,0q�6Y   $
 Wrap=�6l   $	��Top=�6�   $	��165��6�   �� 5B      $��Виробник��6   $
��Left=�6/   $��5,90,0,0q�6J   $	��Top=�6\   �� 5C      -   5        $ ProducerBox��5C      $
��Left=�63   $��23��6N   $��	75,95,0,0q�6Z   $
 Wrap=�6m   $	��Top=�6�   $	��165��6�   �� 5D      $��Тип��6   $
��Left=�6*   $��	5,120,0,0q�6E   $	��Top=�6X   �� 5E      -   5         ��Name$ TypeBox��5E      $
��Left=�60   $��
75,125,0,0q�6K   $	��165��6_   $��30��6k   $	��Top=�6w   6�   �� 5F      -   5        $	 Is_Type_Filtered��5F      $�� ��69   $
��Left=�6D   $��
57,125,0,0q�6_   $	��Top=�6s   $��16��6�   �� 5H      $��Рейтинг��6   $
��Left=�6.   $��	5,155,0,0q�6I   $	��Top=�6\   �� 5I      $��Від��6   $
��Left=�6*   $��
55,155,0,0q�6E   $	��Top=�6Y   �� 5J      $
��До��6   $
��Left=�6)   $��150,155,0,0q�6D   $	��Top=�6Y   �� 5K      -   5        $ 	From_Rate��5K      $
��Left=�61   $��23��6L   $��
85,165,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $��60��6�   �� 5L      -   5        $ To_Rate��5L      $
��Left=�6/   $��23��6J   $��175,165,0,0q�6V   $
 Wrap=�6k   $	��Top=�6�   $��65��6�   5M      5N      5O      �� 5P   
   $!��Сортировать по��6   $��3��6)   $
��Left=�69   $��7,0,0,0q�6T   $	��Top=�6e   $��26��6}   $��98��6�   �� 5Q   
   -   5        $
��Sort��5Q      $��0��6   $��3��6,   $��10,40,152,62q�6<   $��28��6{   .@�5R      �� .��6   
Ціні6!   �� 5S      .��6   Гарантії6%   �� 5T      .��6   По рейтингу6(   �� 5U      .��6   !Кількості оцінок6-   5V      &   System.Windows.Controls.DataGrid  5W   
   -   5          Name$
 Grid��5W         EnableRowVirtualization .     
IsReadOnly . $
��Left=�6T   $	��313��6o   $��	40,15,0,0q�6|   $��1��6�   $	��Top=�6�   $	��810��6�   $��3��6�   $��1��6�   �� 5X   
   -   5        $	 Asc��5X      $
��Left=�6   $	��Top=�6J   $��40��6b   
�������$��3��6�   $��	10,75,0,0q�6�   
������ $��35��6�   ��69   Z� .��5Y      �� $��33��6   $��30��6$   .+�5Z      �� $��../Images/ASC.png��6   $��35��63   5[      5\      �� 5]   
   -   5        $	 Dsc��5]      $
��Left=�6/   $	��Top=�6J   $��30��6b   
�������$��3��6�   $��	70,81,0,0q�6�   
������ $��34��6�   ��6   Z� .��5^      �� $ Vertical=�6   .+�5_      �� $��../Images/DESC.png��6   $��30��64   5`      5a      �� 5b   
   -   5        $ Filter_Button��5b      $��Фільтрувати��6(   $
��Left=�6>   $��	170,5,0,0q�6Y   $	��Top=�6l   $��85��6�   $��2��6�   $��30��6�   �� 5c   
   -   5        $ Basket_Button��5c      
�������$��3��6M   $��0q�6]   $��225,15,12,62q�6q   $
��Auto��6�   ��6(   Z� .��5d      �� $ Vertical=�6   .+�5e      �� $��../Images/Basket.png��6   5f      5g      �� 5h   
   -   5        $ AddBusket_Button��5h      
�������$��0q�6O   $��180,16,57,57q�6c   $��3��6�   $
��Auto��6�   ��6+   Z� .��5i      �� $ Vertical=�6   .+�5j      �� $��../Images/Add_Basket.png��6   5k      5l      �� 5m   
   $%��Марка автомобіля��6   $
��Left=�6+   $��6,3,0,0q�6F   $	��Top=�6W   $��24��6o   $	��109��6{   $��1��6�   �� 5n   
   -   5        $ MarkBox��5n      $
��Left=�6$   $��	10,23,0,0q�6?   $��1��6R   $	��Top=�6_   $	��130��6w   $��2��6�   $��28��6�   �� 5o   
   $��Рік випуску��6   $
��Left=�6&   $��	10,45,0,0q�6A   $��1��6T   $	��Top=�6a   $��24��6y   $��70��6�   �� 5p   
   -   5        $ YearBox��5p      $
��Left=�6$   $��	10,75,0,0q�6?   $��1��6R   $	��Top=�6_   $	��130��6w   $��2��6�   $��28��6�   �� 5q   
   $��Модель��6   $
��Left=�6!   $��
12,100,0,0q�6<   $��1��6P   $	��Top=�6]   $��24��6u   $��51��6�   �� 5r   
   -   5        $ ModelBox��5r      $
��Left=�6%   $��
10,128,0,0q�6@   $��1��6T   $	��Top=�6a   $	��130��6y   $��2��6�   $��28��6�   �� 5s   
   $��Модифікація��6   $
��Left=�6&   $��
10,150,0,0q�6A   $��1��6U   $	��Top=�6b   $��24��6z   $��79��6�   �� 5t   
   -   5        $ Modif��5t      $
��Left=�6"   $��
10,178,0,0q�6=   $��1��6Q   $	��Top=�6^   $	��130��6v   $��2��6�   $��28��6�   �� 5u   
   -   5        $ Info_Button��5u      
�������$��0q�6K   $��130,20,107,53q�6_   $��3��6�   $
��Auto��6�   ��6&   Z� .��5v      �� $ Vertical=�6   .+�5w      �� $��../Images/Info.png��6   5x      5y      �� 5z   
   -   5        $ 	EndFilter��5z      $!��Скинути фільтр��6%   $��2��6>   $
��Left=�6N   $��10,5,0,0q�6i   $	��Top=�6{   $	��135��6�   $��30��6�   �� 5{   
   $��Тип товару��6   $
��Left=�6%   $��
10,200,0,0q�6@   $��1��6T   $	��Top=�6a   $��24��6y   $��69��6�   �� 5|   
   -    5        $��Type_SelectBox��5|      $
��Left=�6)   $��
10,223,0,0q�6D   $��1��6X   $	��Top=�6e   $	��130��6}   $��2��6�   $��28��6�   �� 5}   
   -!   5        $ 	Pick_Item��5}      $��Підібрати��6$   $
��Left=�68   $��
10,270,0,0q�6S   $��1��6g   $	��Top=�6t   $	��125��6�   $��2��6�   6�   �� 5~   
   -"   5        $ AddReview_Button��5~      
�������$��0q�6O   $��125,64,102,9q�6c   $��3��6z   $
��Auto��6�   ��6+   Z� .��5      �� $ Vertical=�6   .+�5�      �� $��../Images/Lreview.jpg��6   $��39��67   $��44��6C   5�      5�      �� 5�   
   -#   5        $ SeeReview_Button��5�      
�������$��0q�6O   $��170,62,47,11q�6c   $��3��6�   $ 0.778,0.875&�6�   $
��Auto��6�   ��6+   Z� .��5�      �� $ Vertical=�6   .+�5�      �� $��../Images/Sreview.jpg��6   $��39��67   $��44��6C   $ 	0.5,0.513&�6N   5�      5�      5�      5�      
   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	   !    AutoParts.View.EditDiscount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Icon$  ../Images/Parts.png��5   	    � Title$) #Редагування знижки��5	   	   $	��302��6$   $	��339��61   .��5
      � .+�5   
   �� $��
Назва��6   $
��Left=�6    $��	15,55,0,0q�6;   $	��Top=�6N   �� 5   
   $��Опис��6   $
��Left=�6   $��	15,90,0,0q�6:   $	��Top=�6M   �� 5   
   $��Знижка��6   $
��Left=�6!   $��
10,176,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ NameBox��5      $
��Left=�5   '   $��25��6B   $��
110,55,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6w   $	��190��6�   ��5   $   ��  �� Path$
 Name� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditDiscountL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5   �   �� 5   
   -   5        $ DescBox��5      $
��Left=�5   '   $��75��6B   $��
110,85,0,0q�6N   $
 Wrap=�6b   $	��Top=�6w   $	��190��6�   ��5   #   �� $
 Desc� �� *FindAncestor+$ local:EditDiscountL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   -   5        $ DiscBox��5      $
��Left=�5   '   $��25��6B   $��110,175,0,0q�6N   $
 Wrap=�6c   $	��Top=�6x   $	��190��6�   ��5   #   �� $
 Disc� �� *FindAncestor+$ local:EditDiscountL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   -   5        	 ��Name$	 Complete_Button��5      $!��Зберігти зміни��6*   $
��Left=�6C   $��35��6^   $��
70,225,0,0q�6j   $	��Top=�6~   $	��170��6�   6�   5      5      
   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	   %    AutoParts.View.EditModification   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Icon$  ../Images/Parts.png��5   	    � Title$3 -Редагування модифікації��5	   	   $	��377��6)   $	��354��66   .��5
      � .+�5   
   �� $��
Назва��6   $
��Left=�6    $��	35,55,0,0q�6;   $	��Top=�6N   �� 5   
   $��Комплектація��6   $
��Left=�6'   $��
35,125,0,0q�6B   $	��Top=�6V   �� 5   
   $��Тип приводу��6   $
��Left=�6&   $��	35,90,0,0q�6A   $	��Top=�6T   �� 5   
   $��Авто��6   $
��Left=�6   $��
41,161,0,0q�6:   $	��Top=�6N   �� 5   
   $��Двигун��6   $
��Left=�6!   $��
38,205,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ TypeBox��5      $
��Left=�5   '   $��23��6B   $��
160,90,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6w   $	��150��6�   ��5   #   ��  �� Path$
 Type� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditModificationL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5   �   �� 5   
   -   5        $ NameBox��5      $
��Left=�5   '   $��23��6B   $��
160,55,0,0q�6N   $
 Wrap=�6b   $	��Top=�6w   $	��150��6�   ��5   #   �� $
 Name� �� *FindAncestor+$ local:EditModificationL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   -   5        $ ComplectBox��5      $
��Left=�5   '   $��23��6B   $��160,125,0,0q�6N   $
 Wrap=�6c   $	��Top=�6x   $	��150��6�   ��5   '   �� $ Complect� �� *FindAncestor+$ local:EditModificationL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   -   5        	 ��Name$	 CarBox��5      $
��Left=�6#   $��160,160,0,0q�6>   $	��Top=�6S   $	��150��6k   �� 5   
   -   5        $	 	EngineBox��5      $
��Left=�6&   $��160,202,0,0q�6A   $	��Top=�6V   $	��150��6n   �� 5   
   -   5        
 ��Name$
 CompleteButton��5      $!��Зберігти зміни��6)   $
��Left=�6B   $��45��6]   $��
75,280,0,0q�6i   $	��Top=�6}   $	��175��6�   6�   5       5!      
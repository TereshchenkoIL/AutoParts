   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	       AutoParts.View.EditEngine   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Icon$  ../Images/Parts.png��5   	    � Title$+ %Редагування двигуна��5	   	   $	��272��6%   $	��319��62   .��5
      � .+�5   
   �� $��
Назва��6   $
��Left=�6    $��	30,26,0,0q�6;   $	��Top=�6N   �� 5   
   $��Потужність��6   $
��Left=�6%   $��	30,60,0,0q�6@   $	��Top=�6S   �� 5   
   $��	Об'єм��6   $
��Left=�6    $��	29,95,0,0q�6;   $	��Top=�6N   �� 5   
   $��Тип��6   $
��Left=�6   $��
29,121,0,0q�69   $	��Top=�6M   �� 5   
   $
��Left=�5   '   $��23��6B   $��
120,95,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6w   $	��160��6�   ��5      ��  �� Path$ Volume� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditEngineL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5   �   �� 5   
   $
��Left=�5   (   $��23��6C   $��
120,27,0,0q�6O   $
 Wrap=�6c   $	��Top=�6x   $	��160��6�   ��5      �� $
 Name� �� *FindAncestor+$ local:EditEngineL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   $
��Left=�5   '   $��23��6B   $��
120,62,0,0q�6N   $
 Wrap=�6b   $	��Top=�6w   $	��160��6�   ��5      �� $ Power� �� *FindAncestor+$ local:EditEngineL�$ PropertyChanged=�$ TwoWay=�5   �   �� 5   
   $
��Left=�5   '   $��23��6B   $��120,122,0,0q�6N   $
 Wrap=�6c   $	��Top=�6x   $	��160��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��5      �� $
 Type� �� *FindAncestor+$ local:EditEngineL�$ PropertyChanged=�$ TwoWay=�.��5   �   z�5      V� 5       .~�5!      �� �� 5"      �� 5#      	 �� Angle$	 -0.412Q�6&   T� 5$      5%      .��5&   '   5'      �� 5(   
   -   5        
 ��Name$
 CompleteButton��5(      $!��Зберігти зміни��6)   $
��Left=�6B   $��40��6]   $��
60,185,0,0q�6i   $	��Top=�6}   $	��195��6�   6�   5*      5+      
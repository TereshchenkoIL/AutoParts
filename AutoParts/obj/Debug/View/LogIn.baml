   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	       AutoParts.View.LogIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	   -   5          � Icon$  ../Images/Parts.png��5   	    � Title$ Вхід��5	   	   $	��500��6   $	��350��6#    � WindowStartupLocation$ CenterScreen=�6?   .��5
      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF2281D1��6#   � 5      $ 	#FF34268A��6#    � Offset$ 1Q�65   � 5      $ 	#FF33288B��6#   $	 0.5Q�65   5      5      �� 5   
   $��../Images/home.png��6   $	��100��6,   $	��100��68   $	��Top=�6E   $��20q�6]   6k   �� 5   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��0, 100q�6U    �� RadiusY$ 24��6e    �� RadiusX$ 24��6r   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   Color$
 	#FFBBBBBB��6#      	Direction$ 0Q�65      
BlurRadius$ 15Q�6C      ShadowDepth$ 1Q�6S   5      � 5   
   $	��280��6   $	��240��6   $��Bottom=�6(   $��0,100q�6C   .+�5      �� $��Вхід��6   $��Center=�6#   $��40��6@   $��114,14,102,186q�6M   $��64��6e   ���	#FF5F5E5E$��24(�6�   �� 5      $��username��6   $
��Left=�6'   $��30��6B   $��4,84,0,0q�6N   $	��Top=�6`   $��70��6x   �� 5      $��password��6   $
��Left=�6'   $��30��6B   $��	4,161,0,0q�6N   $	��Top=�6a   $��65��6y   �� 5      -   5         ��Name$ 	user_name��5      $
��Left=�6)   $��25��6D   $��	78,84,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��160��6�   G� 5       -   5         G�Name$ user_pas��5       $
��Left=�6,   $��25��6G   $��
78,164,0,0q�6S   $	��Top=�6g   $	��160��6   5!      �� 5"   
   -   5        $��Вхід��5"      $��0q�6    $��Center=�64   $��40��6Q   $��	0,345,0,0q�6]   $	��Top=�6p   $	��185��6�   ���	#FF01AAF9
�������$��18(�6�   6�   �� 5#   
   -   5        $&�� Зарегіструватися��5#      $��0q�6,   $
��Left=�6@   $��25��6[   $��
95,410,0,0q�6g   $	��Top=�6{   ���	#FF01AAF9
�������$	��155��6�   6�   5$      5%      
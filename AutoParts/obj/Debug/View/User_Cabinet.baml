   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	   !    AutoParts.View.User_Cabinet   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:AutoParts.View  5   	     � Icon$  ../Images/Parts.png��5	   	    � Title$+ %Кабінет користувача��5
   	   $	��522��6%   $	��454��62    � WindowStartupLocation$ CenterScreen=�6>   .��5      � -   5         �Name$ MainGrid��5      .+�5   
   �� -   5         ��Name$ Edit_Button��5      
�������$��315,2,26,411q�6T   $��0q�6j   $
��Auto��6~   .��5      ��  �� Orientation$ Vertical=�6    J� RenderTransformOrigin$ 0.522,0.455&�60   $��80��6T   $��70��6_   .+�5      �� $��../Images/Edit.png��6   $��36��64   $��43��6?   �� 5      -   5         ��Name$ 
Edit_Label��5      $��Редагувати��60   
���   �$��26��6U   5      5      �� 5   
   -   5         ��Name$ 
Name_Label��5      $
��Name��6$   $
��Left=�63   $��	15,16,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ Sur_Name��5      $��Surname��6"   $
��Left=�64   $��
15,126,0,0q�6O   $	��Top=�6c   $ 0.526,0.385&�6{   �� 5   
   $��Second_Name��6   $
��Left=�6&   $��	15,72,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        	 ��Name$	 Name_Box��5      $
��Left=�6$   $��23��6?   $��	15,42,0,0q�6K   
 �� TextWrapping$

 Wrap=�6^    �� 
IsReadOnly . $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $	 SurBox��5       . $
��Left=�64   $��23��6O   $��
15,152,0,0q�6[   $

 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $	 SNameBox��5       . $
��Left=�66   $��23��6Q   $��	15,99,0,0q�6]   $

 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5   
   $��Email��6   $
��Left=�6!   $��
15,182,0,0q�6<   $	��Top=�6P   $ 0.526,0.385&�6h   �� 5   
   -	   5        $	 EmailBox��5       . $
��Left=�66   $��23��6Q   $��
15,207,0,0q�6]   $

 Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 5   
   $��Phone��6   $
��Left=�6!   $��
15,242,0,0q�6<   $	��Top=�6P   $ 0.526,0.385&�6h   �� 5   
   -
   5        $	 PhoneBox��5       . $
��Left=�66   $��23��6Q   $��
15,267,0,0q�6]   $

 Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 5   
   $
��City��6   $
��Left=�6    $��
15,302,0,0q�6;   $	��Top=�6O   $ 0.526,0.385&�6g   �� 5   
   -   5        $	 CityBox��5       . $
��Left=�65   $��23��6P   $��
15,327,0,0q�6\   $

 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5   
   $��Адреса��6   $
��Left=�6"   $��
20,354,0,0q�6=   $	��Top=�6Q   $ 0.526,0.385&�6i   �� 5   
   -   5        $	 	AdressBox��5       . $
��Left=�67   $��23��6R   $��
15,377,0,0q�6^   $

 Wrap=�6r   $	��Top=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$
 Grid��5       $
��Left=�6!   $	��275��6<   $��
165,75,0,0q�6I   $	��Top=�6]   $	��255��6u   �� 5!   
   -   5        $B��<Продивитися детальну інформацію��5!      $
��Left=�6;   $��160,365,0,0q�6V   $	��Top=�6k   $	��280��6�   6�   �� 5"   
   -   5        $+��%Переглянути каталог��5"      $
��Left=�6/   $��35��6J   $��210,425,0,0q�6V   $	��Top=�6k   $	��190��6�   6�   5$      5%      
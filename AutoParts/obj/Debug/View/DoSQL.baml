   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  5   	       AutoParts.View.DoSQL   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AutoParts.View     5   	     � Icon$  ../Images/Parts.png��5   	    � Title$ DoSQL��5	   	   $	��450��6   $	��604��6$   .��5
      � .+�5   
   �� -   5         ��Name$ 	QueryText��5      $
��Left=�6%   $	��100��6@   $��	20,15,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $��SELECT * FROM PARTS��6t   $	��Top=�6�   $	��460��6�   �� 5   
   -   5        $��Do SQL��5      $
��Left=�6"   $��
490,28,0,0q�6=   $	��Top=�6Q   $��90��6i   6t   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 Grid��5      $
��Left=�6!   $	��270��6<   $��
20,135,0,0q�6I   $	��Top=�6]   $	��555��6u   �� 5   
   -   5        $��Scheme��5      $
��Left=�6"   $��
490,80,0,0q�6=   $	��Top=�6Q   $��90��6i   6t   5      5      
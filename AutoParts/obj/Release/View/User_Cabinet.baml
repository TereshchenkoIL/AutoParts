   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  !    AutoParts.View.User_Cabinet   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  (localclr-namespace:AutoParts.View    � Icon$  ../Images/Parts.png�� � Title$+ %Кабінет користувача��$	��522��$	��454�� � WindowStartupLocation$ CenterScreen=�.��� -    �Name$ MainGrid��.+��� -    ��Name$ Edit_Button��
�������$��315,2,26,411q�$��0q�$
��Auto��.����  �� Orientation$ Vertical=� J� RenderTransformOrigin$ 0.522,0.455&�$��80��$��70��.+��� $��../Images/Edit.png��$��36��$��43���� -    ��Name$ 
Edit_Label��$��Редагувати��
���   �$��26���� -    ��Name$ 
Name_Label��$
��Name��$
��Left=�$��	15,16,0,0q�$	��Top=��� -   $ Sur_Name��$��Surname��$
��Left=�$��
15,126,0,0q�$	��Top=�$ 0.526,0.385&��� $��Second_Name��$
��Left=�$��	15,72,0,0q�$	��Top=��� -   	 ��Name$	 Name_Box��$
��Left=�$��23��$��	15,42,0,0q�
 �� TextWrapping$

 Wrap=� �� 
IsReadOnly . $	��Top=�$	��120���� -   $	 SurBox�� . $
��Left=�$��23��$��
15,152,0,0q�$

 Wrap=�$	��Top=�$	��120���� -   $	 SNameBox�� . $
��Left=�$��23��$��	15,99,0,0q�$

 Wrap=�$	��Top=�$	��120���� $��Email��$
��Left=�$��
15,182,0,0q�$	��Top=�$ 0.526,0.385&��� -	   $	 EmailBox�� . $
��Left=�$��23��$��
15,207,0,0q�$

 Wrap=�$	��Top=�$	��120���� $��Phone��$
��Left=�$��
15,242,0,0q�$	��Top=�$ 0.526,0.385&��� -
   $	 PhoneBox�� . $
��Left=�$��23��$��
15,267,0,0q�$

 Wrap=�$	��Top=�$	��120���� $
��City��$
��Left=�$��
15,302,0,0q�$	��Top=�$ 0.526,0.385&��� -   $	 CityBox�� . $
��Left=�$��23��$��
15,327,0,0q�$

 Wrap=�$	��Top=�$	��120���� $��Адреса��$
��Left=�$��
20,354,0,0q�$	��Top=�$ 0.526,0.385&��� -   $	 	AdressBox�� . $
��Left=�$��23��$��
15,377,0,0q�$

 Wrap=�$	��Top=�$	��120��&   System.Windows.Controls.DataGrid  -     Name$
 Grid��$
��Left=�$	��275��$��
165,75,0,0q�$	��Top=�$	��255���� -   $B��<Продивитися детальну інформацію��$
��Left=�$��160,365,0,0q�$	��Top=�$	��280���� -   $+��%Переглянути каталог��$
��Left=�$��35��$��210,425,0,0q�$	��Top=�$	��190��
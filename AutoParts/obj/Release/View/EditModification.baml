   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  %    AutoParts.View.EditModification   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$3 -Редагування модифікації��$	��377��$	��354��.��� .+��� $��
Назва��$
��Left=�$��	35,55,0,0q�$	��Top=��� $��Комплектація��$
��Left=�$��
35,125,0,0q�$	��Top=��� $��Тип приводу��$
��Left=�$��	35,90,0,0q�$	��Top=��� $��Авто��$
��Left=�$��
41,161,0,0q�$	��Top=��� $��Двигун��$
��Left=�$��
38,205,0,0q�$	��Top=��� -    ��Name$ TypeBox��$
��Left=�$��23��$��
160,90,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��150������  �� Path$
 Type� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditModificationL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� -   $ NameBox��$
��Left=�$��23��$��
160,55,0,0q�$
 Wrap=�$	��Top=�$	��150������ $
 Name� �� *FindAncestor+$ local:EditModificationL�$ PropertyChanged=�$ TwoWay=��� -   $ ComplectBox��$
��Left=�$��23��$��160,125,0,0q�$
 Wrap=�$	��Top=�$	��150������ $ Complect� �� *FindAncestor+$ local:EditModificationL�$ PropertyChanged=�$ TwoWay=��� -   	 ��Name$	 CarBox��$
��Left=�$��160,160,0,0q�$	��Top=�$	��150���� -   $	 	EngineBox��$
��Left=�$��160,202,0,0q�$	��Top=�$	��150���� -   
 ��Name$
 CompleteButton��$!��Зберігти зміни��$
��Left=�$��45��$��
75,280,0,0q�$	��Top=�$	��175��
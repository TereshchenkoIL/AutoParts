   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View  !    AutoParts.View.EditProducer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$/ )Редагування виробника��$	��312��$	��329��.��� .+��� $��
Назва��$
��Left=�$��	15,55,0,0q�$	��Top=��� $��Опис��$
��Left=�$��	15,90,0,0q�$	��Top=��� $��Рік створення��$
��Left=�$��
10,176,0,0q�$	��Top=��� -    ��Name$ NameBox��$
��Left=�$��25��$��
110,55,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��190������  �� Path$
 Name� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditProducerL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� -   $ DescBox��$
��Left=�$��75��$��
110,85,0,0q�$
 Wrap=�$	��Top=�$	��190������ $
 Desc� �� *FindAncestor+$ local:EditProducerL�$ PropertyChanged=�$ TwoWay=��� -   $ YearBox��$
��Left=�$��25��$��110,175,0,0q�$
 Wrap=�$	��Top=�$	��190������ $
 Year� �� *FindAncestor+$ local:EditProducerL�$ PropertyChanged=�$ TwoWay=��� -   	 ��Name$	 Complete_Button��$!��Зберігти зміни��$
��Left=�$��35��$��
70,225,0,0q�$	��Top=�$	��170��
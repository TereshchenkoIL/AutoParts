   M S B A M L   `   `   `  ���� D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoParts.ViewAutoParts.View      AutoParts.View.EditCar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:AutoParts.View       � Icon$  ../Images/Parts.png�� � Title$/ )Редагувати автомобілі��$	��322��$	��359��.��� .+��� $��
Марка��$
��Left=�$��25��$��	35,45,0,0q�$	��Top=�$��55���� $��Модель��$
��Left=�$��25��$��	30,85,0,0q�$	��Top=�$��55���� $#��Рік виробництва��$
��Left=�$��25��$��
30,125,0,0q�$	��Top=�$	��105���� $��Тип��$
��Left=�$��25��$��
30,160,0,0q�$	��Top=�$	��105���� $
��Left=�$��25��$��
150,85,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��165������  �� Path$ Model� �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:EditCarL� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $
��Left=�$��25��$��
150,45,0,0q�$
 Wrap=�$	��Top=�$	��165������ $
 Mark� �� *FindAncestor+$ local:EditCarL�$ PropertyChanged=�$ TwoWay=��� $
��Left=�$��25��$��150,125,0,0q�$
 Wrap=�$	��Top=�$	��165������ $
 Year� �� *FindAncestor+$ local:EditCarL�$ PropertyChanged=�$ TwoWay=��� -    ��Name$ TypeBox��$
��Left=�$��150,162,0,0q�$	��Top=�$	��165���� -   	 ��Name$	 CompleteButton��$��Зберігти��$
��Left=�$��50��$��
80,210,0,0q�$	��Top=�$	��190���� $��Додати Авто��$
��Left=�$��25��$��
125,10,0,0q�$	��Top=�$��80��
   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    DebtBook$   DebtBook.Views.AddDebtorWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59Y UPrism.Unity.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5   	   3System&clr-namespace:System;assembly=mscorlib 	 5   	     � SizeToContent$  WidthAndHeight=�5
   !    � WindowStartupLocation$ CenterScreen=�6@   $	��400��6e   $	��600��6u    � Title 6	   �� *Title+ +� FocusedElement 6�   ��  �� ElementName$ tbxName��.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��3q�6!   Name:63   �� 5   
   $��2��6   $��3q�6!   Initial Debt6;   �� 5   
   $��4��6   $��3q�6!   Date63   �� 5   
   -   5        $��tbxName��5      $��1��5      $��1��5      $	��100��5      $��3q�5      ��5      ��  �� Path$ NewDebtor.Name�5      �� 5!   
   -   5        $��tbxTotalDebt��5"      $��3��5!      $��2��5$      $��3q�5%      ��5#      �� $ NewDebtor.TotalDebt� �� StringFormat$ N0��5%      (  "System.Windows.Controls.DatePicker  5(   
   -   5        $��
DatePicker��5)      $��5��5(      $��5q�5*      $��3��5+         SelectedDate 5,      �� $ InitDate�	 �� Mode$	 TwoWay=�

 �� Now �� TargetNullValue# Z
 � 5/   
   $��6��6   $��0��6!   $��Right=�62   $��Bottom=�6N   .+�50      �� -   5        $
��SAVE��50      $��5q�51       �� 	IsDefault$
 True��52      $��5��53      $��75��54      ��55      �� *CommandSaveDebtor+56      �� 59      $��CANCEL��6   $��5q�5:      $
 True��5;      $��4��5<      $��75��5=       �� IsCancel$
 True��5>      5B      5D      5E      
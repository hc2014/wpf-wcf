   M S B A M L   `   `   `  ���� G  CAdminManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AdminManager.UserControlsAdminManager.UserControls  (    "AdminManager.Windows.EditOrderInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9Local'clr-namespace:AdminManager.UserControls     X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  EditOrderInfo��$	��500��$	��500�� � 
ResizeMode$ NoResize=�.���  � 	Resources  �� 
TargetType �� Property �� Value��%�  '��       '�� V     '�� �     '��     �� " ��.���  � ��$ Right=���  � ��$ Center=���  � ��$ 30���� " ��.���  � ��$ 3q���  � ��$ 30����  � ��$ 50���� " ��.���  � ��$ 24����  � ��$	 120����  � ��$
 Left=���  � ��$ Center=��� " ��.���  � ��$ 24����  � ��$
 Left=���  � ��$ Center=� � RowDefinitions �� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��80 ��� $��40 ��� $��40 ��� $��80 ��� $
��auto � � ColumnDefinitions �� $��75 ��� $	��150 ��� $��75 ��� $	��150 �.+��� -    ��Name$ 
lb_orderid��$��0��$��0��$��
订单号:���� -   	 ��Name$	 txt_ordreid��
 �� 
IsReadOnly
 . $��1��$��0���� -   $ lb_date��$��2��$��0��$��订单日期:��&   Xceed.Wpf.Toolkit.DateTimePicker  -   $
��date��$��3��$��0��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��140���� -   $ lb_UserName��$��0��$��1��$��
收件人:���� -   $	 txt_UserName��$��1��$��1���� -   $ lb_ProductName��$��2��$��1��$��产品名称:���� -	    ��Name$ Com_ProductName��$��3��$	��120��$��1���� -
   $ lb_Price��$��0��$��2��$��单价(￥):���� -   $	 	txt_Price��$��1��$��2���� -   $ lb_count��$��2��$��2��$��产品数量:���� -   $	 	txt_count��$��3��$��2���� -   $ 
lb_Address��$��0��$��3��$��收件地址:���� $��3��$��1��$��3�� �� Orientation$ 
Horizontal=�$
��Left=�$��10q�.+��� -   $��Com_provance��$	��5 0q�$	��100���� -   $��Com_city��$	��5 0q�$	��100���� -   $��Com_borough��$	��5 0q�$	��100���� -   $	 txt_address��$	��300��$��60��$��3��$��1��$��4��$
��Left=��� -   $ lb_Tel��$��0��$��5��$��电话号码:���� -   $	 txt_Tel��$��1��$��5���� -   $ 	lb_Mobile��$��2��$��5��$��手机号码:���� -   $	 
txt_Mobile��$��3��$��5���� -   $ lb_QQ��$��0��$��6��$	��QQ:���� -   $	 txt_QQ��
 . $��1��$��6���� -   $ lb_Email��$��2��$��6��$��邮件:���� -   $	 	txt_Email��
 . $��3��$��6���� -   $ 	lb_Remark��$��Center=�$��0��$��7��$��备注:���� -   $	 
txt_remark��$	��300��$��60��$��3��$��1��$��7��$
��Left=��� $��3��$��8��$ 
Horizontal=�$��Right=�.+��� -    ��Name$ btn_sure��$��确定���� -   $ 
btn_Cancle��$��取消��
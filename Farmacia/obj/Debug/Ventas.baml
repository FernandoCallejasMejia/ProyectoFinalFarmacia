   M S B A M L   `   `   `  ����C  ?Farmacia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FarmaciaFarmacia  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	       Farmacia.Ventas   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Farmacia     5   	   Rforms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	     � Title$  Ventas��5	   	   $	��500��6   $	��400��6%   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��30(�6   $��Center=�6   $��0��6;   .��6H   Venta6O   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��100��6   .��6$   
Empleado6.   �� 5      -   5         ��Name$ cmbEmpleados��5   '   $	��250��6   6?   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��100��6   .��6$   
Producto6.   �� 5      -   5        $ cmbProductos��5   '   $	��250��6   6?   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��100��6   .��6$   	Cliente6-   �� 5      -   5        $ cmbClientes��5   '   $	��250��6   6>   5       �� 5!      $ 
Horizontal=�6   .+�5"      �� $	��100��6   .��6$   
Cantidad6.   �� 5#      -   5         ��Name$ txbCantidad��5#      $��50��6/   6<   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��50��6   $��20,0,0,0q�6#   .��65   Precio6=   �� 5'      -   5        $ 	txbPrecio��5'      $��60��6-   5(      �� 5)      $ 
Horizontal=�6   .+�5*      �� $	��152��6   6&   �� 5+      $	��149��6   $��15(�6$   .��62   Datos del cliente6E   �� 5,      $	��119��6   6&   5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� $	��100��6   .��6$   Nombre6,   �� 50      -   5        $ 	txbNombre��50      $	��250��6-   6;   51      �� 52      $ 
Horizontal=�6   .+�53      �� $	��100��6   .��6$   	Direccion6/   �� 54      -   5        $ txbDireccion��54      $	��250��60   6>   55      �� 56      $ 
Horizontal=�6   .+�57      �� $	��100��6   .��6$   RFC6)   �� 58      -   5        $ txbRFC��58      $	��250��6*   68   59      �� 5:      $ 
Horizontal=�6   .+�5;      �� $	��100��6   .��6$   	Teléfono6.   �� 5<      -	   5        $ txbTelefono��5<      $	��250��6/   6=   5=      �� 5>      $ 
Horizontal=�6   .+�5?      �� $	��100��6   .��6$   Email6+   �� 5@      -
   5        $ txbEmail��5@      $	��250��6,   6:   5A      5B      � 5C   
   $��2��6   .+�5D      �� -   5         ��Name$ btnNuevo��5D   !   $��80��6   $��	120,0,0,0q�6L   .��6`   Nueva Venta6m   �� 5E      -   5        $ btnCalcular��5E   !   $��80��6   $��Calcular Total��6R   $��0q�6k   5F      � 5G   
   $��3��6   .+�5H      �� -   5        $ 
btnGenerar��5H   !   $	��200��6   $��Generar Ticket��6N   $��Center=�6g   $��	100,0,0,0q�6�   5I      � 5J   
   $��4��6   .+�5K      �� $ 
Horizontal=�6   .+�5L      �� $	��100��6   .��6$   Total a Pagar63   �� 5M      -   5        $ txbTotal��5M      $	��250��6,   6:   5N      5O      5P      5Q      
   M S B A M L   `   `   `  ����C  ?Farmacia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FarmaciaFarmacia  5   	       Farmacia.Productos   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Farmacia     5   	     � Title$  	Productos��5   	   $	��400��6   $	��400��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��30(�6   $��Center=�6    $��0��6=   .��6J   	Productos6U   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��105��6   .��6&   Nombre6.   �� 5      -   5         ��Name$ 	txbNombre��5      $	��250��6.   6>   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��105��6   .��6&   Descripcion63   �� 5      -   5        $ txbDescripcion��5      $	��250��63   6C   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��105��6   .��6&   Precio de compra68   �� 5      -   5        $ txbPrecioCompra��5      $	��250��64   6D   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��105��6   .��6&   Precio de venta67   �� 5       -   5        $ txbPrecioVenta��5       $	��250��63   6C   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $	��105��6   .��6&   Presentacion64   �� 5$      -   5        $ txbPresentacion��5$      $	��250��64   6D   5%      5&      � 5'   
   $��2��6   .+�5(      �� -   5         ��Name$ btnNuevo��5(   !   $��70��6   .��6M   Nuevo6T   �� 5)      -   5        $ 
btnGuardar��5)   !   $��70��6   .��6Q   	Guardar6Z   �� 5*      -   5        $ 	btnEditar��5*   !   $��70��6   .��6O   Editar6W   �� 5+      -	   5        $ btnCancelar��5+   !   $��70��6   .��6S   
Cancelar6]   �� 5,      -
   5        $ btnEliminar��5,   !   $��70��6   .��6S   
Eliminar6]   5-      &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ dtgProductos��5.         
IsReadOnly . $��3��6=   5/      50      
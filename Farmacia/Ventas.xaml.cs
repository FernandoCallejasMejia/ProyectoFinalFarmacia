using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Farmacia
{
    /// <summary>
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        RepositorioDeEmpleados repositorioEmpleados;
        RepositorioDeProductos repositorioProductos;
        RepositorioDeClientes repositorioClientes;
        public Ventas()
        {
            InitializeComponent();
            Cliente cliente = new Cliente();
            repositorioEmpleados = new RepositorioDeEmpleados();
            repositorioProductos = new RepositorioDeProductos();
            repositorioClientes = new RepositorioDeClientes();
            cmbEmpleados.ItemsSource = repositorioEmpleados.LeerEmpleados();
            cmbProductos.ItemsSource = repositorioProductos.LeerProductos();
            cmbClientes.ItemsSource = repositorioClientes.LeerClientes();
            txbDireccion.Text = cliente.Direccion;
            txbNombre.Text = cliente.Nombre;
            txbRFC.Text = cliente.RFC;
            txbTelefono.Text = cliente.Telefono;
            txbEmail.Text = cliente.Correo;
            HabilitarCajas(false);
            HabilitarCalcular(false);
            HabilitarGenerar(false);
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbNombre.Clear();
            txbDireccion.Clear();
            txbTelefono.Clear();
            txbRFC.Clear();
            txbEmail.Clear();
            txbCantidad.Clear();
            txbPrecio.Clear();
            txbTotal.Clear();
            txbNombre.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbRFC.IsEnabled = habilitadas;
            txbEmail.IsEnabled = habilitadas;
            txbCantidad.IsEnabled = habilitadas;
            txbPrecio.IsEnabled = habilitadas;
            txbTotal.IsReadOnly = habilitadas;
            cmbProductos.IsEnabled = habilitadas;
            cmbClientes.IsEnabled = habilitadas;
            cmbEmpleados.IsEnabled = habilitadas;
        }

        private void HabilitarCalcular(bool habilitados)
        {
            btnCalcular.IsEnabled = habilitados;
        }

        private void HabilitarGenerar(bool habilitados)
        {
            btnGenerar.IsEnabled = habilitados;
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            ArchivoTicket archivo = new ArchivoTicket();
            if (archivo.GenerarTicket(txbNombre.Text,cmbProductos.Text,float.Parse(txbPrecio.Text),int.Parse(txbCantidad.Text),float.Parse(txbTotal.Text),cmbEmpleados.Text ,txbNombre.Text+".txt"))
            {
                MessageBox.Show("Ticket generado correctamente", "Mi Pequeño Enfermito", MessageBoxButton.OK, MessageBoxImage.Information);
                HabilitarCalcular(false);
            }
            else
            {
                MessageBox.Show("Error al generar el ticket", "Mi Pequeño Enfermito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            HabilitarCalcular(false);
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarCalcular(true);
            HabilitarGenerar(false);
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbEmail.Text) || string.IsNullOrEmpty(txbCantidad.Text) || string.IsNullOrEmpty(txbPrecio.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Guardado con Éxito", "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
                HabilitarGenerar(true);
                HabilitarCalcular(false);
                HabilitarCalcular(true);
                Venta venta = new Venta();
                venta.Cantidad = int.Parse(txbCantidad.Text);
                venta.Precio = float.Parse(txbPrecio.Text);
                txbTotal.Text = venta.CalcularTotal().ToString();
            } 
        }
    }
}
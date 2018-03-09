using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        RepositorioDeClientes repositorio;
        bool esNuevo;
        public Clientes()
        {
            InitializeComponent();
            repositorio = new RepositorioDeClientes();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbDireccion.Clear();
            txbRFC.Clear();
            txbTelefono.Clear();
            txbNombre.Clear();
            txbEmail.Clear();
            txbDireccion.IsEnabled = habilitadas;
            txbRFC.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbNombre.IsEnabled = habilitadas;
            txbEmail.IsEnabled = habilitadas;
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbTelefono.Text) || string.IsNullOrEmpty(txbEmail.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Cliente c = new Cliente()
                {
                    Direccion = txbDireccion.Text,
                    RFC = txbRFC.Text,
                    Telefono = txbTelefono.Text,
                    Nombre = txbNombre.Text,
                    Correo = txbEmail.Text
                };
                if (repositorio.AgregarCliente(c))
                {
                    MessageBox.Show("Guardado con Éxito", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente original = dtgClientes.SelectedItem as Cliente;
                Cliente c = new Cliente();
                c.Direccion = txbDireccion.Text;
                c.RFC = txbRFC.Text;
                c.Telefono = txbTelefono.Text;
                c.Nombre = txbNombre.Text;
                c.Correo = txbEmail.Text;
                if (repositorio.ModificarCliente(original, c))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("El cliente ha sido actualizado", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgClientes.ItemsSource = null;
            dtgClientes.ItemsSource = repositorio.LeerClientes();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerClientes().Count == 0)
            {
                MessageBox.Show("No hay clientes", "No existen clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgClientes.SelectedItem != null)
                {
                    Cliente c = dtgClientes.SelectedItem as Cliente;
                    if (MessageBox.Show("Realmente deseas eliminar " + c.Nombre + "?", "Eliminar?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarCliente(c))
                        {
                            MessageBox.Show("El cliente ha sido eliminado", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿Quien?", "Cliente", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerClientes().Count == 0)
            {
                MessageBox.Show("No hay clientes", "No existen clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgClientes.SelectedItem != null)
                {
                    Cliente c = dtgClientes.SelectedItem as Cliente;
                    HabilitarCajas(true);
                    txbDireccion.Text = c.Direccion;
                    txbRFC.Text = c.RFC;
                    txbTelefono.Text = c.Telefono;
                    txbNombre.Text = c.Nombre;
                    txbEmail.Text = c.Correo;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Quien?", "Cliente", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}

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
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        RepositorioDeEmpleados repositorio;
        bool esNuevo;
        public Empleados()
        {
            InitializeComponent();
            repositorio = new RepositorioDeEmpleados();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbNombre.Clear();
            txbNombre.IsEnabled = habilitadas;
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Empleado o = new Empleado()
                {
                    Nombre = txbNombre.Text,
                };
                if (repositorio.AgregarEmpleado(o))
                {
                    MessageBox.Show("Guardado con Éxito", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado original = dtgEmpleados.SelectedItem as Empleado;
                Empleado o = new Empleado();
                o.Nombre = txbNombre.Text;
                if (repositorio.ModificarEmpleado(original, o))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("El empleado ha sido actualizado", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar al empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = repositorio.LeerEmpleados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerEmpleados().Count == 0)
            {
                MessageBox.Show("No hay empleados", "No tienes empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmpleados.SelectedItem != null)
                {
                    Empleado o = dtgEmpleados.SelectedItem as Empleado;
                    HabilitarCajas(true);
                    txbNombre.Text = o.Nombre;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien?", "Empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerEmpleados().Count == 0)
            {
                MessageBox.Show("No hay empleados", "No existen empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmpleados.SelectedItem != null)
                {
                    Empleado o = dtgEmpleados.SelectedItem as Empleado;
                    if (MessageBox.Show("Realmente deseas eliminar a " + o.Nombre + "?", "Eliminar?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarEmpleado(o))
                        {
                            MessageBox.Show("El empleado ha sido eliminado", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien?", "Empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
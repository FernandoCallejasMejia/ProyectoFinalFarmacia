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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        RepositorioDeProductos repositorio;
        bool esNuevo;
        public Productos()
        {
            InitializeComponent();
            repositorio = new RepositorioDeProductos();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void HabilitarCajas(bool habilitadas)
        {
            txbDescripcion.Clear();
            txbPrecioCompra.Clear();
            txbPrecioVenta.Clear();
            txbNombre.Clear();
            txbPresentacion.Clear();
            txbDescripcion.IsEnabled = habilitadas;
            txbPrecioCompra.IsEnabled = habilitadas;
            txbPrecioVenta.IsEnabled = habilitadas;
            txbNombre.IsEnabled = habilitadas;
            txbPresentacion.IsEnabled = habilitadas;
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
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbPrecioCompra.Text) || string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbPresentacion.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Producto p = new Producto()
                {
                    Descripcion = txbDescripcion.Text,
                    PrecioCompra = txbPrecioCompra.Text,
                    PrecioVenta = txbPrecioVenta.Text,
                    Nombre = txbNombre.Text,
                    Presentacion = txbPresentacion.Text
                };
                if (repositorio.AgregarProducto(p))
                {
                    MessageBox.Show("Guardado con Éxito", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Producto original = dtgProductos.SelectedItem as Producto;
                Producto p = new  Producto();
                p.Descripcion = txbDescripcion.Text;
                p.PrecioCompra = txbPrecioCompra.Text;
                p.PrecioVenta = txbPrecioVenta.Text;
                p.Nombre = txbNombre.Text;
                p.Presentacion = txbPresentacion.Text;
                if (repositorio.ModificarProducto(original, p))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("El producto ha sido actualizado", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = repositorio.LeerProductos();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("No hay productos", "No existen productos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProductos.SelectedItem != null)
                {
                    Producto p = dtgProductos.SelectedItem as Producto;
                    if (MessageBox.Show("Realmente deseas eliminar " + p.Nombre + "?", "Eliminar?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarProducto(p))
                        {
                            MessageBox.Show("El producto ha sido eliminado", "Poductos", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿Cual?", "Poducto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("No hay productos", "No existen poductos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProductos.SelectedItem != null)
                {
                    Producto p = dtgProductos.SelectedItem as Producto;
                    HabilitarCajas(true);
                    txbDescripcion.Text = p.Descripcion;
                    txbPrecioCompra.Text = p.PrecioCompra;
                    txbPrecioVenta.Text = p.PrecioVenta;
                    txbNombre.Text = p.Nombre;
                    txbPresentacion.Text = p.Presentacion;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Cual?", "Producto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}

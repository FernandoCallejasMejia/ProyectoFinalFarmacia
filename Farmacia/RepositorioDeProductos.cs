using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class RepositorioDeProductos
    {
        ManejadorDeArchivos archivoProductos;
        List<Producto> Productos;
        public RepositorioDeProductos()
        {
            archivoProductos = new ManejadorDeArchivos("Productos.txt");
            Productos = new List<Producto>();
        }

        public bool AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
            bool resultado = ActualizarArchivo();
            Productos = LeerProductos();
            return resultado;
        }

        public bool EliminarProducto(Producto producto)
        {
            Producto temporal = new Producto();
            foreach (var item in Productos)
            {
                if (item.Nombre == producto.Nombre)
                {
                    temporal = item;
                }
            }
            Productos.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Productos = LeerProductos();
            return resultado;
        }

        public bool ModificarProducto(Producto original, Producto modificado)
        {
            Producto temporal = new Producto();
            foreach (var item in Productos)
            {
                if (original.Nombre == item.Nombre)
                {
                    temporal = item;
                }
            }
            temporal.Nombre = modificado.Nombre;
            temporal.Descripcion = modificado.Descripcion;
            temporal.PrecioCompra = modificado.PrecioCompra;
            temporal.PrecioVenta = modificado.PrecioVenta;
            temporal.Presentacion = modificado.Presentacion;
            bool resultado = ActualizarArchivo();
            Productos = LeerProductos();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Producto item in Productos)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.Nombre, item.Descripcion, item.PrecioCompra, item.PrecioVenta, item.Presentacion);
            }
            return archivoProductos.Guardar(datos);
        }
        public List<Producto> LeerProductos()
        {
            string datos = archivoProductos.Leer();
            if (datos != null)
            {
                List<Producto> productos = new List<Producto>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Producto p = new Producto()
                    {
                        Nombre = campos[0],
                        Descripcion = campos[1],
                        PrecioCompra = campos[2],
                        PrecioVenta = campos[3],
                        Presentacion = campos[4]
                    };
                    productos.Add(p);
                }
                Productos = productos;
                return productos;
            }
            else
            {
                return null;
            }
        }
        //    ManejadorDeArchivos archivoProductos;
        //    List<Producto> Productos;
        //    public RepositorioDeProductos()
        //    {
        //        archivoProductos = new ManejadorDeArchivos("Productos.txt");
        //        Productos = new List<Producto>();
        //    }

        //    public bool AgregarProducto(Producto producto)
        //    {
        //        Productos.Add(producto);
        //        bool resultado = ActualizarArchivo();
        //        Productos = LeerProductos();
        //        return resultado;
        //    }

        //    public bool EliminarProducto(Producto producto)
        //    {
        //        Producto temporal = new Producto();
        //        foreach (var item in Productos)
        //        {
        //            if (item.Nombre == producto.Nombre)
        //            {
        //                temporal = item;
        //            }
        //        }
        //        Productos.Remove(temporal);
        //        bool resultado = ActualizarArchivo();
        //        Productos = LeerProductos();
        //        return resultado;
        //    }

        //    public bool ModificarProducto(Producto original, Producto modificado)
        //    {
        //        Producto temporal = new Producto();
        //        foreach (var item in Productos)
        //        {
        //            if (original.Nombre == item.Nombre)
        //            {
        //                temporal = item;
        //            }
        //        }
        //        temporal.Nombre = modificado.Nombre;
        //        temporal.Descripcion = modificado.Descripcion;
        //        temporal.PrecioCompra = modificado.PrecioCompra;
        //        temporal.PrecioVenta = modificado.PrecioVenta;
        //        temporal.Presentacion = modificado.Presentacion;
        //        bool resultado = ActualizarArchivo();
        //        Productos = LeerProductos();
        //        return resultado;
        //    }

        //    private bool ActualizarArchivo()
        //    {
        //        string datos = "";
        //        foreach (Producto item in Productos)
        //        {
        //            datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.Nombre, item.Descripcion, item.PrecioCompra, item.PrecioVenta, item.Presentacion);
        //        }
        //        return archivoProductos.Guardar(datos);
        //    }
        //    public List<Producto> LeerProductos()
        //    {
        //        string datos = archivoProductos.Leer();
        //        if (datos != null)
        //        {
        //            List<Producto> productos = new List<Producto>();
        //            string[] lineas = datos.Split('\n');
        //            for (int i = 0; i < lineas.Length - 1; i++)
        //            {
        //                string[] campos = lineas[i].Split('|');
        //                Producto p = new Producto()
        //                {
        //                    Nombre = campos[0],
        //                    Descripcion = campos[1],
        //                    PrecioCompra = campos[2],
        //                    PrecioVenta = campos[3],
        //                    Presentacion = campos[4]
        //                };
        //                Productos.Add(p);
        //            }
        //            Productos = productos;
        //            return productos;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
    }
}
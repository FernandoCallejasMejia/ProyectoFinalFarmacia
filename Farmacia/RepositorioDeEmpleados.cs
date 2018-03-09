using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class RepositorioDeEmpleados
    {
        ManejadorDeArchivos archivoEmpleados;
        List<Empleado> Empleados;
        public RepositorioDeEmpleados()
        {
            archivoEmpleados = new ManejadorDeArchivos("Empleados.txt");
            Empleados = new List<Empleado>();
        }
        public bool AgregarEmpleado(Empleado empleado)
        {
            Empleados.Add(empleado);
            bool resultado = ActualizarArchivo();
            Empleados = LeerEmpleados();
            return resultado;
        }
        public bool EliminarEmpleado(Empleado empleado)
        {
            Empleado temporal = new Empleado();
            foreach (var item in Empleados)
            {
                if (item.Nombre == empleado.Nombre)
                {
                    temporal = item;
                }
            }
            Empleados.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Empleados = LeerEmpleados();
            return resultado;
        }
        public bool ModificarEmpleado(Empleado original, Empleado modificado)
        {
            Empleado temporal = new Empleado();
            foreach (var item in Empleados)
            {
                if (original.Nombre == item.Nombre)
                {
                    temporal = item;
                }
            }
            temporal.Nombre = modificado.Nombre;
            bool resultado = ActualizarArchivo();
            Empleados = LeerEmpleados();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Empleado item in Empleados)
            {
                datos += string.Format("{0}\n", item.Nombre);
            }
            return archivoEmpleados.Guardar(datos);
        }
        public List<Empleado> LeerEmpleados()
        {
            string datos = archivoEmpleados.Leer();
            if (datos != null)
            {
                List<Empleado> empleados = new List<Empleado>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('\n');
                    Empleado e = new Empleado()
                    {
                        Nombre = campos[0],
                    };
                    empleados.Add(e);
                }
                Empleados = empleados;
                return empleados;
            }
            else
            {
                return null;
            }
        }
    }
}

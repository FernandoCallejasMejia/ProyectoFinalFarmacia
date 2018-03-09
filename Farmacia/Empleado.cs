using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public override string ToString()
        {
            return string.Format("{0}",Nombre);
        }
    }
}

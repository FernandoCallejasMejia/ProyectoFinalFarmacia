using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class Venta
    {
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float CalcularTotal()
        {
            float total;
            return total = Cantidad * Precio;
        }
    }
}

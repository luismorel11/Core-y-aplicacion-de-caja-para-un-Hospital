using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
  

    public class Habitaciones
    {
        public int IdHabitaciones { get; set; }
        public string DescripcionHabitacion { get; set; }
        public string DescripcionCamas { get; set; }
        public bool Activo { get; set; }
        public List<Procedimiento> oListaProcedimiento { get; set; }
    }
}

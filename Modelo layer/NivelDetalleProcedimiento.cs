using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    

    public class NivelDetalleProcedimiento
    {
        public int IdNivelDetalleProcedimiento { get; set; }
        public AreaDetalle oAreaDetalle { get; set; }
        public Area oArea { get; set; }
        public Habitaciones oHabitaciones { get; set; }
        public Procedimiento oProcedimiento{ get; set; }
    }
}



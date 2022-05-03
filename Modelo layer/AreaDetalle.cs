using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
   

    public class AreaDetalle
    {
        public int IdAreaDetalle { get; set; }
        public Area oArea { get; set; }
        public Habitaciones oHabitaciones { get; set; }
        public int TotalVacantes { get; set; }
        public int VacantesDisponibles { get; set; }
        public int VacantesOcupadas { get; set; }
        public bool Activo { get; set; }
    }
}



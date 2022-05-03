using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Area
    {
        public int IdArea { get; set; }
        public Periodo oPeriodo { get; set; }
        public string DescripcionArea { get; set; }
        public string DescripcionHorario { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool Activo { get; set; }
        public List<Habitaciones> oListaHabitaciones { get; set; }
    }
}



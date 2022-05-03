using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Curricula
    {
        public int IdCurricula { get; set; }
        public int IdDoctoresNivelDetalleProcedimiento { get; set; }
        public string Descripcion { get; set; }
        public DoctorProcedimiento oDoctorProcedimiento { get; set; }
    }
}




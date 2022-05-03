using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{

    public class DoctorProcedimiento
    {
        public int IdDoctorProcedimiento { get; set; }
        public NivelDetalleProcedimiento oNivelDetalleProcedimiento { get; set; }
        public Doctor oDoctor { get; set; }
        public bool Activo { get; set; }
    }
}



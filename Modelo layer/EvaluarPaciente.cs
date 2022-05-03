using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class EvaluarPaciente
    {

        public int IdEvaluarPaciente { get; set; }
        public Curricula oCurricula { get; set; }
        public Paciente oPaciente { get; set; }
        public string Analiticas { get; set; }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{

    public class Procedimiento
    {
        public int IdProcedimiento { get; set; }
        public string Descripcion { get; set; }

        public float Costo { get; set; }

        public bool Activo { get; set; }

    }
}


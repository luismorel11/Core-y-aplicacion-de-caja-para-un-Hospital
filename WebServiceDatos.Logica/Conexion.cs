using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceDatos.Logica
{
    public class Conexion
    {
        public string getconexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }

    
}

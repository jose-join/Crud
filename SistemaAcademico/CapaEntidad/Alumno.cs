using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Alumno
    {
        public string CodigoAlumno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string CodigoEscuela { get; set; }
    }
}

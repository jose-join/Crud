using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    class Asignatura
    {
        //Transformar los campos de la tabla Asignatura en  clase
        public string CodAsignatura
        { get; set; }
        public string _Asignatura
        { get; set; }
        public string CodRequisito
        { get; set; }
    }
}

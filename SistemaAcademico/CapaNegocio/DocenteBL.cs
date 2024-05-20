using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class DocenteBL
    {
        private DocenteDAL docenteDAL = new DocenteDAL();

        public void RegistrarDocente(Docente docente, string contrasena)
        {
            docenteDAL.InsertarDocente(docente, contrasena);
        }

        public List<Docente> ObtenerDocentes()
        {
            return docenteDAL.ObtenerDocentes();
        }

        public Docente ObtenerDocentePorCodigo(string codigoDocente)
        {
            return docenteDAL.ObtenerDocentePorCodigo(codigoDocente);
        }

        public void ActualizarDocente(Docente docente)
        {
            docenteDAL.ActualizarDocente(docente);
        }

        public void EliminarDocente(string codigoDocente)
        {
            docenteDAL.EliminarDocente(codigoDocente);
        }
    }
}

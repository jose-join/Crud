using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class DocenteDAL
    {
        private DatosSQL datos = new DatosSQL();

        public void InsertarDocente(Docente docente, string contrasena)
        {
            datos.Ejecutar("spAgregarDocente", docente.CodigoDocente, docente.ApellidoPaterno, docente.ApellidoMaterno, docente.Nombres, docente.Correo, contrasena);
        }

        public List<Docente> ObtenerDocentes()
        {
            List<Docente> docentes = new List<Docente>();
            DataTable dt = datos.TraerDataTable("spListarDocentes");

            foreach (DataRow row in dt.Rows)
            {
                Docente docente = new Docente
                {
                    CodigoDocente = row["CodDocente"].ToString(),
                    ApellidoPaterno = row["APaterno"].ToString(),
                    ApellidoMaterno = row["AMaterno"].ToString(),
                    Nombres = row["Nombres"].ToString(),
                    Correo = row["CodUsuario"].ToString()
                };
                docentes.Add(docente);
            }

            return docentes;
        }

        public Docente ObtenerDocentePorCodigo(string codigoDocente)
        {
            Docente docente = null;
            DataTable dt = datos.TraerDataTable("spObtenerDocentePorCodigo", codigoDocente);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                docente = new Docente
                {
                    CodigoDocente = row["CodDocente"].ToString(),
                    ApellidoPaterno = row["APaterno"].ToString(),
                    ApellidoMaterno = row["AMaterno"].ToString(),
                    Nombres = row["Nombres"].ToString(),
                    Correo = row["CodUsuario"].ToString()
                };
            }

            return docente;
        }

        public void ActualizarDocente(Docente docente)
        {
            datos.Ejecutar("spActualizarDocente", docente.CodigoDocente, docente.ApellidoPaterno, docente.ApellidoMaterno, docente.Nombres, docente.Correo);
        }

        public void EliminarDocente(string codigoDocente)
        {
            datos.Ejecutar("spEliminarDocente", codigoDocente);
        }
    }
}

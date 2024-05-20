using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidad;


namespace CapaDatos
{
    public class AlumnoDAL
    {
        private DatosSQL datos = new DatosSQL();

        public void InsertarAlumno(Alumno alumno, string contrasena)
        {
            datos.Ejecutar("spAgregarAlumno", alumno.CodigoAlumno, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Nombres, alumno.Correo, contrasena, alumno.CodigoEscuela);
        }

        public List<Alumno> ObtenerAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            DataTable dt = datos.TraerDataTable("spListarAlumno");

            foreach (DataRow row in dt.Rows)
            {
                Alumno alumno = new Alumno
                {
                    CodigoAlumno = row["CodAlumno"].ToString(),
                    ApellidoPaterno = row["APaterno"].ToString(),
                    ApellidoMaterno = row["AMaterno"].ToString(),
                    Nombres = row["Nombres"].ToString(),
                    Correo = row["CodUsuario"].ToString(),
                    CodigoEscuela = row["CodEscuela"].ToString()
                };
                alumnos.Add(alumno);
            }

            return alumnos;
        }

        public Alumno ObtenerAlumnoPorCodigo(string codigoAlumno)
        {
            Alumno alumno = null;
            DataTable dt = datos.TraerDataTable("spObtenerAlumnoPorCodigo", codigoAlumno);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                alumno = new Alumno
                {
                    CodigoAlumno = row["CodAlumno"].ToString(),
                    ApellidoPaterno = row["APaterno"].ToString(),
                    ApellidoMaterno = row["AMaterno"].ToString(),
                    Nombres = row["Nombres"].ToString(),
                    Correo = row["CodUsuario"].ToString(),
                    CodigoEscuela = row["CodEscuela"].ToString()
                };
            }

            return alumno;
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            datos.Ejecutar("spActualizarAlumno", alumno.CodigoAlumno, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Nombres, alumno.Correo, alumno.CodigoEscuela);
        }

        public void EliminarAlumno(string codigoAlumno)
        {
            datos.Ejecutar("spEliminarAlumno", codigoAlumno);
        }
    }
}

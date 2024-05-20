using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class AlumnoBL
    {
        private AlumnoDAL alumnoDAL = new AlumnoDAL();

        public void RegistrarAlumno(Alumno alumno, string contrasena)
        {
            alumnoDAL.InsertarAlumno(alumno, contrasena);
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return alumnoDAL.ObtenerAlumnos();
        }

        public Alumno ObtenerAlumnoPorCodigo(string codigoAlumno)
        {
            return alumnoDAL.ObtenerAlumnoPorCodigo(codigoAlumno);
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            alumnoDAL.ActualizarAlumno(alumno);
        }

        public void EliminarAlumno(string codigoAlumno)
        {
            alumnoDAL.EliminarAlumno(codigoAlumno);
        }
    }
}

using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacionW
{
    public partial class Alumno1 : System.Web.UI.Page
    {
        private AlumnoBL alumnoBL = new AlumnoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAlumnos();
            }

        }
        private void CargarAlumnos()
        {
            List<Alumno> alumnos = alumnoBL.ObtenerAlumnos();
            gvAlumnos.DataSource = alumnos;
            gvAlumnos.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }

            Alumno alumno = new Alumno
            {
                CodigoAlumno = txtCodigoAlumno.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                ApellidoMaterno = txtApellidoMaterno.Text,
                Nombres = txtNombres.Text,
                Correo = txtCorreo.Text,
                CodigoEscuela = txtCodigoEscuela.Text
            };

            try
            {
                alumnoBL.RegistrarAlumno(alumno, txtContrasena.Text);
                lblMensaje.Text = "Registro exitoso";
                CargarAlumnos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                alumnoBL.EliminarAlumno(txtCodigoAlumno.Text);
                lblMensaje.Text = "Eliminación exitosa";
                CargarAlumnos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }

        }
        
      protected void btnActualizar_Click1(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno
            {
                CodigoAlumno = txtCodigoAlumno.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                ApellidoMaterno = txtApellidoMaterno.Text,
                Nombres = txtNombres.Text,
                Correo = txtCorreo.Text,
                CodigoEscuela = txtCodigoEscuela.Text
            };

            try
            {
                alumnoBL.ActualizarAlumno(alumno);
                lblMensaje.Text = "Actualización exitosa";
                CargarAlumnos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            Alumno alumno = alumnoBL.ObtenerAlumnoPorCodigo(txtCodigoAlumno.Text);
            if (alumno != null)
            {
                List<Alumno> alumnos = new List<Alumno> { alumno };
                gvAlumnos.DataSource = alumnos;
                gvAlumnos.DataBind();
                lblMensaje.Text = "Alumno encontrado.";
            }
            else
            {
                gvAlumnos.DataSource = null;
                gvAlumnos.DataBind();
                lblMensaje.Text = "Alumno no encontrado.";
            }
        }

       

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string codigoAlumno = e.CommandArgument.ToString();
                Alumno alumno = alumnoBL.ObtenerAlumnoPorCodigo(codigoAlumno);
                if (alumno != null)
                {
                    txtCodigoAlumno.Text = alumno.CodigoAlumno;
                    txtApellidoPaterno.Text = alumno.ApellidoPaterno;
                    txtApellidoMaterno.Text = alumno.ApellidoMaterno;
                    txtNombres.Text = alumno.Nombres;
                    txtCorreo.Text = alumno.Correo;
                    txtCodigoEscuela.Text = alumno.CodigoEscuela;
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                string codigoAlumno = e.CommandArgument.ToString();
                alumnoBL.EliminarAlumno(codigoAlumno);
                CargarAlumnos();
            }
        }
        private void LimpiarCampos()
        {
            txtCodigoAlumno.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtNombres.Text = "";
            txtCorreo.Text = "";
            txtCodigoEscuela.Text = "";
            txtContrasena.Text = "";
            txtConfirmarContrasena.Text = "";
        }

    }
}
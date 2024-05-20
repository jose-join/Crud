using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{

    public partial class frmAlumno : System.Web.UI.Page
    {

        private void Listar()
        {
            AlumnoBL alumnoBL = new AlumnoBL();
            gvAlumno.DataSource = alumnoBL.Listar();
            gvAlumno.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtAPaterno.Text.Trim();
            alumno.AMaterno = txtAMaterno.Text.Trim();
            alumno.Nombres = txtNombres.Text.Trim();
            alumno.CodUsuario = txtCodUsuario.Text.Trim();
            alumno.Contrasena = txtContrasena.Text.Trim();
            alumno.CodEscuela = txtCodEscuela.Text.Trim();
            AlumnoBL alumnoBL = new AlumnoBL();
            if (alumnoBL.Agregar(alumno))
                Listar();
            lblMensaje.Text = alumnoBL.Mensaje;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            AlumnoBL alumnoBL = new AlumnoBL();
            if (alumnoBL.Eliminar(codAlumno))
                Listar();
            lblMensaje.Text = alumnoBL.Mensaje;
        }
    }
}
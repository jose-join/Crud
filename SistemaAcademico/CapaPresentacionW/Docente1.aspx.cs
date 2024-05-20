using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace CapaPresentacionW
{
    public partial class Docente1 : System.Web.UI.Page
    {
        private DocenteBL docenteBL = new DocenteBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDocentes();
            }

        }
        private void CargarDocentes()
        {
            List<Docente> docentes = docenteBL.ObtenerDocentes();
            gvDocentes.DataSource = docentes;
            gvDocentes.DataBind();
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }

            Docente docente = new Docente
            {
                CodigoDocente = txtCodigoDocente.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                ApellidoMaterno = txtApellidoMaterno.Text,
                Nombres = txtNombres.Text,
                Correo = txtCorreo.Text
            };

            try
            {
                docenteBL.RegistrarDocente(docente, txtContrasena.Text);
                lblMensaje.Text = "Registro exitoso";
                CargarDocentes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Docente docente = docenteBL.ObtenerDocentePorCodigo(txtCodigoDocente.Text);
            if (docente != null)
            {
                List<Docente> docentes = new List<Docente> { docente };
                gvDocentes.DataSource = docentes;
                gvDocentes.DataBind();
                lblMensaje.Text = "Docente encontrado.";
            }
            else
            {
                gvDocentes.DataSource = null;
                gvDocentes.DataBind();
                lblMensaje.Text = "Docente no encontrado.";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Docente docente = new Docente
            {
                CodigoDocente = txtCodigoDocente.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                ApellidoMaterno = txtApellidoMaterno.Text,
                Nombres = txtNombres.Text,
                Correo = txtCorreo.Text
            };

            try
            {
                docenteBL.ActualizarDocente(docente);
                lblMensaje.Text = "Actualización exitosa";
                CargarDocentes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
        protected void gvDocentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string codigoDocente = e.CommandArgument.ToString();
                Docente docente = docenteBL.ObtenerDocentePorCodigo(codigoDocente);
                if (docente != null)
                {
                    txtCodigoDocente.Text = docente.CodigoDocente;
                    txtApellidoPaterno.Text = docente.ApellidoPaterno;
                    txtApellidoMaterno.Text = docente.ApellidoMaterno;
                    txtNombres.Text = docente.Nombres;
                    txtCorreo.Text = docente.Correo;
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                string codigoDocente = e.CommandArgument.ToString();
                docenteBL.EliminarDocente(codigoDocente);
                CargarDocentes();
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoDocente.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtNombres.Text = "";
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            txtConfirmarContrasena.Text = "";
        }

    }
}
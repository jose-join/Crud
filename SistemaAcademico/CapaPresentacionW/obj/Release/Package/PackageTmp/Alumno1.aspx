<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno1.aspx.cs" Inherits="CapaPresentacionW.Alumno1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registro de Alumno</h2>
            <asp:Label ID="lblCodigoAlumno" runat="server" Text="Código Alumno:"></asp:Label>
            <asp:TextBox ID="txtCodigoAlumno" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblApellidoPaterno" runat="server" Text="Apellido Paterno:"></asp:Label>
            <asp:TextBox ID="txtApellidoPaterno" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblApellidoMaterno" runat="server" Text="Apellido Materno:"></asp:Label>
            <asp:TextBox ID="txtApellidoMaterno" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblNombres" runat="server" Text="Nombres:"></asp:Label>
            <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblCodigoEscuela" runat="server" Text="Código Escuela:"></asp:Label>
            <asp:TextBox ID="txtCodigoEscuela" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Label ID="lblConfirmarContrasena" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="txtConfirmarContrasena" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" /><br /><br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click1" /><br /><br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click1" /><br /><br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br /><br />
            <h2>Lista de Alumnos</h2>
            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAlumnos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CodigoAlumno" HeaderText="Código Alumno" />
                    <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                    <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="CodigoEscuela" HeaderText="Código Escuela" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("CodigoAlumno") %>' CommandName="Editar" />
                            <asp:Button ID="btnEliminarGrid" runat="server" Text="Eliminar" CommandArgument='<%# Eval("CodigoAlumno") %>' CommandName="Eliminar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

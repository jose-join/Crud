<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Docente1.aspx.cs" Inherits="CapaPresentacionW.Docente1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <h2>Registro de Docente</h2>
            <asp:Label ID="lblCodigoDocente" runat="server" Text="Código Docente:"></asp:Label>
            <asp:TextBox ID="txtCodigoDocente" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblApellidoPaterno" runat="server" Text="Apellido Paterno:"></asp:Label>
            <asp:TextBox ID="txtApellidoPaterno" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblApellidoMaterno" runat="server" Text="Apellido Materno:"></asp:Label>
            <asp:TextBox ID="txtApellidoMaterno" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblNombres" runat="server" Text="Nombres:"></asp:Label>
            <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Label ID="lblConfirmarContrasena" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="txtConfirmarContrasena" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" /><br /><br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" /><br /><br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" /><br /><br />
            
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br /><br />
            <h2>Lista de Docentes</h2>
            <asp:GridView ID="gvDocentes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDocentes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CodigoDocente" HeaderText="Código Docente" />
                    <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                    <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("CodigoDocente") %>' CommandName="Editar" />
                            <asp:Button ID="btnEliminarGrid" runat="server" Text="Eliminar" CommandArgument='<%# Eval("CodigoDocente") %>' CommandName="Eliminar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDestinatarios.aspx.cs" Inherits="RegistroCartasWeb.Registros.rDestinatarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="color: #0094ff">Registro de Destinatarios</h2>
    <div class="form-row">
        <%--DestinatarioID--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Destinatario Id" class="text-primary" runat="server" />
            <asp:TextBox ID="DestinatarioIDTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="DestinatarioIDTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="DestinatarioIDTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <%--Fecha--%>
    <div class="form-group col-md-3">
        <asp:Label Text="Fecha" runat="server" />
        <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
    </div>
    <%--Nombres--%>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Nombres"></asp:Label>
                <asp:TextBox class="form-control" ID="NombresTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>


    <%--Boton--%>
    <div class="col-sm-1 col-md-4 col-xs6">
        <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-6" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                     Buscar
        </asp:LinkButton>
    </div>
    <%--Cantidad de Cartas Enviadas--%>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Cantidad de Cartas"></asp:Label>
                <asp:TextBox class="form-control" ID="CartasEnviadasTextBox" type="number" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-1 col-md-5">
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-primary btn-sm" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCartas.aspx.cs" Inherits="RegistroCartasWeb.rCartas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="color: #0094ff">Registro de Cartas</h2>
    <div class="form-row">
        <%--CartaID--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Carta Id" class="text-primary" runat="server" />
            <asp:TextBox ID="CartaIDTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CartaIDTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CartaIDTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <%--Fecha--%>
    <div class="form-group col-md-3">
        <asp:Label Text="Fecha" runat="server" />
        <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
    </div>


        <%--Boton--%>
        <div class="col-lg-1 p-0 ">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-6" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                     Buscar
            </asp:LinkButton>
        </div>


    <%--Destinatariod--%>
    <div class="form-group col-md-3">
        <asp:Label Text="Destinatario ID" class="text-primary" runat="server" />
        <asp:TextBox ID="DestinatarioIDTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
        <asp:RequiredFieldValidator ID="DestinartarioIdRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="DestinatarioIdTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="DestinatarioIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
    </div>

    <%--Cuerpo--%>
    <div class="form-group col-md-3">
        <asp:Label Text="Cuerpo" runat="server" />
        <asp:TextBox ID="CuerpoTextBox" class="form-control input-sm" placeholder="Mensaje" runat="server" />
        <asp:RequiredFieldValidator ID="CuerpoRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algo!" ControlToValidate="CuerpoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="CuerpoRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algo!" ControlToValidate="CuerpoTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>
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

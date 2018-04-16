<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Empresas Usuário" AutoEventWireup="true" CodeBehind="UserEnterprises.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.UserEnterprises" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <h2 id="formStatus" runat="server">Usuário Empresa</h2>
        <div class="form-group">
            <asp:Label ID="lblEmpresa" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList ID="DropDownEnterprises" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="DropDownUsers" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
         <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"/>
        </div>
    </div>
</asp:Content>

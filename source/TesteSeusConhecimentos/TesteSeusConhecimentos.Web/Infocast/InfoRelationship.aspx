<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoRelationship.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoRelationship" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <h2 id="formStatus" runat="server">Relacionamento</h2>
        <div class="form-group">
            <asp:Label ID="lblEmpresa" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control"  ID="EmpresaDropDownList"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblUsuário" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control"  ID="UsuarioDropDownList"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Relacionar" OnClick="btnSalvar_Click" Enabled="false" />
        </div>
    </div>
</asp:Content>

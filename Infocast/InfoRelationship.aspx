<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoRelationship.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoRelationship" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Novo Relacionamento</h2>
         <div class="form-group">
            <asp:Label ID="lbEmpresa" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList ID="ddlEmpresa" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lbUsuario" runat="server" Text="Label">Usuário:</asp:Label>
            <asp:DropDownList ID="ddlUsuario" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRelacionar" runat="server" Text="Relacionar" OnClick="btnRelacionar_Click" />
        </div>
    </div>
</asp:Content>

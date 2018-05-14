<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoRelacionamentos.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoRelacionamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Novo Relacionamento</h2>
         <div class="form-group">
            <asp:Label ID="lbEmpresa" runat="server" Text="Label">Empresa:</asp:Label>
            
             <asp:DropDownList runat="server" ID="ddlEmpresa" CssClass="form-control">                 
             </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lbUsuario" runat="server" Text="Label">Usuário:</asp:Label>
            
            <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="form-control">                
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Relacionar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>

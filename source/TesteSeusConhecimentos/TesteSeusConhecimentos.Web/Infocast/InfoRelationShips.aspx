<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoRelationships.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoRelationships" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <h2 id="formStatus" runat="server">Relacionamentos</h2>
        <div class="form-group">
            <asp:Label ID="lbStreetAdress" runat="server" Text="Label">Empresa:</asp:Label>
            <asp:DropDownList CssClass="form-control" ID="ddlEmpresa" runat="server">
                <asp:ListItem Text="empresa 1" />
                <asp:ListItem Text="empresa 2" />   
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Label">Usuarios:</asp:Label>
            <asp:DropDownList CssClass="form-control" ID="ddUser" runat="server">
                <asp:ListItem Text="usuario 1" />
                <asp:ListItem Text="usuario 2" />
            </asp:DropDownList>
        </div>
   
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Relacionar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>

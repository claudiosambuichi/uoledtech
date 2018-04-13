<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoRelation.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Inforelation.InfoRelation" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <h2 id="formStatus" runat="server">Novo Relacionamento</h2>
        <div class="form-group">
            <asp:Label ID="lbEnterpriseName" runat="server" Text="Label">Empresa:</asp:Label>
            
            <asp:DropDownList ID="ddlEnterpriseName" runat="server" CssClass="form-control">
                <asp:ListItem Text="Todos" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lbUserName" runat="server" Text="Label">Usuário:</asp:Label>

            <asp:DropDownList ID="ddlUserName" runat="server" CssClass="form-control" plac>
                <asp:ListItem Text="Todos" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>

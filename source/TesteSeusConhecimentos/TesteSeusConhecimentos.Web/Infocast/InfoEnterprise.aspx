<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoEnterprise.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoEnterprise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width"> 
        <h2 id="formStatus"  runat="server">Nova Empresa</h2>
         <div class="form-group">
            <asp:Label ID="lbNome" runat="server" Text="Label">Nome:</asp:Label>
            <asp:TextBox ID="txtNome" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbEndereco" runat="server" Text="Label">Endereço:</asp:Label>
            <asp:TextBox ID="txtEndereco" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbCidade" runat="server" Text="Label">Cidade:</asp:Label>
            <asp:TextBox ID="txtCidade" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
           <div class="form-group">
            <asp:Label ID="lbEstado" runat="server" Text="Label">Estado:</asp:Label>
            <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

           <div class="form-group">
            <asp:Label ID="lbCEP" runat="server" Text="Label">CEP:</asp:Label>
            <asp:TextBox ID="txtCEP" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

           <div class="form-group">
            <asp:Label ID="lbAtividade" runat="server" Text="Label">Atividade Corporativa:</asp:Label>
            <asp:TextBox ID="txtAtividade" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>

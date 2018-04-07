﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoEnterprise.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.InfoEnterprises" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="form-width">
        <h2 id="formStatus" runat="server">Nova Empresa</h2>
        <div class="form-group">
            <asp:Label ID="lblEndereco" runat="server" Text="Label">Endereço:</asp:Label>
            <asp:TextBox ID="txtStreetAdress" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCidade" runat="server" Text="Label">Cidade:</asp:Label>
            <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEstado" runat="server" Text="Label">Estado:</asp:Label>
            <asp:TextBox ID="txtState" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblZipCode" runat="server" Text="Label">CEP:</asp:Label>
            <asp:TextBox ID="txtZipCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAtividade" runat="server" Text="Label">Atividade:</asp:Label>
            <asp:TextBox ID="txtCorporateActivity" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>

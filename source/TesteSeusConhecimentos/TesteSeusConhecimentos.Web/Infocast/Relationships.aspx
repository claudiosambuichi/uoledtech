<%@ Page Title="Relacionamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relationships.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Relationships" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdRelationships" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdRelationships_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lblCodigo" Text='<%# Eval("IdRelationship")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nome Empresa">
                <ItemTemplate>
                    <asp:Label ID="lblNomeEmpresa" Text='<%# Eval("EnterpriseName")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                    <asp:Label ID="lblNomeUsuário" Text='<%# Eval("UserName")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Opções">
                <ItemTemplate>
                    <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdRelationship")%>' />
                    <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdRelationship")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>

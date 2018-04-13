<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relation.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Inforelation.Relation" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdRelation" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdRelations_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="tbCodigo" Text='<%# Eval("IdRelation")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbEnterpriseName" Text='<%# Eval("EnterpriseName")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                    <asp:Label ID="lbUserName" Text='<%# Eval("UserName")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Opções">
                <ItemTemplate>
                    <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdRelation")%>' />
                    <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdRelation")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>

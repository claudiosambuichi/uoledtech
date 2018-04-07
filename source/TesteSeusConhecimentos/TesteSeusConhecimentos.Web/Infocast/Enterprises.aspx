<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enterprises.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Enterprises" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdEnterprise" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdEnterprise_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="tbCodigo" Text='<%# Eval("IdEnterprise")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Endereco">
                <ItemTemplate>
                    <asp:Label ID="lblEndereco" Text='<%# Eval("StreetAdress")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cidade">
                <ItemTemplate>
                    <asp:Label ID="lblCidade" Text='<%# Eval("City")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" Text='<%#Eval("State") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CEP">
                <ItemTemplate>
                    <asp:Label ID="lblCep" Text='<%#Eval("ZipCode") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Atividade">
                <ItemTemplate>
                    <asp:Label ID="lblAtividadeEmpresa" Text='<%#Eval("CorporateActivity") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Opções">
                <ItemTemplate>
                    <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdEnterprise")%>' />
                    <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdEnterprise")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Nova empresa" OnClick="btnNovo_Click" />
</asp:Content>

<%@ Page Title="Empresas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enterprisies.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Enterprisies" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdEnterprisies" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdEnterprisies_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lblCodigo" Text='<%# Eval("IdEnterprise")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nome Empresa">
                <ItemTemplate>
                    <asp:Label ID="lblNome" Text='<%# Eval("Name")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Endereço">
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
            <asp:TemplateField HeaderText="Cep">
                <ItemTemplate>
                    <asp:Label ID="lblCep" Text='<%#Eval("ZipCode") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Atividade da Empresa">
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
    <asp:Button ID="btnNovo" runat="server" Text="Nova Empresa" OnClick="btnNovo_Click" />
</asp:Content>

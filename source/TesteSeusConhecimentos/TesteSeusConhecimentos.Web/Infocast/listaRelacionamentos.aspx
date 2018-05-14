<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listaRelacionamentos.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.listaRelacionamentos" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdRelacionamentos" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdRelacionamentos_RowCommand"
        >
        <Columns>
            <asp:TemplateField HeaderText="Cod Relacionamento">
                <ItemTemplate>
                    <asp:Label ID="lbCodRelacionamentos" Text='<%# Eval("IdRelacionamentos")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Cod Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbCodEmpresa" Text='<%# Eval("IdEnterprise")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbEmpresa" Text='<%# Eval("Empresa")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cod Usuário">
                <ItemTemplate>
                    <asp:Label ID="lbCodUsuario" Text='<%# Eval("IdUser")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                    <asp:Label ID="lbUsuario" Text='<%# Eval("Usuario")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
           
           <asp:TemplateField  HeaderText="Opções">
            <ItemTemplate>                
              <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdRelacionamentos")%>' />
              <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdRelacionamentos")%>' />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>

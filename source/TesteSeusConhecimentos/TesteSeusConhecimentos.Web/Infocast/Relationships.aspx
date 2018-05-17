<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relationships.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infocast.Relationships" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdRelationships" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover" OnRowCommand="grdRelationships_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Código do Relacionamento">
                <ItemTemplate>
                    <asp:Label ID="lbCode" Text='<%# Eval("IdRelationship")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <asp:Label ID="lbCompanyId" Text='<%# Eval("Company")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuário">
                <ItemTemplate>
                    <asp:Label ID="lbUserId" Text='<%# Eval("User")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
           <asp:TemplateField  HeaderText="Opções">
            <ItemTemplate>                
              <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdRelationship")%>' />
              <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdRelationship")%>' />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Novo Relacionamento" OnClick="btnNovo_Click" />
</asp:Content>
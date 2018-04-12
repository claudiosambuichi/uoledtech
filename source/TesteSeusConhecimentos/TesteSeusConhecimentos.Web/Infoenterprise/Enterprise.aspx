<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enterprise.aspx.cs" Inherits="TesteSeusConhecimentos.Web.Infoenterprise.Enterprise" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="grdEnterprise" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-hover"
        OnRowCommand="grdEnterprise_RowCommand"
        >
        <Columns>
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="tbCodigo" Text='<%# Eval("IdEnterprise")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <asp:Label ID="lbName" Text='<%# Eval("Name")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Endreço">
                <ItemTemplate>
                    <asp:Label ID="lbStreetAdress" Text='<%# Eval("StreetAdress")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cidade">
                <ItemTemplate>
                    <asp:Label ID="lbCity" Text='<%# Eval("City")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lbState" Text='<%#Eval("State") %>' runat="server" />
                </ItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField HeaderText="CEP">
                <ItemTemplate>
                    <asp:Label ID="lbZipCode" Text='<%#FormatZipCode(Eval("ZipCode").ToString())%>' runat="server" />
                </ItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField HeaderText="Atividade Corporativa">
                <ItemTemplate>
                    <asp:Label ID="lbCorporateActivity" Text='<%#Eval("CorporateActivity") %>' runat="server" />
                </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField  HeaderText="Opções">
            <ItemTemplate>                
              <asp:Button runat="server" ID="deleteButtom" Text="Excluir" CommandName="Remove" CommandArgument='<%#Eval("IdEnterprise")%>' />
              <asp:Button runat="server" ID="editButtom" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("IdEnterprise")%>' />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnNovo" runat="server" Text="Nova Empresa" OnClick="btnNovo_Click" />
</asp:Content>

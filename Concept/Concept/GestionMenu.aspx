<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionMenu.aspx.cs" Inherits="Concept.GestionMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="liens-principaux">
        <div class="row">
            <div class="col-1-de-3">
                <asp:Label ID="lbl_restaurant" runat="server" Text="Restaurant :"></asp:Label>
                <asp:DropDownList ID="ddl_restaurant" runat="server" DataSourceID="SqlDS_Resto" DataTextField="adresse" DataValueField="id_restaurant">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDS_Resto" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [adresse], [id_restaurant] FROM [tbl_restaurant]"></asp:SqlDataSource>
                <asp:Button ID="btn_enregistrer" runat="server" Text="Enregistrer" OnClick="btn_enregistrer_Click" />
                <asp:Button ID="btn_annuler" runat="server" Text="Annuler" OnClick="btn_annuler_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-1-de-3">
                <h1>Menu</h1>
                <asp:GridView ID="view_Menu" runat="server" CssClass="grid_view" ShowHeaderWhenEmpty="True" CellPadding="10" EmptyDataText="Ajouter des produits !" EnableModelValidation="False" Font-Size="Medium" HorizontalAlign="Center" AutoGenerateSelectButton="True">
                    <SelectedRowStyle BackColor="#3399FF" />
                </asp:GridView>
            </div>
            <div class="col-1-de-3">
                <h1>&nbsp</h1>
                <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" />
                <asp:Button ID="btn_retirer" runat="server" Text="Retirer" OnClick="btn_retirer_Click" />
            </div>
            <div class="col-1-de-3">
                <h1>Produits</h1>
                <asp:GridView ID="view_Produits" runat="server" CssClass="grid_view" ShowHeaderWhenEmpty="True" Font-Size="Medium" AutoGenerateSelectButton="True">
                    <SelectedRowStyle BackColor="#3399FF" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

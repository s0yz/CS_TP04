<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionMenu.aspx.cs" Inherits="Concept.GestionMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-1-de-3">
            <asp:Label ID="lbl_restaurant" runat="server" Text="Restaurant :"></asp:Label>
            <asp:DropDownList ID="ddl_restaurant" runat="server">
                <asp:ListItem>Lévis</asp:ListItem>
                <asp:ListItem>Québec</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btn_enregistrer" runat="server" Text="Enregistrer" OnClick="btn_enregistrer_Click" />
            <asp:Button ID="btn_annuler" runat="server" Text="Sauvegarder" OnClick="btn_annuler_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-1-de-3">
            <asp:GridView ID="view_Menu" runat="server" CssClass="grid_view" ShowHeaderWhenEmpty="True"></asp:GridView>
        </div>
        <div class="col-1-de-3">
            <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" />
            <asp:Button ID="btn_retirer" runat="server" Text="Retirer" OnClick="btn_retirer_Click" />
        </div>
        <div class="col-1-de-3">
            <asp:GridView ID="view_Produits" runat="server" CssClass="grid_view" ShowHeaderWhenEmpty="True"></asp:GridView>
        </div>
    </div>
</asp:Content>

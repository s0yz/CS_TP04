<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionMenu.aspx.cs" Inherits="Concept.GestionMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-1-de-3">
            <asp:Label ID="lbl_restaurant" runat="server" Text="Restaurant :"></asp:Label>
            <asp:DropDownList ID="ddl_restaurant" runat="server">
                <asp:ListItem>Lévis</asp:ListItem>
                <asp:ListItem>Québec</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btn_enregistrer" runat="server" Text="Enregistrer" />
            <asp:Button ID="btn_annuler" runat="server" Text="Sauvegarder" />
        </div>
    </div>
    <div class="row">
        <div class="col-1-de-3">
            <asp:GridView ID="Menu" runat="server"></asp:GridView>
        </div>
        <div class="col-1-de-3">
            <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" />
            <asp:Button ID="btn_retirer" runat="server" Text="Retirer" />
        </div>
        <div class="col-1-de-3">
            <asp:GridView ID="Produits" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>

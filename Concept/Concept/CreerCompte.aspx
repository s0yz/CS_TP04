<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreerCompte.aspx.cs" Inherits="Concept.CreerCompte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="monCss.css">
    <div class="conteneur">
        <h1 class="titre" >Créer un compte</h1>
        <br />
        <br />
        <div class="block" >
              <asp:Label  Text="Nom :" runat="server"  CssClass="label" />
              <asp:Label  Text="Mot de passe :" runat="server" cssclass="label" />
              <asp:Label  Text="Confirmer mot de passe :" runat="server" cssclass="label" />
              <asp:Label  Text="Type d'utilisateur :" runat="server" cssclass="label" />
              <asp:Label  Text="Email :" runat="server" cssclass="label" />
              <asp:Label  Text="Adresse" CssClass="label" runat="server" />
            <asp:Label    Text="Restaurant" cssClass="label" runat="server" />
        </div>

        <div class="block" > 
            <asp:TextBox id="tb_nom" runat="server" CssClass="text-box" />
            <asp:TextBox id="tb_motDePasse" runat="server" CssClass="text-box"  />
            <asp:TextBox id="tb_verifPasse" runat="server" CssClass="text-box"  />
            <asp:DropDownList ID="ddl_typeUtilisateur" runat="server" CssClass="text-box" DataSourceID="SqlDataTypeUtilisateur" DataTextField="desc_type" DataValueField="id_type">
            </asp:DropDownList>
            <asp:TextBox id="tb_email" runat="server" CssClass="text-box"  />
            <asp:TextBox id="tb_adresse" CssClass="text-box" runat="server" />
            <asp:DropDownList runat="server" ID="ddl_Restaurant" CssClass="text-box" DataSourceID="SqlDataRestaurant" DataTextField="id_restaurant" DataValueField="id_restaurant">
            </asp:DropDownList>
        </div>
        <div class="conteneur_btn">
           
            <asp:Button Text="Accepter" runat="server" CssClass="btn" OnClick="click_accepte" />
            <asp:Button Text="Annuler" runat="server" CssClass="btn" />
             <asp:SqlDataSource ID="SqlDataRestaurant" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_restaurant] FROM [tbl_restaurant] ORDER BY [id_restaurant]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataTypeUtilisateur" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [desc_type], [id_type] FROM [tbl_type_utilisateur] ORDER BY [id_type]"></asp:SqlDataSource>
        </div>
      
        




    </div>

</asp:Content>

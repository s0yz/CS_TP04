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
        </div>

        <div class="block" > 
            <asp:TextBox id="tb_nom" runat="server" CssClass="text-box" />
            <asp:TextBox id="tb_motDePasse" runat="server" CssClass="text-box"  />
            <asp:TextBox id="tb_verifPasse" runat="server" CssClass="text-box"  />
            <asp:DropDownList ID="ddl_typeUtilisateur" runat="server" CssClass="text-box" DataSourceID="SqlDataSource1" DataTextField="desc_type" DataValueField="id_type">
            </asp:DropDownList>
            <asp:TextBox id="tb_email" runat="server" CssClass="text-box"  />
        </div>
        <div class="conteneur_btn">
            <asp:Button Text="Accepter" runat="server" CssClass="btn" OnClick="click_accepte" />
            <asp:Button Text="Annuler" runat="server" CssClass="btn" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [desc_type], [id_type] FROM [tbl_type_utilisateur] ORDER BY [id_type]"></asp:SqlDataSource>
        </div>
      
        




    </div>

</asp:Content>

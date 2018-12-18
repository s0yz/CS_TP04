<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreerRestaurant.aspx.cs" Inherits="Concept.CreerRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="monCss.css">
    <div class="conteneur">
        <h1 class="titre" >Créer un nouveau restaurant</h1>
        <br />
        <br />
        <div class="block" >
              <asp:Label  Text="Entrez l'adresse du nouveau restaurant :" runat="server"  CssClass="label" />
              <asp:Label  Text="Entrez le numéro de téléphone :" runat="server" cssclass="label" />
        </div>

        <div class="block" > 
            <asp:TextBox id="tb_adresse" runat="server" CssClass="text-box" />
            <asp:TextBox id="tb_telephone" runat="server" CssClass="text-box"  />
        </div>
        <div>
            <br/>
            <h3 style="font-size:1.7em">Aperçu image</h3>
            <br/>
            <asp:FileUpload id="FileDialog" runat="server" Width="300px" />
            <br />
            <br />
            <asp:Image id="im_Resto" runat="server" ImageAlign="Middle" ImageURL="../img/restodefaut.png" Height="200px" Width="250px"/>
            <br />
            <asp:Button Text="Téléverser" runat="server" OnClick="Upload" CssClass="btn" />
            <br />
            <br />
            <br />
            <br />
        </div>
        <div class="conteneur_btn">
            <asp:Button ID="btn_Finish" Text="Terminer" runat="server" OnClick="Finish" CssClass="btn" />
            <asp:Button ID="btn_Cancel" Text="Annuler" runat="server" OnClick="Finish" CssClass="btn" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Commander.aspx.cs" Inherits="Concept.Commander" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server">    
    void increment(object sender, ImageClickEventArgs e) {
       
    }
</script>
    <section class="row menu-commande-container">
        <div class="col-1-de-4">
            <ul class="menu-list">
                 <li><asp:Button Text="Entrée" runat="server" CssClass="btn" OnClick="entre_click" /></li>
                 <li><asp:Button Text="Repas" runat="server" CssClass="btn"  OnClick="repas_click"/></li>
                 <li><asp:Button Text="Déssert" runat="server"  CssClass="btn" OnClick="dessert_click"/></li>
                 <li><asp:Button Text="Boisson" runat="server" CssClass="btn"  OnClick="boisson_click"/></li>
            </ul>
        </div>
        <div>
         <%=
           this.construireHtml()
             %>

    
         </div>
</section>
</asp:Content>


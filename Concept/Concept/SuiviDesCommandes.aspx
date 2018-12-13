<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuiviDesCommandes.aspx.cs" Inherits="Concept.SuiviDesCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="monCss.css">
    <div >
        <section class="suivi-commandes-container">
         <h1 class="suivi-commandes-container__titre">Suivi des commandes</h1>
         <div>
                <%=
                    this.construireHtml()
                    %>
             <input type="type" name="name" value=""  />
    </div>
            </section>
    </div>
   
    
    </asp:Content>



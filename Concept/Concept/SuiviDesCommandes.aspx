<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuiviDesCommandes.aspx.cs" Inherits="Concept.SuiviDesCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="monCss.css">
    <div >
        <h1>Suivi des commandes</h1>
         <div>
      <%=   
          this.construireHtml()
              %>
        
    </div>
    </div>
   
    
    </asp:Content>



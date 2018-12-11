<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuiviDesCommandes.aspx.cs" Inherits="Concept.SuiviDesCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Suivi des commandes</h1>
    </div>
    <div>
      <%=   
          this.construireHtml()
              %>
        
    </div>
    
    </asp:Content>



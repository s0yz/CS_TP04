<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuiviDesCommandes.aspx.cs" Inherits="Concept.SuiviDesCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>   
        <%=
            this.construireHtml()
            %>
    </div>
</asp:Content>

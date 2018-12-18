<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authentification.aspx.cs" Inherits="Concept.Authentification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
        <div class="connexion-container">
            <h3 class="connexion-container__title">Connexion</h3>
           
                <asp:TextBox runat="server" id="tb_email" cssclass="connexion-form__text-input" />
                <asp:TextBox runat="server" id="tb_motDePasse" cssclass="connexion-form__text-input" />
                <a href="#" class="connexion-form__mpoublie">Mot de passe oublié?</a>
                
                <div class="btn-container">
                    <asp:Button Text="Se connecter"  OnClick="connection_click" runat="server" CssClass="btn" />
                    <asp:Button Text="Se créer un compte"  OnClick="création_click" runat="server" CssClass="btn" />
                </div>
            </form>
        </div>
    </div>
        </div>
    </form>
</body>
</html>

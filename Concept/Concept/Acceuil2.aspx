<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acceuil2.aspx.cs" Inherits="Concept.Acceuil2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="liens-principaux">
      <div class="row">
        <div class="col-1-de-3">
          <div class="link-container">
            <h3 class="link-container__title"><a href="#" class="title__link">Découvrez nos menus</a></h3>
            <a href="#" class="link-container__link link-container--menu"></a>
          </div>
        </div>
        <div class="col-1-de-3">
          <div class="link-container">
            <h3 class="link-container__title"><a href="#" class="title__link">Découvrez nos restaurants</h3>
            <a href="#" class="link-container__link link-container--restaurant"></a>
          </div>        
        </div>
        <div class="col-1-de-3">
          <div class="link-container">
            <h3 class="link-container__title"><a href="#" class="title__link">Découvrez nos promotions</h3>
            <a href="#" class="link-container__link link-container--promotion"></a>
          </div>        
        </div>
      </div>
    </section>
    <section class="carriere">
      <div class="row">
        <div class="carriere-container">
          <h3 class="carriere-container__title"><a href="#" class="carriere-container__link">Joignez vous à notre équipe!</a></h3>
        </div>
      </div>
    </section>
    <section class="media">
      <div class="row">
        <div class="col-1-de-2">
          <div class="media-sociaux-container">
            <h3 class="media-sociaux-container__title">Suivez-nous!</h3>
            <a href="#" class="media-sociaux-container__link media-sociaux-container--fb"></a>
            <a href="#" class="media-sociaux-container__link media-sociaux-container--insta"></a>
            <a href="#" class="media-sociaux-container__link media-sociaux-container--youtube"></a>
          </div>
        </div>
        <div class="col-1-de-2">
          <form action="" class="info-lettre">
            <h3 class="info-lettre__titre">Inscrivez-vous à notre info-lettre!</h3>
            <h4 class="info-lettre__soustitre">Obtenez un rabais de 5$ sur une repas en restaurant</h4>
            <input type="text" class="info-lettre__input" placeholder="Prénom">
            <input type="text" class="info-lettre__input" placeholder="Nom">
            <input type="text" class="info-lettre__input" placeholder="Courriel">
            <a href="#" class="btn">Je m'inscris!</a>
          </form>        
        </div>
      </div>
    </section>
</asp:Content>

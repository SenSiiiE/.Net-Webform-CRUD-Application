
<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MyMedicos.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card d-flex justify-content-center parent">
            <div class="card-body container text-center custom-brand-photo">
                <a href="Item_List.aspx" class="card-link inline_block custom-show-items">See Available Items<img src="bag-check-fill.svg" class="custom-logo"/></a>
                
            </div>
        </div>
</asp:Content>

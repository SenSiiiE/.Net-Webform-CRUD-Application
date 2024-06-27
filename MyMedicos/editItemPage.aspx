<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="editItemPage.aspx.cs" Inherits="MyMedicos.editItemPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="custom-form container">
    <div class="row">
    <div class="custom-form-heading col-md-12">
        <h1 class="custom-heading">
            Update item details
        </h1>
    </div>

        </div>
    <div class="row custom-field">
        <div class="custom-form-content col-md-3">
            <asp:Label ID="item_name_update" runat="server" ForeColor="White">Item Name</asp:Label>
        </div>
        <div class="custom-form-content col-md-5">
            <asp:TextBox ID="TextBox_name_update" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name_update" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

        </div>
    </div>

    <div class="row custom-field">
        <div class="custom-form-content col-md-3">
            <asp:Label ID="item_category_update" runat="server" ForeColor="White">Cateogry</asp:Label>
        </div>
        <div class="custom-form-content col-md-5">
            <asp:TextBox ID="TextBox_category_update" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_category_update" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />


        </div>
    </div>

    <div class="row custom-field">
        <div class="custom-form-content col-md-3">
            <asp:Label ID="item_price_update" runat="server" ForeColor="White">Price</asp:Label>
        </div>
        <div class="custom-form-content col-md-5">
            <asp:TextBox ID="TextBox_price_update" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_price_update" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

        </div>
        </div>
    <div class="row custom-field">
    <div class="custom-form-content col-md-3">
        <asp:Label ID="Label1_update" runat="server" ForeColor="White">Quantity Available</asp:Label>
    </div>
    <div class="custom-form-content col-md-5">
        <asp:TextBox ID="TextBox_quant_update" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_quant_update" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

    </div>
    </div>
    <div class="row custom-field">
        <div class="custom-form-content col-md-3">
            <asp:Label ID="Label2_update" runat="server" ForeColor="White">Distributor Address</asp:Label>
        </div>
        <div class="custom-form-content col-md-5">
            <asp:TextBox ID="TextBox_add_update" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox_add_update" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

        </div>
    </div>
    <div class="row custom-field">
        <div class="col-md-3 custom-form-content">
            <asp:Button CssClass="btn btn-success submit-btn" ID="UpdateButton" runat="server" text="Submit" OnClick="SubmitButton_Click"/>
        </div>
        <div class="col-md-7 custom-form-content">
            <a class="custom-a" href="Item_List.aspx">Back to Items List</a>
        </div>
    </div>
    <div class="custom-success">

    <asp:label id="label_success" runat="server" ForeColor="White">

    </asp:label>
    </div>
    

</div>
</asp:Content>

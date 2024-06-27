<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="MyMedicos.addItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="custom-form container">
        <div class="row">
            <div class="custom-form-heading col-md-12">
                <h1 class="custom-heading">Enter item details
                </h1>
            </div>

        </div>
        <div class="row custom-field">
            <div class="custom-form-content col-md-3">
                <asp:Label ID="item_name1" runat="server" ForeColor="White">Item Name</asp:Label>
            </div>
            <div class="custom-form-content col-md-5">
                <asp:TextBox ID="TextBox_name1" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox_name1" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

            </div>
        </div>

        <div class="row custom-field">
            <div class="custom-form-content col-md-3">
                <asp:Label ID="item_category" runat="server" ForeColor="White">Cateogry</asp:Label>
            </div>
            <div class="custom-form-content col-md-5">
                <asp:TextBox ID="TextBox_category" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_category" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />


            </div>
        </div>

        <div class="row custom-field">
            <div class="custom-form-content col-md-3">
                <asp:Label ID="item_price" runat="server" ForeColor="White">Price</asp:Label>
            </div>
            <div class="custom-form-content col-md-5">
                <asp:TextBox ID="TextBox_price" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_price" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

            </div>
            <div class="col-md-1">
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddMoreButton_Click" OnClientClick="addMoreTextBox(); return false;" />

            </div>

        </div>
                            <asp:TextBox ID="textbox1" runat="server" placeholder="Enter" Visible="false"></asp:TextBox>

            <asp:TextBox ID="textbox2" runat="server" placeholder="Enter" Visible="false"></asp:TextBox>

            <asp:TextBox ID="textbox3" runat="server" placeholder="Enter" Visible="false"></asp:TextBox>

            <asp:TextBox ID="textbox4" runat="server" placeholder="Enter" Visible="false"></asp:TextBox>



        <div class="row custom-field">
            <div class="custom-form-content col-md-3">
                <asp:Label ID="Label1" runat="server" ForeColor="White">Quantity Available</asp:Label>
            </div>
            <div class="custom-form-content col-md-5">
                <asp:TextBox ID="TextBox_quant" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_quant" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

            </div>
        </div>
        <div class="row custom-field">
            <div class="custom-form-content col-md-3">
                <asp:Label ID="Label2" runat="server" ForeColor="White">Distributor Address</asp:Label>
            </div>
            <div class="custom-form-content col-md-5">
                <asp:TextBox ID="TextBox_add" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox_add" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />

            </div>
        </div>
        <div class="row custom-field">
            <div class="col-md-3 custom-form-content">
                <asp:Button CssClass="btn btn-success submit-btn" ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
            </div>
            <div class="col-md-7 custom-form-content">
                <a class="custom-a" href="Item_List.aspx">Back to Items List</a>
            </div>
        </div>
        <div class="custom-success">

            <asp:Label ID="label_success" runat="server" ForeColor="White">

            </asp:Label>
        </div>


    </div>

    <script>
        function addMoreTextBox() {
            //console.log("add more textbox..!!")
            //var container = document.getElementById('#dynamicTextBoxContainer');
            //var textbox = document.createElement('div');
            //textbox.innerHTML = '<div class = "row custom-field">' +
            //    '<div class="custom-form-content col-md-3">' +
            //    '<asp:Label ID = "item_name" runat = "server" ForeColor = "White"> Item Name</asp:Label>' +
            //    '</div>' +
            //    '<div class="custom-form-content col-md-5">' +
            //    '   <asp:TextBox ID="TextBox_name" runat="server" CssClass="form-control"></asp:TextBox>' +
            //    '   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="Field is required!!" CssClass="error-message" Display="Dynamic" />' +
            //    '</div>' +
            //    '</div>';
            //container.appendChild(textBox);


        }
    </script>

</asp:Content>

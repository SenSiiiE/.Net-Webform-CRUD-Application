<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyMedicos.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>  
 <asp:TextBox ID="TextBox1" runat="server" Width="146px"></asp:TextBox>  
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
     ControlToValidate="TextBox1" ErrorMessage="Enter username." ForeColor="Red"></asp:RequiredFieldValidator>  
 <br />  
 Password<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"   
     Width="147px"></asp:TextBox>  
 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
     ControlToValidate="TextBox2" ErrorMessage="Enter password." ForeColor="Red"></asp:RequiredFieldValidator>  
 <br />  
 <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Log In" />  
 <br />  
 <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

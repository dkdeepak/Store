<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="StoreManagement._Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    


<asp:DropDownList ID="ddlCity" runat="server" Width="200px">
 <asp:ListItem Value="0">--Select--</asp:ListItem>
 <asp:ListItem Value="1">Delhi</asp:ListItem>
 <asp:ListItem Value="2">Noida</asp:ListItem>
 <asp:ListItem Value="3">Gurgaon</asp:ListItem>
 <asp:ListItem Value="4">Mumbai</asp:ListItem>
 <asp:ListItem Value="5">Pune</asp:ListItem>
 <asp:ListItem Value="6">Banglore</asp:ListItem>
 <asp:ListItem Value="7">Lucknow</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCity" InitialValue="0" runat="server" ErrorMessage="Please select city"></asp:RequiredFieldValidator>
 </div>
 <br />
 <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
     
</asp:Content>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StoreManagement.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.dataTable
{
text-align:left;
font-size:10pt;
font-family:Verdana, Sans-Serif;
border:solid 1px rgb(210,210,210);
color:gray;
 
}
.dataTable CAPTION
{
color:Black;
text-align:left;
font-size:12pt;
font-weight:bold;
padding-bottom:5px;
padding-top:15px;
}
.dataTable TH
{
text-decoration:none;
background-color:rgb(210,210,210);
font-family:Tahoma, Sans-Serif, Arial;
font-size:11pt;
font-weight:normal;
color:Black;
border:solid 0px;
padding:2px 4px 2px 2px;
}
.dataTable TD
{
padding-left:6px;
border:solid 0px;
min-width:100px;
}
.dataTable TR
{
border:solid 0px;
 
}
.dataTableAlt TD
{
font-size: 10pt;
color:rgb(75,75,75);
font-family:Verdana;
border: solid 0px;
padding:2px 0px 2px 8px;
background-color:rgb(245,245,245);
min-width:100px;
}
.dataTableRow
{
color:rgb(75,75,75);
font-family:Verdana;
padding:2px 0px 2px 8px;
border:solid 0px;
background-color:White;
}
.dataTable A:Link, .dataTable A:Visited
{
text-decoration:none;
color:black;
}
.dataTable A:Hover
{
color:Red;
text-decoration:none;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
<asp:GridView ID="GridView1"
runat="server"
DataKeyNames="PurchaseOrderID" AutoGenerateColumns="false"
OnRowDataBound="gv_RowDataBound" Width="80%"
AllowPaging="True" PageSize="20" >
<HeaderStyle CssClass="dataTable" />
<RowStyle CssClass="dataTable" />
<AlternatingRowStyle CssClass="dataTableAlt" />
<Columns>
<asp:TemplateField>
<ItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseOrderID") %>', 'one');">
<img id="imgdiv<%# Eval("PurchaseOrderID") %>" alt="Click to show/hide orders" border="0" src="Images/view.png" />
</a>
</ItemTemplate>
<AlternatingItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseOrderID") %>', 'alt');">
<img id="imgdiv<%# Eval("PurchaseOrderID") %>" alt="Click to show/hide orders" border="0" src="Images/view.png"/>
</a>
</AlternatingItemTemplate>
</asp:TemplateField>
 
<asp:BoundField DataField="PurchaseOrderID" HeaderText="PurchaseOrderID" HtmlEncode="False" />
<asp:BoundField DataField="PurchaseAmount" HeaderText="PurchaseAmount" HtmlEncode="False" />
<asp:BoundField DataField="TaxValue" HeaderText="TaxValue" HtmlEncode="False" />
<asp:TemplateField>
<ItemTemplate>
</td></tr>
<tr>
<td colspan="100%" >
<div id="div<%# Eval("PurchaseOrderID") %>" style="display:none;position:relative;left:25px;" >
<asp:GridView ID="GridView2" runat="server" Width="80%"
AutoGenerateColumns="false" DataKeyNames="PurchaseOrderItemID"
EmptyDataText="No purchase orders item for this customer." >
<HeaderStyle CssClass="dataTable" />
<AlternatingRowStyle CssClass="dataTableAlt" />
<RowStyle CssClass="dataTable" />
<Columns>
<asp:BoundField DataField="PurchaseOrderItemID" HeaderText="Purchase Order item" HtmlEncode="False" />
<asp:BoundField DataField="ItemID" HeaderText="ItemID" HtmlEncode="False" />
<asp:BoundField DataField="ItemUnit" HeaderText="ItemUnit" />
 
</Columns>
</asp:GridView>
</div>
</td>
</tr>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</form>
    <script type="text/javascript">
function switchViews(obj, row) {
var div = document.getElementById(obj);
var img = document.getElementById('img' + obj);
 
if (div.style.display == "none") {
div.style.display = "inline";
img.src = "images/expand_button_down.png";
} else {
div.style.display = "none";
img.src = "images/expand_button.png";
}
}
</script>
</body>
</html>

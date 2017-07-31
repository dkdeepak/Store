<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseReceived.aspx.cs" Inherits="StoreManagement.ReportSection.PurchaseReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">

    <asp:UpdatePanel id="up2" runat="server">
        <ContentTemplate>
           

                
            <asp:GridView ID="gvPOrder"
runat="server"
DataKeyNames="PurchaseReceivedID" 
OnRowDataBound="gvPOrder_RowDataBound" Width="80%"
AllowPaging="True" PageSize="20" >
<HeaderStyle CssClass="dataTable" />
<RowStyle CssClass="dataTable" />
<AlternatingRowStyle CssClass="dataTableAlt" />
<Columns>
<asp:TemplateField HeaderText="View">
<ItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseReceivedID") %>', 'one');">
<img id="imgdiv<%# Eval("PurchaseReceivedID") %>" alt="Click to show/hide orders" border="0" width="20px" height="20px" src="../Images/view.png" />
</a>
</ItemTemplate>
<AlternatingItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseReceivedID") %>', 'alt');">
<img id="imgdiv<%# Eval("PurchaseReceivedID") %>" alt="Click to show/hide orders" width="20px" height="20px" border="0" src="../Images/view.png"/>
</a>
</AlternatingItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:ImageButton ID="imgbtn" ImageUrl="~/Images/edit.png" runat="server" Width="25" Height="25" OnClick="imgbtn_Click" />
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:ImageButton ID="imgbtnfrDelete" ImageUrl="~/Images/delete.png" runat="server" Width="20" Height="20" OnClick="imgbtnfrDelete_Click" />
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField>
<ItemTemplate>
</td></tr>
<tr>
<td colspan="100%" >
<div id="div<%# Eval("PurchaseReceivedID") %>" style="display:none;position:relative;left:25px;" >
<asp:GridView ID="gvPoItem" runat="server" Width="80%"
 DataKeyNames="PurchaseItemReceivedID"
EmptyDataText="No purchase orders item for this customer." >
<HeaderStyle CssClass="dataTable" />
<AlternatingRowStyle CssClass="dataTableAlt" />
<RowStyle CssClass="dataTable" />
</asp:GridView>
</div>
</td>
</tr>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

        </ContentTemplate>

    </asp:UpdatePanel>
    <script type="text/javascript">
function switchViews(obj, row) {
var div = document.getElementById(obj);
var img = document.getElementById('img' + obj);
 
if (div.style.display == "none") {
div.style.display = "inline";
img.src = "../Images/view.png";
} else {
div.style.display = "none";
img.src = "../Images/view.png";
}
}
</script>
</asp:Content>

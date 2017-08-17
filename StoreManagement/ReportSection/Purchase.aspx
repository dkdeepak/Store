<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="StoreManagement.ReportSection.Purchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <asp:UpdatePanel id="up2"  runat="server">
        <ContentTemplate>
           
           
                
            <asp:GridView ID="gvPOrder"
            runat="server"
            onrowdatabound="gvPOrder_RowDataBound"
            DataKeyNames="PurchaseOrderID" 
             AutoGenerateColumns="false"
             Width="80%"
            AllowPaging="True" PageSize="20" >
            <HeaderStyle CssClass="dataTable" />
            <RowStyle CssClass="dataTable" />
            <AlternatingRowStyle CssClass="dataTableAlt" />
            <Columns>
            <asp:TemplateField  ItemStyle-HorizontalAlign="Center"  HeaderText="View">
            <ItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseOrderID") %>', 'one');">
    
<img id="imgdiv<%# Eval("PurchaseOrderID") %>" alt="Click to show/hide orders"  border="1" " width="20px" height="20px" src="../Images/view.png" />
</a>
</ItemTemplate>
<AlternatingItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseOrderID") %>', 'alt');">
    
 <img id="imgdiv<%# Eval("PurchaseOrderID") %>" alt="Click to show/hide orders"  style="align-items:center" width="20px" height="20px" border="0" src="../Images/view.png"/>
</a>
</AlternatingItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="NotSet" HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:ImageButton ID="imgbtn" ImageUrl="~/Images/edit.png" runat="server" ImageAlign="Middle" Width="25" Height="25" OnClick="imgbtn_Click" />
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"   HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:ImageButton ID="imgbtnfrDelete" ImageUrl="~/Images/delete.png" ImageAlign="Middle" runat="server" Width="20" Height="20" OnClick="imgbtnfrDelete_Click" />
    </ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="PurchaseOrderID">
        <ItemTemplate>            
           <asp:Label ID="lblpo" runat="server" Text='<%# Eval("PurchaseOrderID") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date of purchase" >
        <ItemTemplate>            
           <asp:Label ID="lblpdate" runat="server" Text='<%# Eval("PurchaseDate") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Purchase Amount" >
        <ItemTemplate>            
           <asp:Label ID="lblamt" runat="server" Text='<%# Eval("PurchaseAmount") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Tax value" >
        <ItemTemplate>            
           <asp:Label ID="lbltax" runat="server" Text='<%# Eval("TaxValue") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Shipping & Handling Cost" >
        <ItemTemplate>            
           <asp:Label ID="lblshc" runat="server" Text='<%# Eval("ShipingAndHandlingCost") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText=" Miscellaneous Cost" >
        <ItemTemplate>            
           <asp:Label ID="lblMiscCost" runat="server" Text='<%# Eval("MiscCost") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Discount Amount" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Discount(%)" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscountPre" runat="server" Text='<%# Eval("DiscountPre") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

<asp:TemplateField>
<ItemTemplate>
</td></tr>
<tr>
<td colspan="100%" >
<div id="div<%# Eval("PurchaseOrderID") %>" style="display:none;position:relative;left:25px;" >
<asp:GridView ID="gvPoItem" runat="server" Width="80%"
 DataKeyNames="PurchaseOrderItemID"
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

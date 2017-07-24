<%@ Page Title="TRANSACTION| Purchase Order" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="POrder.aspx.cs" Inherits="StoreManagement.Admin.POrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    
 <asp:UpdatePanel ID="upForm" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
       <asp:HiddenField ID="hfPId" runat="server" />
       <center>
           <div class="panel panel-primary panel-heading">
<b>
           Purchase Order
   </b>
                    </div>
       
        </center>
       <hr />
       
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false"  GridLines="None" OnRowDataBound="Gridview1_RowDataBound">
            <HeaderStyle HorizontalAlign="Right" />
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName" placeholder="Enter Item Name" ToolTip="Item Name"     runat="server"  CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" CompletionListCssClass="autoCompleteList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false"  CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="true">  
                </ajaxToolkit:AutoCompleteExtender>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDec" placeholder="Item Description" ToolTip="Item Description"    runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" placeholder="Unit Price" ToolTip="Unit Price"    runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount(%)">
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtDisPre" runat="server" ToolTip="Discount(%)" placeholder="Discount(%)"    OnTextChanged="txtDisPre_TextChanged" AutoPostBack="true"  CssClass="form-control"  ></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:TextBox ID="txtDis" ToolTip="Discount" placeholder="Discount"   runat="server"   CssClass="form-control" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server"  ToolTip="Quantity" placeholder="Quantity"   CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                     <asp:TextBox ID="txtTotal" ToolTip="Total" placeholder="Total" runat="server"   CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        <hr />
        <div class="row">
            <div class="col-lg-2 col-lg-offset-10 ">
                <asp:TextBox ID="txtSubTotal" placeholder="Sub Total" ToolTip="Sub Total" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-2 col-lg-offset-10">
                <asp:TextBox ID="txtDicPre" placeholder="Discount(%)" ToolTip="Discount(%)" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtDicPre_TextChanged1"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-2 col-lg-offset-10">
                <asp:TextBox ID="txtDic" runat="server" placeholder="Discount" ToolTip="Discount"  CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-2 col-lg-offset-10">
                <asp:TextBox ID="txtTax" placeholder="Tax(%)" ToolTip="Tax(%)"  runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-2 col-lg-offset-10">
                <asp:TextBox ID="txtSHC" placeholder="Shiping And Handling Cost" ToolTip="Shiping And Handling Cost" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10">
            <asp:TextBox ID="txtMiscCost"  runat="server" placeholder="Misc Cost" ToolTip="Misc Cost" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtMiscCost_TextChanged"></asp:TextBox>
        </div>
        
</div>
        <br />
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txttotal" placeholder="Total" ToolTip="Total" CssClass="form-control" runat="server"></asp:TextBox></div>
        
</div>
        <br />
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:Button ID="btnSubmit" Text="Submit" CssClass="form-control btn-primary" runat="server" OnClick="btnSubmit_Click" />
         </div>
        </div>
    </ContentTemplate>
  </asp:UpdatePanel>
      

<br />
    <asp:UpdatePanel id="up2" runat="server">
        <ContentTemplate>
           

                
            <asp:GridView ID="gvPOrder"
runat="server"
DataKeyNames="PurchaseOrderID" 
OnRowDataBound="gvPOrder_RowDataBound" Width="80%"
AllowPaging="True" PageSize="20" >
<HeaderStyle CssClass="dataTable" />
<RowStyle CssClass="dataTable" />
<AlternatingRowStyle CssClass="dataTableAlt" />
<Columns>
<asp:TemplateField HeaderText="View">
<ItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseOrderID") %>', 'one');">
<img id="imgdiv<%# Eval("PurchaseOrderID") %>" alt="Click to show/hide orders" border="0" width="20px" height="20px" src="../Images/view.png" />
</a>
</ItemTemplate>
<AlternatingItemTemplate>
<a href="javascript:switchViews('div<%# Eval("PurchaseOrderID") %>', 'alt');">
<img id="imgdiv<%# Eval("PurchaseOrderID") %>" alt="Click to show/hide orders" width="20px" height="20px" border="0" src="../Images/view.png"/>
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
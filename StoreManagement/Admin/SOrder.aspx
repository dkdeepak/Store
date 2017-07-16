<%@ Page Title="TRANSACTION| Sales Order" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SOrder.aspx.cs" Inherits="StoreManagement.Admin.SOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    
 <asp:UpdatePanel ID="up1" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
       <center>
           <div class="panel panel-primary panel-heading">
<b>
           Sales Order
   </b>
                    </div>
       
        </center>
       <hr />
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false" GridLines="None" OnRowDataBound="Gridview1_RowDataBound">
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName" placeholder="Enter Item Name" ToolTip="Item Name" runat="server" CssClass="form-control" OnTextChanged="txtItemName_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
                </ajaxToolkit:AutoCompleteExtender>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtDis" runat="server" placeholder="Item Description" ToolTip="Item Description"  CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtCostAmount" runat="server" placeholder="Cost Price" ToolTip="Cost Price" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtSaleAmount" runat="server" ToolTip="Sale price" placeholder="Sale Price" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtDisPer" runat="server"  ToolTip="Discount(%)" placeholder="Discount(%)" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtDisAmt" runat="server" ToolTip="Discount" placeholder="Discount"  CssClass="form-control"  ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server" ToolTip="Quantity" placeholder="Quantity" AutoPostBack="true" OnTextChanged="txtQut_TextChanged" CssClass="form-control" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        <hr />
        <div >
        <div class="row">
        <div class="col-lg-2"><asp:TextBox ID="txtPriceCT" CssClass="form-control" placeholder="Cost Price Total" ToolTip="Cost Price Total" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:TextBox ID="txtPriceST" CssClass="form-control" placeholder="Sale Price Total" ToolTip="Sale Price Total" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:TextBox ID="txtDisT" CssClass="form-control" placeholder="Discount Total" ToolTip="Discount Total" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:TextBox ID="txtTax" CssClass="form-control" placeholder="Tax(%)" ToolTip="Tax(%)" runat="server" ></asp:TextBox></div>
        <div class="col-lg-2"><asp:TextBox ID="txtSHC" CssClass="form-control" placeholder="Shiping And Handling Cost" ToolTip="Shiping And Handling Cost" runat="server"></asp:TextBox></div>
        <div class="col-lg-2"><asp:TextBox ID="txtMiscCost" CssClass="form-control" placeholder="Misc Cost" ToolTip="Misc Cost"  runat="server"></asp:TextBox></div>
        </div>
        <hr />
        <div class="row">
        <div class="col-lg-3 col-lg-offset-4"><asp:Button ID="btnSubmit" Text="Submit" CausesValidation="false"  runat="server" 
                CssClass="form-control btn-primary" OnClick="btnSubmit_Click"  /></div>
        </div>
        <div>
            <div id="loading" style="display:none;" runat="server" class="loading1"></div>
        </div>
</div>

    </ContentTemplate>
    
  </asp:UpdatePanel>      

<br />

</asp:Content>




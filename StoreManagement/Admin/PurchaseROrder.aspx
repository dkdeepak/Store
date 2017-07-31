<%@ Page Title="TRANSACTION| Purchase Received"  Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseROrder.aspx.cs" Inherits="StoreManagement.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <br />
    <asp:HiddenField ID="hfPoderId" runat="server" />
    <asp:UpdatePanel ID="upSearch" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary col-lg-4 col-md-4 col-sm-4 col-xm-4 col-lg-offset-4" id="divSerach" runat="server">
            <div class="panel-heading"></div>
                <div class="panel-body">
                    <asp:TextBox ID="txtPoId" runat="server" placeholder="Enter Purchase Order No" CssClass="form-control" ValidationGroup="serach"></asp:TextBox>
                    <br />    
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-control btn-primary" OnClick="btnSearch_Click" />
                </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
 <asp:UpdatePanel ID="up1" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
       <div id="divForm" runat="server">
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="Gridview1_RowDataBound" >
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName"  Text='<%# Bind("ItemPrefix") %>' runat="server"  CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
                </ajaxToolkit:AutoCompleteExtender>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDec" Text='<%# Bind("Description") %>'  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" Text='<%# Bind("ItemPrice") %>'  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" Text='<%# Bind("ItemUnit") %>'  runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:TextBox ID="txtTotal" Text='<%# Bind("TotalPrice") %>'  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        
        <div >
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblSubTotal" Font-Bold="true" runat="server" Text="Sub Total"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtSubTotal" CssClass="form-control" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblTax" Font-Bold="true" runat="server" Text="Tax(%)"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtTax" runat="server" CssClass="form-control" ></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblSHC" Font-Bold="true" runat="server" Text="Shiping And Handling Cost"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtSHC" runat="server" CssClass="form-control"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblMiscCost" Font-Bold="true" runat="server" Text="Misc Cost"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtMiscCost" CssClass="form-control" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
             <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblGToatal" Font-Bold="true" runat="server" Text="Total"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtTotal"  CssClass="form-control"  runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Button ID="btnSubmit" Text="Submit" CausesValidation="false"   runat="server" 
               CssClass="form-control btn-primary" OnClick="btnSubmit_Click"  /></div>
        <div class="col-lg-2"><asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false"   runat="server" 
               CssClass="form-control btn-danger" OnClick="btnCancel_Click"  /></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-5"></div>
</div>
       
</div>
        </div>
    


    </ContentTemplate>
     <Triggers>
         <asp:AsyncPostBackTrigger ControlID ="Gridview1" />
         
     </Triggers>
  </asp:UpdatePanel>      

<br />

    <asp:HiddenField ID="hfpo" Value="0"  runat="server" />
    <asp:Label ID="lbl1" runat="server"></asp:Label>
    
</asp:Content>



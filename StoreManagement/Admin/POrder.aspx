<%@ Page Title="TRANSACTION| Purchase Order" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="POrder.aspx.cs" Inherits="StoreManagement.Admin.POrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .autoCompleteList {
      list-style: none outside none;
      border: 5px solid #123456;
      cursor: pointer;
      padding: 5px;
      margin: 0px;
      z-index:10000 !important;
    }
      
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    
 <asp:UpdatePanel ID="up1" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
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
                    <asp:TextBox ID="txtDec" placeholder="Item Description" ToolTip="Item Description"  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" placeholder="Unit Price" ToolTip="Unit Price"  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount(%)">
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtDisPre" runat="server" ToolTip="Discount(%)" placeholder="Discount(%)"  OnTextChanged="txtDisPre_TextChanged" AutoPostBack="true"  CssClass="form-control"  ></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:TextBox ID="txtDis" ToolTip="Discount" placeholder="Discount"   runat="server" CssClass="form-control" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server"  ToolTip="Quantity" placeholder="Quantity" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                     <asp:TextBox ID="txtTotal" ToolTip="Total" placeholder="Total" runat="server" CssClass="form-control"></asp:TextBox>
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
    <asp:UpdatePanel id="up2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvPOrder" runat="server"  Width="100%" CssClass="Grid" 
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="PurchaseOrderID">
                                    <Columns>                                       

                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                
                                                <asp:ImageButton ID="imgbtnfrView" ImageUrl="~/Images/view.png" runat="server" Width="20" Height="20" OnClick="imgbtnfrView_Click" />
                                           
                                                     </ItemTemplate>
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
                                               

                                                <asp:GridView ID="gvPoItem" runat="server"  DataKeyNames="PurchaseOrderItemID" CssClass="Grid"
                                                     AlternatingRowStyle-CssClass="alt"></asp:GridView>
                                              
                                                
                                                   
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
              
        </ContentTemplate>

    </asp:UpdatePanel>
  
</asp:Content>
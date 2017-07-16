<%@ Page Title="TRANSACTION| Purchase Order" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="POrder2.aspx.cs" Inherits="StoreManagement.Admin.POrder2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <div style="width: 100%">
        <div>
            <asp:HiddenField ID="rid" runat="server" />
            <table style="width: 100%">
                <tr>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click"><span class="glyphicon glyphicon-trash"></span>View Cart</asp:LinkButton>
                            </ContentTemplate>                            
                       </asp:UpdatePanel>

                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <center>
        <div class="panel panel-primary panel-heading">
            <b>Purchase Order</b>
        </div>
    </center>
    <hr />

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup"  DefaultButton="bntAdd">
   <asp:UpdatePanel ID="upGrid" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false"  GridLines="None" OnRowDataBound="Gridview1_RowDataBound">
            <HeaderStyle HorizontalAlign="Right" />
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtItemName" placeholder="Enter Item Name" ToolTip="Item Name"     runat="server"  CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
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
       <asp:Button ID="bntAdd"  CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgCat" Text="Add to Cart" OnClick="bntAdd_Click" />
       
     </ContentTemplate>
  </asp:UpdatePanel> 
         </asp:Panel>
            <hr />
    <asp:UpdatePanel ID="upTotal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txtSubTotal" placeholder="Sub Total" ToolTip="Sub Total" runat="server" CssClass="form-control"></asp:TextBox></div>
        
        </div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txtDicPre" placeholder="Discount(%)" ToolTip="Discount(%)" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtDicPre_TextChanged1"></asp:TextBox></div>
        
</div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txtDic" runat="server" placeholder="Discount" ToolTip="Discount"  CssClass="form-control" ></asp:TextBox></div>
        
</div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txtTax" placeholder="Tax(%)" ToolTip="Tax(%)"  runat="server" CssClass="form-control" ></asp:TextBox></div>
        
</div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txtSHC" placeholder="Shiping And Handling Cost" ToolTip="Shiping And Handling Cost" runat="server" CssClass="form-control"></asp:TextBox></div>
        
</div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txtMiscCost"  runat="server" placeholder="Misc Cost" ToolTip="Misc Cost" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtMiscCost_TextChanged"></asp:TextBox></div>
        
</div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:TextBox ID="txttotal" placeholder="Total" ToolTip="Total" CssClass="form-control" runat="server"></asp:TextBox></div>
        
</div>
        <div class="row">
        <div class="col-lg-2 col-lg-offset-10"><asp:Button ID="btnSubmit" Text="Submit" CssClass="form-control btn-primary" runat="server" OnClick="btnSubmit_Click" />
         </div>
        
</div>
        <div>
            <div id="loading" style="display:none;" runat="server" class="loading1"></div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    


         

<br />
    <asp:HiddenField ID="hfpo" Value="0"  runat="server" />
    <asp:Label ID="lbl1" runat="server"></asp:Label>
</asp:Content>
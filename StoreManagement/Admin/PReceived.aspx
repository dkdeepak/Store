<%@ Page Title="TRANSACTION| Purchase Received" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PReceived.aspx.cs" Inherits="StoreManagement.Admin.PReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
         .leftmargin{
             margin-left:-7%;
         }
     </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <asp:Button ID="btnShowVendor"  runat="server" Style="display: none" />
    <asp:Button ID="btnShowSummary"  runat="server" Style="display: none" />

 <asp:UpdatePanel ID="upForm" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
       <asp:HiddenField ID="hfPId" runat="server" />
       <center>
           <div class="panel panel-primary panel-heading">
                <b>Purchase Received</b>
           </div>       
        </center>
       <hr />
       <div class="row" id="divData" runat="server">
           <asp:GridView ID="gvPOrder" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bReceiveded table-hover" OnRowDeleting="gvPOrder_RowDeleting">
               <Columns>
                    <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="5%" />
                    <asp:BoundField HeaderText="Purchase Date" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-CssClass="text_title" DataField="PurchaseDate" ItemStyle-Width="5%" />
                    <asp:BoundField HeaderText="Purchase Amount" ItemStyle-CssClass="text_title" DataField="PurchaseAmount" ItemStyle-Width="5%" />
                    <asp:BoundField HeaderText="Tax" ItemStyle-CssClass="text_title" DataField="TaxValue" ItemStyle-Width="5%" />
                    <asp:BoundField HeaderText="Shiping & Handling" ItemStyle-CssClass="text_title" DataField="ShipingAndHandlingCost" ItemStyle-Width="5%" />
                    <asp:BoundField HeaderText="MiscCost" ItemStyle-CssClass="text_title" DataField="MiscCost" ItemStyle-Width="5%" />
                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfVendorId"  Value='<%# Bind("VendorID") %>' runat="server" />
                            <asp:HiddenField ID="hfPOrderId" Value='<%# Bind("PurchaseOrderID") %>' runat="server" />
                            <asp:ImageButton ID="imgbtnSelect" CommandName="delete"  ImageUrl="~/Images/select.png" runat="server" Width="50" Height="20"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
           </asp:GridView>
       </div>
       <div id="divFrom" runat="server">
       <div class="row">
           <div class="col-lg-6">
               <div class="row">
                   <div class="col-lg-3">
                       <label  class="form-control">Name</label>
                   </div>
                   <div class="col-lg-7 leftmargin">
                        <asp:TextBox ID="txtVendor" CssClass="form-control" ReadOnly="true" runat="server" required placeholder="Enter the Supplier Name"></asp:TextBox>
                       <asp:HiddenField ID="hfVendor" runat="server" />
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-3"><label  class="form-control">E-Mail</label></div>
                   <div class="col-lg-9 leftmargin"><asp:TextBox ID="txtEmail" ReadOnly="true" CssClass="form-control" runat="server" placeholder="E-Mail"></asp:TextBox></div>
               </div>
               <div class="row">
                   <div class="col-lg-3"><label  class="form-control">Mobile</label></div>
                   <div class="col-lg-9 leftmargin"><asp:TextBox ID="txtMobile" ReadOnly="true" CssClass="form-control" runat="server" placeholder="Mobile"></asp:TextBox></div>
               </div>
               <div class="row">
                   <div class="col-lg-3"><label  class="form-control">Date</label></div>
                   <div class="col-lg-9 leftmargin"><asp:TextBox ID="TxtDate" CssClass="form-control" runat="server" placeholder="Date"></asp:TextBox></div>
               </div>
           </div>
           <div class="col-lg-6">
               <div class="row">
                   <div class="col-lg-3"><label  class="form-control">Address</label></div>
                   <div class="col-lg-9 leftmargin"><asp:TextBox ID="txtAddress" TextMode="MultiLine" ReadOnly="true" Rows="3" CssClass="form-control" runat="server" placeholder="Address"></asp:TextBox></div>
               </div>
               <div class="row" style="margin-top:1%;">
                   <div class="col-lg-3"><label  class="form-control">State</label></div>
                   <div class="col-lg-3 leftmargin">
                       <asp:TextBox ID="txtState" CssClass="form-control" runat="server" ReadOnly="true" placeholder="State"></asp:TextBox>
                   </div>
                   <div class="col-lg-3"><label  class="form-control">City</label></div>
                   <div class="col-lg-3 leftmargin">
                       <asp:TextBox ID="txtCity" CssClass="form-control" runat="server" ReadOnly="true" placeholder="City"></asp:TextBox>
                   </div>
               </div>
               <div class="row">
                   <div class="col-lg-3"><label  class="form-control">Country</label></div>
                   <div class="col-lg-3 leftmargin">
                       <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server" ReadOnly="true" placeholder="Country"></asp:TextBox>
                   </div>
                   <div class="col-lg-3"><label  class="form-control">Pin Code</label></div>
                   <div class="col-lg-3 leftmargin">
                       <asp:TextBox ID="txtPin" CssClass="form-control" runat="server" ReadOnly="true" placeholder="Pin Code"></asp:TextBox>
                   </div>
               </div>
          </div>
    </div>
       <hr />
       <asp:HiddenField ID="hfPOrder" runat="server" />
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true"  CssClass="table table-striped table-bReceiveded table-hover" AutoGenerateColumns="false"  GridLines="None" OnRowDataBound="Gridview1_RowDataBound">
            <HeaderStyle HorizontalAlign="Right" />
            <Columns>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName" placeholder="Enter Item Name" ReadOnly="true"  Text='<%# Bind("ItemPrefix") %>' ToolTip="Item Name"     runat="server"  CssClass="form-control"></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDec" Text='<%# Bind("Description") %>' ReadOnly="true" placeholder="Item Description" ToolTip="Item Description"    runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    Total:
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice"  Text='<%# Bind("ItemPrice") %>' ReadOnly="true"  placeholder="Unit Price" ToolTip="Unit Price"    runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPriceT" placeholder="00.00" ToolTip="Unit Price"  ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server" Text='<%# Bind("ItemUnit") %>'  ToolTip="Quantity" placeholder="Quantity"   CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtQutT" placeholder="00" ToolTip="Quantity" ReadOnly="true"   runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                     <asp:TextBox ID="txtTotal" Text='<%# Bind("TotalPrice") %>' ToolTip="Total" placeholder="Total" ReadOnly="true" runat="server"   CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTotalT" placeholder="00.00" ToolTip="Total" ReadOnly="true"    runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>               
            </Columns>
        </asp:gridview>
        <hr />
        <div class="row">
            <div class="col-lg-2 col-lg-offset-4">
                <asp:Button ID="btnSubmit" Text="Submit" CssClass="form-control btn-primary" runat="server" OnClick="btnSubmit_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" 
               CssClass="form-control btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
        </div>
    </ContentTemplate>
  </asp:UpdatePanel>
   

    <ajaxToolkit:ModalPopupExtender ID="mpopSummary" runat="server" TargetControlID="btnShowSummary" PopupControlID="pnlSummary"
        CancelControlID="ibtnCloseSummary" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlSummary" runat="server" CssClass="modalPopup"  >
       <asp:UpdatePanel ID="upSummary" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-12">
            <div class="panel panel-default">
                    <div class="panel-heading">
                        <table width="100%">
                                <tr>
                                    <td align="left"><b>Purchase Received Summary</b></td>
                                    <td align="right"><asp:LinkButton ID="ibtnCloseSummary" Font-Bold="true" Font-Size="Large" runat="server" OnClick="ibtnCloseSummary_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                    </div>
                     <div class="panel-body">
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Sub Total</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtSubTotal" placeholder="Sub Total" ToolTip="Sub Total" runat="server" CssClass="form-control"></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Tax</label></div>
                             <div class="col-lg-6 leftmargin"> <asp:TextBox ID="txtTax" placeholder="Tax(%)" ToolTip="Tax(%)"  runat="server" CssClass="form-control" ></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Shiping & Handling Cost</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtSHC" placeholder="Shiping And Handling Cost" ToolTip="Shiping And Handling Cost" runat="server" CssClass="form-control"></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Misc Cost</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtMiscCost"  runat="server" placeholder="Misc Cost" ToolTip="Misc Cost" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtMiscCost_TextChanged"></asp:TextBox></div>
                         </div>
                          <div class="row">
                             <div class="col-lg-6"><label class="form-control">Total</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txttotal" placeholder="Total" ToolTip="Total" CssClass="form-control" runat="server"></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-4 col-lg-offset-2 ">
                                 <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CssClass="form-control btn-primary" OnClick="btnCheckOut_Click" />
                             </div>
                             <div class="col-lg-4 ">
                                 <asp:Button ID="btnCancelReceived" runat="server" Text="Cancel" CssClass="form-control btn-danger" OnClick="btnCancelReceived_Click" />
                             </div>
                         </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
<br />
    
   
  
</asp:Content>
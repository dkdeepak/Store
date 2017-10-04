<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SaleOrder.aspx.cs" Inherits="StoreManagement.Admin.SaleOrder" %>
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
                <b>Sales Order</b>
           </div>       
        </center>
       <hr />
       <div class="row">
           <div class="col-lg-6">
               <div class="row">
                   <div class="col-lg-3">
                       <label  class="form-control">Name</label>
                   </div>
                   <div class="col-lg-7 leftmargin">
                        <asp:TextBox ID="txtVendor" CssClass="form-control" ReadOnly="true" runat="server"  placeholder="Enter the Supplier Name"></asp:TextBox>
                       <asp:HiddenField ID="hfVendor" runat="server" />
                   </div>
                   <div class="col-lg-2 margin">
                        <asp:ImageButton ID="ibtnSearch" OnClick="ibtnSearch_Click" runat="server" Width="30px" ImageUrl="~/Images/search.png" />
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
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" ShowHeader="false" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false"  GridLines="None" OnRowDataBound="Gridview1_RowDataBound">
            <HeaderStyle HorizontalAlign="Right" />
            <Columns>
            <asp:BoundField DataField="RowNumber"/>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName" OnTextChanged="txtItemName_TextChanged" AutoPostBack="true" placeholder="Enter Item Name" ToolTip="Item Name"     runat="server"  CssClass="form-control"></asp:TextBox>
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
                <FooterTemplate>
                    Total:
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cost Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtCPrice" placeholder="cost Price" ToolTip="Cost Price"    runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCPriceT" placeholder="00.00" ToolTip="cost Price"  ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="sale Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtSPrice" placeholder="Sales Price" ToolTip="sales Price"    runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSPriceT" placeholder="00.00" ToolTip="sales Price"  ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Discount(%)">
                <ItemTemplate>                   
                    <asp:TextBox ID="txtDisPre" runat="server" ToolTip="Discount(%)" placeholder="Discount(%)"    AutoPostBack="true"  CssClass="form-control"  ></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDisPreT" placeholder="00.00 %" ToolTip="Discount(%)" ReadOnly="true"   runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:TextBox ID="txtDis" ToolTip="Discount" placeholder="Discount" ReadOnly="true"   runat="server"   CssClass="form-control" ></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDisT" placeholder="00.00" ToolTip="Discount" ReadOnly="true"   runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server"  ToolTip="Quantity" placeholder="Quantity"   CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtQutT" placeholder="00" ToolTip="Quantity" ReadOnly="true"   runat="server" CssClass="form-control"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                     <asp:TextBox ID="txtTotal" ToolTip="Total" placeholder="Total" ReadOnly="true" runat="server"   CssClass="form-control"></asp:TextBox>
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
    </ContentTemplate>
  </asp:UpdatePanel>

    <ajaxToolkit:ModalPopupExtender ID="mpopVendor" runat="server" TargetControlID="btnShowVendor" PopupControlID="pnlVendor"
        CancelControlID="lbtnClose" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlVendor" runat="server" CssClass="modalPopup"  >
       <asp:UpdatePanel ID="updateSupplierBdInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-12">
            <div class="panel panel-default">
                    <div class="panel-heading">
                        <table width="100%">
                                <tr>
                                    <td align="left"><b>Supplier Information</b></td>
                                    <td align="right"><asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn btn-primary" OnClick="btnNew_Click" /></td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" Font-Bold="true" Font-Size="Large" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                    </div>
                     <div class="panel-body">
                            <div class="col-md-12">
                                <asp:GridView ID="dgvVendorInfo" runat="server"   OnRowDeleting="dgvVendorInfo_RowDeleting" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="VendorID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Supplier ID"  ItemStyle-CssClass="text_title" DataField="VendorID" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Supplier Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Address" ItemStyle-CssClass="text_title" DataField="Address" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Country" ItemStyle-CssClass="text_title" DataField="CountryName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="State" ItemStyle-CssClass="text_title" DataField="StateName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="City" ItemStyle-CssClass="text_title" DataField="CityName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Pin" ItemStyle-CssClass="text_title" DataField="PinID" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="MobileNo" ItemStyle-CssClass="text_title" DataField="MobileNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="E-mailID" ItemStyle-CssClass="text_title" DataField="EmailID" ItemStyle-Width="5%" />
                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnSelect" CommandName="delete"  ImageUrl="~/Images/select.png" runat="server" Width="50" Height="20"  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                
                            </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

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
                                    <td align="left"><b>Sales Order Summary</b></td>
                                    <td align="right"><asp:LinkButton ID="ibtnCloseSummary" Font-Bold="true" Font-Size="Large" runat="server" OnClick="ibtnCloseSummary_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                    </div>
                     <div class="panel-body">
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control"> Cost Price Sub Total</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtCPSubTotal" placeholder="Cost Price sub Total" ToolTip="Cost Price sub Total" runat="server" CssClass="form-control"></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control"> Sales Price Sub Total</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtSPSubTotal" placeholder="Sale price Sub Total" ToolTip="Sale price Sub Total" runat="server" CssClass="form-control"></asp:TextBox></div>
                         </div>

                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Discount(%)</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtDicPre" placeholder="Discount(%)" ToolTip="Discount(%)" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtDicPre_TextChanged1"></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Discount</label></div>
                             <div class="col-lg-6 leftmargin"><asp:TextBox ID="txtDic" runat="server" placeholder="Discount" ToolTip="Discount"  CssClass="form-control" ></asp:TextBox></div>
                         </div>
                         <div class="row">
                             <div class="col-lg-6"><label class="form-control">Tax(%)</label></div>
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
                                 <asp:Button ID="btnCancelOrder" runat="server" Text="Cancel" CssClass="form-control btn-danger" OnClick="btnCancelOrder_Click" />
                             </div>
                         </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>


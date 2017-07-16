<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="StoreManagement.Admin.PurchaseOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr >
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Purchase Order</asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <hr />
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="updatePOrder" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvPOrder" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="PurchaseOrderID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName"  ItemStyle-Width="15%" />
                                        <asp:BoundField HeaderText="Purchase Date" ItemStyle-CssClass="text_title" DataField="PurchaseDate" DataFormatString="{0:dd-MMM-yyyy}"  ItemStyle-Width="15%" />
                                         <asp:BoundField HeaderText="Purchase Amount" ItemStyle-CssClass="text_title" DataField="PurchaseAmount"  ItemStyle-Width="15%" />
                                         <asp:BoundField HeaderText="Tax Value" ItemStyle-CssClass="text_title" DataField="TaxValue"  ItemStyle-Width="15%" />
                                         <asp:BoundField HeaderText="Shiping And Handling Cost" ItemStyle-CssClass="text_title" DataField="ShipingAndHandlingCost"  ItemStyle-Width="15%" />
                                         <asp:BoundField HeaderText="Miscellanenous Cost" DataField="MiscCost"  ItemStyle-Width="15%" />
                                         <asp:BoundField HeaderText="Is Avtive" DataField="IsActive" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Created Date" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="15%" />
                                      
                                       
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
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
     <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" BackColor="White" Style="display: none" DefaultButton="btnUpdate">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">purchase Order Information</div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="updatePOrderBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <div class="col-md-12">
                            <div class="row" style="visibility:hidden">
                                <div class="col-md-6">Purchase Order Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtPOId" runat="server" CssClass="form-control"/></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">Vendor Name:</div>
                                <div class="col-md-6"><asp:DropDownList ID="ddlVendor" runat="server"></asp:DropDownList></div>
                            </div>
                             <div class="row">
                                <div class="col-md-6">Purchase Date:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtPDate" runat="server"  Width="25%" />
                                        <ajaxToolkit:CalendarExtender ID="cePDate" TargetControlID="txtPDate" runat="server" />
                                       <asp:RequiredFieldValidator ID="rfvPDate" ControlToValidate="txtPDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="VgPOrder" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">Purchase Amount:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtPAmount" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvPAmount" ControlToValidate="txtPAmount" ErrorMessage="*" ForeColor="Red" ValidationGroup="VgPOrder" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                             <div class="row">
                                <div class="col-md-6">Tax Value:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtTaxValue" runat="server"  Width="25%" />
                                         <asp:RequiredFieldValidator ID="rfvTaxValue" ControlToValidate="txtTaxValue" ErrorMessage="*" ForeColor="Red" ValidationGroup="VgPOrder" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                             <div class="row">
                                <div class="col-md-6">Shipping & Handling Amount:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtSHCost" runat="server"  Width="25%" />
                                         <asp:RequiredFieldValidator ID="rfvSHCost" ControlToValidate="txtSHCost" ErrorMessage="*" ForeColor="Red" ValidationGroup="VgPOrder" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                             <div class="row">
                                <div class="col-md-6">Miscellanenous Cost:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtMiscCost" runat="server"  Width="25%" />
                                         <asp:RequiredFieldValidator ID="rfvMiscCost" ControlToValidate="txtMiscCost" ErrorMessage="*" ForeColor="Red" ValidationGroup="VgPOrder" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">Is Active:</div>
                                <div class="col-md-6">  <asp:CheckBox ID="cbIsActive" runat="server" /></div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                 <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                 <asp:Button ID="btnUpdate" CommandName="Update" runat="server" ValidationGroup="VgPOrder" Text="Submit" OnClick="btnUpdate_Click" />
                                </div>
                                <div class="col-md-6">
                                 <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CausesValidation="false" runat="server" Text="Cancel" />
                                </div>
                            </div>
                            </div>                                      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            
                

    </asp:Panel>
</asp:Content>

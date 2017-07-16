<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseReceived.aspx.cs" Inherits="StoreManagement.Admin.PurchaseReceived" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Purchase Received</asp:LinkButton>
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
                        <asp:UpdatePanel ID="updatePurchaseReceived" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvPurchaseReceived" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="PurchaseReceivedID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="15%" />
                                        <asp:BoundField HeaderText="Purchase Recived Date" ItemStyle-CssClass="text_title" DataField="PurchaseRecivedDate" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Purchase Amount" ItemStyle-CssClass="text_title" DataField="PurchaseAmount" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Tax Value" ItemStyle-CssClass="text_title" DataField="TaxValue" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Shiping And Handling Cost" ItemStyle-CssClass="text_title" DataField="ShipingAndHandlingCost" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Miscellaneous Cost" ItemStyle-CssClass="text_title" DataField="MiscCost" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Purchase Order ID" ItemStyle-CssClass="text_title" DataField="PurchaseOrderID" ItemStyle-Width="10%" />                                       
                                        <asp:BoundField HeaderText="Is Active" ItemStyle-CssClass="text_title" DataField="IsActive" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Created Date" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
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
    <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" BackColor="White" Height="269px" Width="400px" Style="display: none">
        <table width="100%" style="border: Solid 3px #337ab7; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
            <tr style="background-color: #337ab7">
                <td style="height: 12%; color: White; font-weight: bold; font-size: larger" align="center">Purchased Received Information</td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updatePurchasedReceivedBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table height="150px" width="382px" cellpadding="0" cellspacing="0">

                             <tr style="visibility:hidden">
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Received Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtPurchaseReceivedID" runat="server"  Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                            <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Vendor Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlVendor" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Received Date:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtPurchaseReceivedDate" runat="server"  Width="25%" />
                                        <ajaxToolkit:CalendarExtender ID="cePRDate" TargetControlID="txtPurchaseReceivedDate" runat="server" />
                                         <asp:RequiredFieldValidator ID="rfvPurchaseReceivedDate" ControlToValidate="txtPurchaseReceivedDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcv" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Amount:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtPurchaseAmount" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvPurchaseAmount" ControlToValidate="txtPurchaseAmount" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcv" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Tax Value:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTaxValue" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvTaxValue" ControlToValidate="txtTaxValue" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcv" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Shipping and Handling Cost:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtShippingHandlingCost" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvShippingHandlingCost" ControlToValidate="txtShippingHandlingCost" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcv" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Miscellaneous Cost:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtMiscCost" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvMiscCost" ControlToValidate="txtMiscCost" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcv" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Order Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                       <asp:DropDownList ID="ddlPurchaseOrderID" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Is Active:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                      <asp:CheckBox ID="chkBoxIsActive" runat="server" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
                                </tr>
                                
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <tr>

                <td style="text-align: center; vertical-align: top">
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" ValidationGroup="vgPRcv" Text="Submit" OnClick="btnUpdate_Click" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
                </td>
            </tr>


        </table>

    </asp:Panel>
</asp:Content>

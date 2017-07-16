<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesReturned.aspx.cs" Inherits="StoreManagement.Admin.SalesReturned" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Sales Returned </asp:LinkButton>
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
                        <asp:UpdatePanel ID="updateSalesReturned" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvSalesReturned" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="SalesReturnedID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Sales Return Date" ItemStyle-CssClass="text_title" DataField="SalesReturnDate" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Total Sales Return Amount" ItemStyle-CssClass="text_title" DataField="TotalSalesReturnAmount" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Tax Value" ItemStyle-CssClass="text_title" DataField="TaxValue" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Shipping And Handling Cost" ItemStyle-CssClass="text_title" DataField="ShippingAndHandlingCost" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Misc Cost" ItemStyle-CssClass="text_title" DataField="MiscCost" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Sales Order ID" ItemStyle-CssClass="text_title" DataField="SalesOrderID" ItemStyle-Width="10%" />
                                         <asp:BoundField HeaderText="Is Active" ItemStyle-CssClass="text_title" DataField="IsActive" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Created Date" ItemStyle-CssClass="text_title" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
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
                <td style="height: 12%; color: White; font-weight: bold; font-size: larger" align="center">Sales Return Information</td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updateSalesReturnedBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table height="150px" width="382px" cellpadding="0" cellspacing="0">
                                <tr style="visibility:hidden">
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Sales Return Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtSalesReturnedID"  runat="server"  Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%"> Vendor Name:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlVendor" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%"> Sales Return Date:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtSalesReturnDate" runat="server"  Width="25%" />
                                        <ajaxToolkit:CalendarExtender ID="ceSRtnDate" TargetControlID="txtSalesReturnDate" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvSalesReturnDate" ControlToValidate="txtSalesReturnDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgSRtn" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%"> Total Sales Return Amount:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTotalSalesReturnAmount" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvTotalSalesReturnAmount" ControlToValidate="txtTotalSalesReturnAmount" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgSRtn" runat="server">
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
                                         <asp:RequiredFieldValidator ID="rfvTaxValue" ControlToValidate="txtTaxValue" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgSRtn" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Shipping and handling Cost:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtShippingHandlingCost" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvShippingHandlingCost" ControlToValidate="txtShippingHandlingCost" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgSRtn" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%"> Miscellaneous Cost:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtMiscCost" runat="server"  Width="25%" />
                                         <asp:RequiredFieldValidator ID="rfvMiscCost" ControlToValidate="txtMiscCost" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgSRtn" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%"> Sales Order Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlSalesOrderID" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%"> Is Active:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:CheckBox ID="cbIsActive" runat="server" />
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
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Submit" ValidationGroup="vgSRtn" OnClick="btnUpdate_Click" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" />
                </td>
            </tr>


        </table>

    </asp:Panel>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="StoreManagement.Admin.Sale" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Sales Order</asp:LinkButton>
                            </ContentTemplate>
                       </asp:UpdatePanel>

                    </td>
                </tr>
               
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="updateSalesOrder" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvSalesOrder" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="RowID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Sales Order" DataField="SalesOrderID" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Created Date" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="25%" />
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
    
       <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" BackColor="White" Height="269px" Width="400px" Style="display: none">
        <table width="100%" style="border: Solid 3px #337ab7; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
            <tr style="background-color: #337ab7">
                <td style="height: 12%; color: White; font-weight: bold; font-size: larger" align="center">sales Order Information</td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updateSalesOrderBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table height="150px" width="382px" cellpadding="0" cellspacing="0">
                            <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Sales Order Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtSalesOrderId" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Vendor Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtVendorId" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Sales Date:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtSalesDate" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">total Cost amount:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTotalCostAmount" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Total Sales Amount:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTotalSalesAmount" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Total Discount Amount:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTotalDiscountAmount" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Total Tax value:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTotalTaxValue" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Shipping and Handling Cost:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtShippingHandlingCost" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Miscellaneous Sales amount:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtMiscSalesCost" runat="server" Enabled="false" Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Is Active:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:CheckBox ID="chkboxIsActive" runat="server" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                              </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <tr>

                <td style="text-align: center; vertical-align: top">
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Submit" OnClick="btnUpdate_Click" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>


        </table>

    </asp:Panel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ItemPrice.aspx.cs" Inherits="StoreManagement.Admin.ItemPrice" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Item Price</asp:LinkButton>
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
                        <asp:UpdatePanel ID="updateItemPrice" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvItemPrice" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="ItemPriceID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Item ID" ItemStyle-CssClass="text_title" DataField="ItemID" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Name" ItemStyle-CssClass="text_title" DataField="ItemPrefix" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Cost Price" ItemStyle-CssClass="text_title" DataField="ItemCostPricePerUnit" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Sale Price" ItemStyle-CssClass="text_title" DataField="ItemSalePricePerUnit" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Discount Percentage" ItemStyle-CssClass="text_title" DataField="ItemDiscountPercentagePerUnit" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Window From" ItemStyle-CssClass="text_title" DataField="WindowFrom" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Window To" ItemStyle-CssClass="text_title" DataField="WindowTo" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Category Name" ItemStyle-CssClass="text_title"  DataField="CategoryName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Batch No" ItemStyle-CssClass="text_title" DataField="BatchNo" ItemStyle-Width="10%" />
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
                <td style="height: 12%; color: White; font-weight: bold; font-size: larger" align="center">Item Price Information</td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updateItemPriceBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table height="150px" width="382px" cellpadding="0" cellspacing="0">
                                <tr style="visibility:hidden">
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item Price Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtItemPriceId" runat="server"  Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Category Name:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item Name:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlItemName" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item Cost Price:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtCostPrice" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCostPrice" ControlToValidate="txtCostPrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgIPrice" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item Sale Price:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtSalePrice" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSalePrice" ControlToValidate="txtSalePrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgIPrice" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                 <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Discount(%):</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDiscount" ControlToValidate="txtDiscount" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgIPrice" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                 <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Discount From:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFrom" ControlToValidate="txtFrom" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgIPrice" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                 <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Discount To:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTo" ControlToValidate="txtTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgIPrice" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                 <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Batch No:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtBatchNo" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvBatchNo" ControlToValidate="txtBatchNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgIPrice" runat="server">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 2%"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>


                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <tr>

                <td style="text-align: center; vertical-align: top">
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" ValidationGroup="vgIPrice" Text="Submit" OnClick="btnUpdate_Click" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel"  CausesValidation="false" runat="server" Text="Cancel" />
                </td>
            </tr>


        </table>

    </asp:Panel>
</asp:Content>

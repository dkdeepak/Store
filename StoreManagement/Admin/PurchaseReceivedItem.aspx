<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseReceivedItem.aspx.cs" Inherits="StoreManagement.Admin.PurchaseReceivedItem" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Purchase Received Item</asp:LinkButton>
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
                        <asp:UpdatePanel ID="updatePurchaseItemReceived" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvPurchaseItemReceived" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="PurchaseItemReceivedID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Purchase Received ID" ItemStyle-CssClass="text_title" DataField="PurchaseReceivedID" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Purchase Order ID" ItemStyle-CssClass="text_title" DataField="PurchaseOrderID" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Item Name" ItemStyle-CssClass="text_title" DataField="ItemPrefix" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Item Unit" ItemStyle-CssClass="text_title" DataField="ItemUnit" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Description" ItemStyle-CssClass="text_title" DataField="Description" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Item Price" ItemStyle-CssClass="text_title" DataField="ItemPrice" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Is Active" ItemStyle-CssClass="text_title" DataField="IsActive" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Created Date" ItemStyle-CssClass="text_title" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="25%" />
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
                <td style="height: 12%; color: White; font-weight: bold; font-size: larger" align="center">Purchased Item Received Information</td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updatePurchasedItemReceivedBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table height="150px" width="382px" cellpadding="0" cellspacing="0">

                             <tr style="visibility:hidden">
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Item Received Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtPurchaseItemReceivedID" runat="server"  Width="25%" />
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                            <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Received Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlPurchaseReceivedId" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>
                                
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Order Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                       <asp:DropDownList ID="ddlPurchaseOrderId" runat="server"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                       <asp:DropDownList ID="ddlItemId" runat="server" 
                                            onselectedindexchanged="ddlItemId_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item Unit:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtItemUnit" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Received Item description:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtDescription" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvDescription" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcvItem" runat="server">
                                        </asp:RequiredFieldValidator>

                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item price:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtItemPrice" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvItemPrice" ControlToValidate="txtItemPrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPRcvItem" runat="server">
                                        </asp:RequiredFieldValidator>
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
                                    <td><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                                </tr>
                                
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            
            <tr>

                <td style="text-align: center; vertical-align: top">
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" ValidationGroup="vgPRcvItem" Text="Submit" OnClick="btnUpdate_Click" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
                </td>
            </tr>


        </table>

    </asp:Panel>
</asp:Content>

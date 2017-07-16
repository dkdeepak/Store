<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderItem.aspx.cs" Inherits="StoreManagement.Admin.PurchaseOrderItem" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Purchase Order Item</asp:LinkButton>
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
                        <asp:UpdatePanel ID="updatePurchaseItemOrder" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                               <asp:GridView ID="dgvPurchaseItemOrder" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"  DataKeyNames="PurchaseOrderItemID"
                                    PagerStyle-CssClass="pgr">
                                    <Columns>
                                        <asp:BoundField HeaderText="Purchase Order ID" DataField="PurchaseOrderID" ItemStyle-Width="20%" />
                                         <asp:BoundField HeaderText="Item Name" DataField="ItemPrefix" ItemStyle-Width="20%" />
                                         <asp:BoundField HeaderText="Item Unit" DataField="ItemUnit" ItemStyle-Width="20%" />
                                         <asp:BoundField HeaderText="Description" DataField="Description" ItemStyle-Width="20%" />
                                         <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" ItemStyle-Width="20%" />
                                         <asp:BoundField HeaderText="Is Active" DataField="IsActive" ItemStyle-Width="20%" />
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

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" BackColor="White" Height="269px" Width="400px" Style="display: none">
        <table width="100%" style="border: Solid 3px #337ab7; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
            <tr style="background-color: #337ab7">
                <td style="height: 12%; color: White; font-weight: bold; font-size: larger" align="center">Purchased Item Order Information</td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updatePurchasedItemOrderBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table height="150px" width="382px" cellpadding="0" cellspacing="0">

                             <tr style="visibility:hidden">
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Purchase Item Order Id:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtPurchaseItemOrderID" runat="server"  Width="25%" />
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
                                    <td style="width: 35%">Purchase Order Item description:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"  Width="25%" />
                                        <asp:RequiredFieldValidator ID="rfvDescription" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPOItem" runat="server">
                                        </asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="revDescription" runat="server" ValidationGroup="vgPOItem" ForeColor="Red"
                                         ControlToValidate="txtDescription" ErrorMessage="Invalid entry" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td style="width: 2%"></td>

                                </tr>

                                <tr>
                                    <td style="width: 2%"></td>
                                    <td style="width: 35%">Item price:</td>
                                    <td style="width: 2%">:</td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtItemPrice" runat="server"  Width="25%" />
                                         <asp:RequiredFieldValidator ID="rfvItemPrice" ControlToValidate="txtItemPrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgPOItem" runat="server">
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
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Submit" ValidationGroup="vgPOItem" OnClick="btnUpdate_Click" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CausesValidation="false" />
                </td>
            </tr>


        </table>
        <asp:DropDownList ID="ss" runat="server"></asp:DropDownList>
    </asp:Panel>
</asp:Content>

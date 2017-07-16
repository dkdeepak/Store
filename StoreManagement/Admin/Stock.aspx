<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="StoreManagement.Admin.Stock" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr >
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Stock</asp:LinkButton>
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
                        <asp:UpdatePanel ID="updateStock" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvStock" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="StockID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Item Prefix" ItemStyle-CssClass="text_title" DataField="ItemPrefix" ItemStyle-Width="20%" />
                                        <asp:BoundField HeaderText="Stock Quantity" ItemStyle-CssClass="text_title" DataField="StockQuantity" ItemStyle-Width="20%" />
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
                <div class="panel-heading">Category Information</div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="updateStockBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <div class="col-md-12">
                            <div class="row" style="visibility:hidden">
                                <div class="col-md-6">Stock Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtStockId" runat="server" CssClass="form-control" /></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">Item Id:</div>
                                <div class="col-md-6"><asp:DropDownList ID="ddlItemId" runat="server"></asp:DropDownList></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">Quantity:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvQuantity" ControlToValidate="txtQuantity" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgStock" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6"><asp:Button ID="btnUpdate" CssClass="form-control btn-primary" CommandName="Update" ValidationGroup="vgStock" runat="server" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-md-6"><asp:Button ID="btnCancel" runat="server" 
                                        CausesValidation="false" Text="Cancel" onclick="btnCancel_Click" CssClass="form-control btn-primary" /></div>
                            </div>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </asp:Panel>
    
</asp:Content>


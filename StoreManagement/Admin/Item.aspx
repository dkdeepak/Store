<%@ Page Title="Master| Item" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="StoreManagement.Admin.Item" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr > 
                    <td align="left"><h3 style="color:#2679b5;">Item</h3></td>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" runat="server" CssClass="btn btn-primary" OnClick="linkButton_Click"><span class="glyphicon glyphicon-pencil"></span>Add</asp:LinkButton>
                            </ContentTemplate>                            
                       </asp:UpdatePanel>

                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
     <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup"  DefaultButton="btnUpdate">
                    <asp:UpdatePanel ID="updateItemBdInfo"  runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
         <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                            <div class="col-lg-11 col-sm-10 col-md-10 col-xs-10">
                                Item Information
                            </div>
                            <div class="col-lg-1 col-sm-2 col-md-2 col-xs-2">
                                <asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="row" style="display:none">
                         <div class="col-lg-3">Item Id:</div>
                         <div class="col-lg-3">"><asp:TextBox ID="txtItemId" runat="server" CssClass="form-control" /></div>
                        <div class="col-lg-3">Item Price Id:</div>
                         <div class="col-lg-3"><asp:TextBox ID="txtItemPriceId" CssClass="form-control" runat="server"/></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtItemPrefix" placeholder="Enter Name" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvgItemPrefix" ControlToValidate="txtItemPrefix" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revItemPrefix" runat="server" ValidationGroup="vgItem" ForeColor="Red"
                             ControlToValidate="txtItemPrefix"
                             ErrorMessage="Invalid entry" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6">
                           <asp:TextBox ID="txtItemCode" placeholder="Enter Code" runat="server" CssClass="form-control" />
                           <asp:RequiredFieldValidator ID="rfvItemCode" ControlToValidate="txtItemCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                           </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtBarcode" placeholder="Enter BarCode" runat="server"  CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvBarcode" ControlToValidate="txtBarcode" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtItemDecription" placeholder="Enter Discription" runat="server"  CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvItemDecription" ControlToValidate="txtItemDecription" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="revItemDiscription" runat="server" ControlToValidate="txtItemDecription" ValidationGroup="vgItem"  ForeColor="Red"
                                         ErrorMessage="Invalid entry" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6"> 
                                <asp:DropDownList ID="ddlItemUnitId" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvItemUnitId" ControlToValidate="ddlItemUnitId" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlCategoryId" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCategoryId" ControlToValidate="ddlCategoryId" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                            
                        </div>
                    </div>
<%--                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtCostPrice" CssClass="form-control" placeholder="Enter Cost Price" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCostPrice" ControlToValidate="txtCostPrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtSalePrice" CssClass="form-control" placeholder="Enter Sale Price" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSalePrice" ControlToValidate="txtSalePrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtItemDiscountPerUnit" CssClass="form-control" placeholder="Enter Discount per Unit" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvItemDiscountPerUnit" ControlToValidate="txtItemDiscountPerUnit" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-6">
                             <asp:TextBox ID="txtBatchNo" runat="server" CssClass="form-control" placeholder="Enter Batch No"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvBatchNo" ControlToValidate="txtBatchNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6"> 
                            <asp:TextBox ID="txtFrom" CssClass="form-control" placeholder="Select Discount Date From" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFrom" runat="server"></ajaxToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="rfvFrom" ControlToValidate="txtFrom" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                           <asp:TextBox ID="txtTo" CssClass="form-control" placeholder="Select Discount Date To" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtTo" runat="server"></ajaxToolkit:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfvTo" ControlToValidate="txtTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItem" runat="server">
                                        </asp:RequiredFieldValidator>

                        </div>
                    </div>
                    --%>
                    <div class="row">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3"><asp:Button ID="btnUpdate"   CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgItem" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-lg-3"><asp:Button ID="btnCancel"  CssClass="form-control btn-primary"  
                                        runat="server" Text="Cancel" CausesValidation="false" 
                                        onclick="btnCancel_Click" />
                                </div>
                                <div class="col-lg-3"></div>
                            </div>
     
                </div>
            </div>
        </div>
                                </ContentTemplate>
                    </asp:UpdatePanel>
    </asp:Panel>          
</asp:Content>
<asp:Content ID="cnt2" runat="server" ContentPlaceHolderID="cphData">
    <asp:UpdatePanel ID="updateItem" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
    <%-- <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>--%>
                            <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ItemID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Item Name" ItemStyle-CssClass="text_title" DataField="ItemPrefix" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Code" ItemStyle-CssClass="text_title" DataField="ItemCode" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Bar code" ItemStyle-CssClass="text_title" DataField="Barcode" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Description" ItemStyle-CssClass="text_title" DataField="ItemDescription" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Unit Name" ItemStyle-CssClass="text_title" DataField="UnitName" ItemStyle-Width="10%" />                                                                               
                                        <%--<asp:BoundField HeaderText="Item Cost Price Per Unit" ItemStyle-CssClass="text_title" DataField="ItemCostPricePerUnit" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Sale Price Per Unit" ItemStyle-CssClass="text_title" DataField="ItemSalePricePerUnit" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Item Discount Percentage Per Unit" ItemStyle-CssClass="text_title" DataField="ItemDiscountPercentagePerUnit" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Window From" ItemStyle-CssClass="text_title" DataField="WindowFrom" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Window To" ItemStyle-CssClass="text_title" DataField="WindowTo" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />                                        
                                        <asp:BoundField HeaderText="Batch No" ItemStyle-CssClass="text_title" DataField="BatchNo" ItemStyle-Width="10%" />                                        --%>

                                        <asp:BoundField HeaderText="Category Name" ItemStyle-CssClass="text_title" DataField="CategoryName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Created Date" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="10%" />
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">                                           
                                         <ItemTemplate>
                                                <asp:ImageButton ID="imgbtn" ImageUrl="~/Images/edit.png" runat="server" Width="25" Height="25" OnClick="imgbtn_Click" />                                       
                                                 </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">                                            
                                        <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnfrDelete" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" ImageUrl="~/Images/delete.png" runat="server" Width="20" Height="20" OnClick="imgbtnfrDelete_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

<%--        </Content>
        </ajaxToolkit:AccordionPane>
    </Panes>
    </ajaxToolkit:Accordion>--%>
                                </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ItemPrice.aspx.cs" Inherits="StoreManagement.Admin.ItemPrice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <asp:Button ID="btnShowBatch"  runat="server" Style="display: none" />
    <asp:Button ID="btnShowForm"  runat="server" Style="display: none" />
<ajaxToolkit:ModalPopupExtender ID="mpopBatch" runat="server" TargetControlID="btnShowBatch" PopupControlID="pnlBatch"
    CancelControlID="ibtnCloseBatch" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlBatch" runat="server" CssClass="modalPopup"  >
   <asp:UpdatePanel ID="upBatch" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="col-md-12">
        <div class="panel panel-default">
                <div class="panel-heading">
                    <table width="100%">
                            <tr>
                                <td align="left"><b>Select Batch</b></td>
                                <td align="right"><asp:LinkButton ID="ibtnCloseBatch" Font-Bold="true" Font-Size="Large" runat="server" OnClick="ibtnCloseBatch_Click" >X</asp:LinkButton></td>
                            </tr>
                        </table>
                </div>
                 <div class="panel-body">
                     <asp:GridView ID="dgvBatch" runat="server" AutoGenerateColumns="false" OnRowDeleting="dgvBatch_RowDeleting" Width="100%" CssClass="table table-striped table-bordered table-hover" >
                        <Columns>
                            <asp:BoundField HeaderText="Batch No" ItemStyle-CssClass="text_title" DataField="BatchNo" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Item Name" ItemStyle-CssClass="text_title" DataField="ItemPrefix" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="10%" />
                            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">                                            
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfItemPriceId" runat="server" Value='<%#Eval("ItemPriceID") %>' />
                                    <asp:ImageButton ID="imgbtnfrDelete"  ImageUrl="~/Images/select.png" runat="server" CommandName="Delete" Width="20" Height="20"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </div>
            </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mpopForm" runat="server" TargetControlID="btnShowForm" PopupControlID="pnlForm"
    CancelControlID="ibtnCloseForm" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlForm" runat="server" CssClass="modalPopup"  >
   <asp:UpdatePanel ID="upForm" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="col-md-12">
        <div class="panel panel-primary">
                <div class="panel-heading">
                    <table width="100%">
                            <tr>
                                <td align="left"><b>Item Price</b></td>
                                <td align="right"><asp:LinkButton ID="ibtnCloseForm" Font-Bold="true" ForeColor="White" Font-Size="Large" runat="server" OnClick="ibtnCloseForm_Click" >X</asp:LinkButton></td>
                            </tr>
                       </table>
                </div>   
                  <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtSP" CssClass="form-control required"  runat="server"  placeholder="Enter the sale price "></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtSP" ControlToValidate="txtSP" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItemPrice" runat="server">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtDisPerUnit" CssClass="form-control"  runat="server"  placeholder="Enter the discount % per unit"></asp:TextBox>

                        </div>
                    </div>
            <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtApplicableFrom" CssClass="form-control" runat="server"  placeholder="Enter The Date"></asp:TextBox>
                            <%-- <ajaxToolkit:CalendarExtender ID="cal1" TargetControlID="txtApplicableFrom" runat="server"></ajaxToolkit:CalendarExtender> --%>
                        </div>
                    </div>
                      <br />
                     <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtApplicableTo" CssClass="form-control" runat="server"  placeholder="Enter the Date"></asp:TextBox>
                            <%-- <ajaxToolkit:CalendarExtender ID="cal2" TargetControlID="txtApplicableTo" runat="server"></ajaxToolkit:CalendarExtender> --%>
                        </div>
                    </div>
                      <br />
                    <div class="row">
                        <div class="col-md-6">
                             <asp:HiddenField ID="hfItemPriceId" runat="server"  />
                             <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="form-control btn-primary" />
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="form-control btn-danger" />
                        </div>
                    </div>
                 </div>
            </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

  
</asp:Content>
<asp:Content ID="con4" runat="server" ContentPlaceHolderID="cphData">
    <asp:UpdatePanel ID="upData" runat="server">
        <ContentTemplate>

        
    <asp:GridView ID="dgvItem" runat="server" OnRowDeleting="dgvItem_RowDeleting" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ItemID">
        <Columns>
            <asp:BoundField HeaderText="Item Name" ItemStyle-CssClass="text_title" DataField="ItemPrefix" ItemStyle-Width="10%" />
            <asp:BoundField HeaderText="Item Code" ItemStyle-CssClass="text_title" DataField="ItemCode" ItemStyle-Width="10%" />
            <asp:BoundField HeaderText="Bar code" ItemStyle-CssClass="text_title" DataField="Barcode" ItemStyle-Width="10%" />
            <asp:BoundField HeaderText="Item Unit Name" ItemStyle-CssClass="text_title" DataField="UnitName" ItemStyle-Width="10%" />
            <asp:BoundField HeaderText="Category Name" ItemStyle-CssClass="text_title" DataField="CategoryName" ItemStyle-Width="10%" />
            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">                                            
                <ItemTemplate>
                    <asp:HiddenField ID="hfItemId" runat="server" Value='<%# Bind("ItemID") %>' />
                    <asp:ImageButton ID="imgbtnfrDelete"  ImageUrl="~/Images/select.png" CommandName="Delete" runat="server" Width="20" Height="20"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

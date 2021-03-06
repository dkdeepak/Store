﻿<%@ Page Title="Master|Category" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="StoreManagement.Admin.Category" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
 <div style="width: 100%">
        <div>
            <asp:HiddenField ID="rid" runat="server" />
            <table style="width: 100%">
                <tr>
                    <td align="left"><h3 style="color:#2679b5;">Category</h3></td>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" CssClass="btn btn-primary" runat="server" OnClick="linkButton_Click"><span class="glyphicon glyphicon-pencil"></span>Add</asp:LinkButton>
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
       <asp:UpdatePanel ID="updateCategoryBdInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-12">
            <div class="panel panel-primary">
                    <div class="panel-heading">
                        <table width="100%">
                                <tr>
                                    <td align="left">Category Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                    </div>
                    <div class="panel-body">
                            <div class="col-md-12">
                            <div class="row" style="display:none">
                                <div class="col-md-6">Category Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtCategoryId" runat="server" CssClass="form-control required" /></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                <asp:TextBox ID="txtCategoryName" placeholder="Enter Category Name"  ToolTip="Category Name"  runat="server" CssClass="form-control required" />
                                <asp:RequiredFieldValidator ID="rfvtCategoryName" ControlToValidate="txtCategoryName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCat" runat="server">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCategory" runat="server"
                                                         ControlToValidate="txtCategoryName" ValidationGroup="vgCat" ErrorMessage="Invalid entry"
                                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator></div>
                            </div>
                            <div class="row" style="display:block">
                                <div class="col-md-2">
                                    <asp:CheckBox ID="cbParant" runat="server" OnCheckedChanged="cbParant_CheckedChanged" AutoPostBack="true" />Parent
                                </div>
                                <div class="col-md-12" id="divCategory" runat="server">
                                    <asp:DropDownList ID="ddlCategory"  runat="server" CssClass="form-control ddl"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6"><asp:Button ID="btnUpdate"  CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgCat" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-md-6"><asp:Button ID="btnCancel" CssClass="form-control btn-primary"  
                                        runat="server" Text="Cancel" CausesValidation="false" 
                                        onclick="btnCancel_Click" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
<asp:Content ID="con" ContentPlaceHolderID="cphData" runat="server">
    <asp:UpdatePanel ID="updateCategory" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                            <%--<ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>
         --%>

                                
                                <asp:GridView ID="dgvCategory" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="CategoryID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Category Name" DataField="CategoryName" ItemStyle-Width="25%"  ItemStyle-CssClass="text_title"/>
                                        <asp:BoundField HeaderText="Parent Category Name" DataField="ParentCategory" ItemStyle-Width="25%"  ItemStyle-CssClass="text_title"/>
                                        <asp:BoundField HeaderText="Created Date" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="25%" />
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
   
    <%--     </Content>
         </ajaxToolkit:AccordionPane>
         </Panes>
         </ajaxToolkit:Accordion>--%>
         
                            </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

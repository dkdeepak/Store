<%@ Page Title="Master|Item Unit" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ItemUnit.aspx.cs" Inherits="StoreManagement.Admin.ItemUnit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
   <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr > 
                    <td align="left"><h3 style="color:#2679b5;">Item Unit</h3></td>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" CssClass="btn btn-primary" runat="server" OnClick="linkButton_Click"><span class="glyphicon glyphicon-pencil"></span> Add</asp:LinkButton>
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
      <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup"   DefaultButton="btnUpdate">
           <asp:UpdatePanel ID="updateItemUnitBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                   
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                     <table width="100%">
                                <tr>
                                    <td align="left">Item Unit Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                </div>
                <div class="panel-body">
                        <div class="col-md-12">
                            <div class="row" style="display:none">
                                <div class="col-md-6">Unit Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtUnitId" runat="server" CssClass="form-control" /></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlCategory" CssClass="form-control" ToolTip="Category" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCategory" ControlToValidate="ddlCategory" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItemUnit" runat="server">
                                        </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                <asp:TextBox ID="txtUnitName" placeholder="Enter Unit Name" ToolTip="Unit Name" runat="server"  CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvUnitName" ControlToValidate="txtUnitName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgItemUnit" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revUnitName" runat="server" ValidationGroup="vgItemUnit" ForeColor="Red"
                                         ControlToValidate="txtUnitName" ErrorMessage="Invalid entry" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                                </div>
                            <//div>
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
<asp:Content ID="cnt3" ContentPlaceHolderID="cphData" runat="server">
    <asp:UpdatePanel ID="updateItemUnit" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
       <%--  <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>--%>
          
        <asp:GridView ID="dgvItemUnit" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="UnitID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Item Unit Name" ItemStyle-CssClass="text_title" DataField="UnitName" ItemStyle-Width="20%" />                                       
                                        <asp:BoundField HeaderText="Category Name" ItemStyle-CssClass="text_title" DataField="CategoryName" ItemStyle-Width="20%" />
                                        <asp:BoundField HeaderText="Created Date" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="20%" />
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
  
           <%-- </Content>
        </ajaxToolkit:AccordionPane>
    </Panes>
    </ajaxToolkit:Accordion>--%>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
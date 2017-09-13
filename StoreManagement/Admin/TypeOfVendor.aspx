<%@ Page Title="Master|Type of User" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TypeOfVendor.aspx.cs" Inherits="StoreManagement.Admin.TypeOfVendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
 <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr >
                    <td align="left"><h3 style="color:#2679b5;">Type of Vendor</h3></td>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" CssClass="btn btn-primary" runat="server" OnClick="linkButton_Click"><span class="glyphicon glyphicon-pencil"></span>Add
                                </asp:LinkButton>
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
        <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" DefaultButton="btnUpdate">
          <asp:UpdatePanel ID="updateTypeofUserBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                   
            <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <table width="100%">
                                <tr>
                                    <td align="left">Type Of Vendor Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                   
                </div>
                <div class="panel-body">
                        <div class="col-md-12">
                            <div class="row" style="display:none">
                                <div class="col-md-6">Type of Vendor Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtTypeofVendorId" runat="server" /></div>
                            </div>

                            <div class="row">
                                <div class="col-md-12"> <asp:TextBox ID="txtTypeofVendorName" ToolTip="Type Of User" placeholder="Enter Type of User Name" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvTypeofVendorName" ControlToValidate="txtTypeofVendorName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgTVendor" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revTypeofVendorName" runat="server" ValidationGroup="vgTVendor" ForeColor="Red" ControlToValidate="txtTypeofVendorName" ErrorMessage="Invalid entry"
                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6"> <asp:Button ID="btnUpdate" CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgTUser" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-md-6"><asp:Button ID="btnCancel" CausesValidation="false" CssClass="form-control btn-primary" 
                                        runat="server" Text="Cancel" onclick="btnCancel_Click" /></div>
                            </div>
                            </div>
                      
                 </div>
             </div>
           </div>
                              </ContentTemplate>
                    </asp:UpdatePanel>
    </asp:Panel>
 </asp:Content>
<asp:Content ID="cnt2" ContentPlaceHolderID="cphData" runat="server">
    <asp:UpdatePanel ID="updateTypeofUser" runat="server" UpdateMode="Conditional">
<ContentTemplate>
       <%--      <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>--%>
    
        <asp:GridView ID="dgvTypeofVendor" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="TypeOfVendorID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Type of Vendor Name" ItemStyle-CssClass="text_title" DataField="TypeofVendorName" ItemStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Created Date" ItemStyle-CssClass="text_title" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="25%" />
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
               <%--                         </Content>
        </ajaxToolkit:AccordionPane>
    </Panes>
    </ajaxToolkit:Accordion>--%>
    
</ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>
<%@ Page Title="Master|Currency" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Currency.aspx.cs" Inherits="StoreManagement.Admin.Currency" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
 <div style="width: 100%">
        <div>
            <asp:HiddenField ID="rid" runat="server" />
            <table style="width: 100%">
                <tr>
                    <td align="left"><h3 style="color:#2679b5;">Currency</h3></td>
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
       <asp:UpdatePanel ID="updateCurrencyBdInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-12">
            <div class="panel panel-primary">
                    <div class="panel-heading">
                        <table width="100%">
                                <tr>
                                    <td align="left">Currency Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                    </div>
                    <div class="panel-body">
                            <div class="col-md-12">
                            <div class="row" style="display:none">
                                <div class="col-md-6">Currency Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtCurrencyId" runat="server" CssClass="form-control" /></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                <asp:TextBox ID="txtCurrencyName" placeholder="Enter Currency Name"  ToolTip="Currency Name"  runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvtCurrencyName" ControlToValidate="txtCurrencyName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCat" runat="server">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCurrency" runat="server"
                                                         ControlToValidate="txtCurrencyName" ValidationGroup="vgCat" ErrorMessage="Invalid entry"
                                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:FileUpload ID="fuSign" runat="server" CssClass="form-control" />
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
    <asp:UpdatePanel ID="updateCurrency" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                            <%--<ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>
         --%>


                                <asp:GridView ID="dgvCurrency" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="CurrencyID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Currency Name" DataField="CurrencyName" ItemStyle-Width="25%"  ItemStyle-CssClass="text_title"/>
                                        <asp:BoundField HeaderText="Parent Currency Name" DataField="ParentCurrency" ItemStyle-Width="25%"  ItemStyle-CssClass="text_title"/>
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

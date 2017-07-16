<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="StoreManagement.Admin.Vendor" %>
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
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click">Create New Vendor</asp:LinkButton>
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
                        
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" BackColor="White" Height="269px" Width="400px" Style="display: none" DefaultButton="btnUpdate">
         <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <table width="100%">
                                <tr>
                                    <td align="left">Vendor Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                    </div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="updateVendorBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <div class="col-md-12">
                            <div class="row" style="visibility:hidden">
                                <div class="col-md-6">Vendor  Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtVendorId" runat="server" CssClass="form-control" /></div>
                            </div>
                             <div class="row">
                                <div class="col-md-12"><asp:TextBox ID="txtVendorName" CssClass="form-control" placeholder="Enter Vendor Name" ToolTip="Vendor Name" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvVendorName" ControlToValidate="txtVendorName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendor" runat="server">
                                        </asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="revVendor" runat="server"
                                         ValidationGroup="vgVendor" ForeColor="Red" ControlToValidate="txtVendorName" ErrorMessage="Invalid entry"
                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator></div>
                            </div>
                            
                            <div class="row">
                                <div class="col-md-6"><asp:Button ID="btnUpdate"  CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgVendor" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-md-6"><asp:Button ID="btnCancel"  
                                        CssClass="form-control btn-primary" runat="server" CausesValidation="false" 
                                        Text="Cancel" onclick="btnCancel_Click" /></div>
                            </div>
                         </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
               

    </asp:Panel>
   
</asp:Content>
<asp:Content ID="cnt2" ContentPlaceHolderID="cphData" runat="server">
    <asp:UpdatePanel ID="updateVendor" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvVendor" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="VendorID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="25%" />
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
</asp:Content>
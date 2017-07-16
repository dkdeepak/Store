<%@ Page Title="Master| UserInfo" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="StoreManagement.Admin.UserInfo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
<link href="../Style/chekbox.css" rel="stylesheet" />
 <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr > <%--github.com--%>  
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click"><span class="glyphicon glyphicon-plus-sign"></span> New User</asp:LinkButton>
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
    <asp:Panel ID="pnlpopup" runat="server"   DefaultButton="btnUpdate">
         <asp:UpdatePanel ID="updateUserBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                   
         <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <table width="100%">
                                <tr>
                                    <td align="left">User Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>

                </div>
                <div class="panel-body">
                    <div class="row" style="display:none">
                         <div class="col-lg-6">User Id:</div>
                         <div class="col-lg-6"><asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" /></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                                <asp:TextBox ID="txtUserName" placeholder="Enter Name" ToolTip="User Name" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revUserName" runat="server"
                                         ValidationGroup="vgUserInfo" ForeColor="Red" ControlToValidate="txtUserName" ErrorMessage="Invalid entry"
                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>

                           </div>
                        <div class="col-lg-6">
                               <asp:TextBox ID="txtUserDisplayName" placeholder="Enter Display Name" ToolTip="User Display Name" runat="server" CssClass="form-control"/>
                                        <asp:RequiredFieldValidator ID="rfvUserDisplayName" ControlToValidate="txtUserDisplayName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revUserDisplayName" runat="server"
                                         ValidationGroup="vgUserInfo" ForeColor="Red" ControlToValidate="txtUserDisplayName" ErrorMessage="Invalid entry"
                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>

                           </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlTypeofUserID" CssClass="form-control" ToolTip="User Type" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvuserType" ControlToValidate="ddlTypeofUserID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtConcernPerson" placeholder="Enter Concern Person" ToolTip="Concern Person" runat="server" CssClass="form-control"/>
                                        <asp:RequiredFieldValidator ID="rfvConcernPerson" ControlToValidate="txtConcernPerson" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12"> 
                                <asp:TextBox ID="txtAddress" plceholder="Enter Address" ToolTip="Address" runat="server" TextMode="MultiLine" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvAddress" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlCountryID" CssClass="form-control" ToolTip="Country"   AutoPostBack="true" runat="server" 
                                            onselectedindexchanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCountryID" ControlToValidate="ddlCountryID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                             <asp:DropDownList ID="ddlStateID" CssClass="form-control" ToolTip="State" AutoPostBack="true" runat="server" 
                                            onselectedindexchanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvStateID" ControlToValidate="ddlStateID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlCityID" CssClass="form-control" ToolTip="City" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCityID" ControlToValidate="ddlCityID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                             <asp:TextBox ID="txtPinID" placeholder="Enter Pin No" ToolTip="Pin No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvPinID" ControlToValidate="txtPinID" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPinID" runat="server" ForeColor="Red" ErrorMessage="Invalid entry"
                                                                        ControlToValidate="txtPinID" ValidationExpression="\d{6}" ValidationGroup="vgUserInfo"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6"><asp:TextBox ID="txtMobileNo" ToolTip="Mobile No" placeholder="Enter Mobile No" runat="server" CssClass="form-control" />
                                         <asp:RequiredFieldValidator ID="rfvMobileNo" ControlToValidate="txtMobileNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                      <%--<asp:RegularExpressionValidator ID="rfvtxtMobileNo" runat="server" 
                                                         ControlToValidate="txtMobileNo" ErrorMessage="Invalid Mobile No" ForeColor="Red" ValidationGroup="vgUserInfo"
                                                         ValidationExpression="^(((0|((\+)?91(\-)?))|((\((\+)?91\)(\-)?)))?[789]\d{9})?$"></asp:RegularExpressionValidator>--%></div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtPhoneNo" placeholder="Enter Phone No" ToolTip="Phone No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvPhoneNo" ControlToValidate="txtPhoneNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtWebsiteAddress" placeholder="Enter Website Address" ToolTip="Website Address" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvWebsiteAddress" ControlToValidate="txtWebsiteAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtEmailID" placeholder="Enter Email" ToolTip="Email" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvEmailID" ControlToValidate="txtEmailID" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgUserInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revtxtEmailID" ControlToValidate="txtEmailID"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid EmailId" 
                                        ValidationGroup="vgUserInfo" runat="server"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                     <div class="row">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4 ">
                                   <div class="slideThree">	
	                                    <input type="checkbox" value="None" id="slideThree" name="check" />
	                                    <label for="slideThree"></label>
                                   </div>
                                    
                                    <asp:CheckBox ID="cbIsActive" CssClass="checkbox"  runat="server" /></div>
                                <div class="col-lg-4"></div>
                         </div>
                                 <div class="row">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3"><asp:Button ID="btnUpdate"   CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgUserInfo" Text="Submit" OnClick="btnUpdate_Click" /></div>
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
<asp:Content ID="cnt2" ContentPlaceHolderID="cphData" runat="server">
    <asp:UpdatePanel ID="updateUserInfo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                         <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>
    
                                <asp:GridView ID="dgvUserInfo" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="Grid"
                                    AlternatingRowStyle-CssClass="alt"
                                    PagerStyle-CssClass="pgr" DataKeyNames="UserID">
                                    <Columns>
                                        <asp:BoundField HeaderText="User Name" ItemStyle-CssClass="text_title" DataField="UserName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="User Display Name" ItemStyle-CssClass="text_title" DataField="UserDisplayName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Type of User ID" ItemStyle-CssClass="text_title" DataField="TypeofUserName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Address" ItemStyle-CssClass="text_title" DataField="Address" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="CountryID" ItemStyle-CssClass="text_title" DataField="CountryName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="StateID" ItemStyle-CssClass="text_title" DataField="StateName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="CityID" ItemStyle-CssClass="text_title" DataField="CityName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="PinID" ItemStyle-CssClass="text_title" DataField="PinID" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="ConcernPerson" ItemStyle-CssClass="text_title" DataField="ConcernPerson" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="PhoneNo" ItemStyle-CssClass="text_title" DataField="PhoneNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="MobileNo" ItemStyle-CssClass="text_title" DataField="MobileNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="E-mailID" ItemStyle-CssClass="text_title" DataField="EmailID" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="WebsiteAddress" ItemStyle-CssClass="text_title" DataField="WebsiteAddress" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Is Active" ItemStyle-CssClass="text_title" DataField="IsActive" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Created Date" ItemStyle-CssClass="text_title" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="5%" />
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
            </Content>
        </ajaxToolkit:AccordionPane>
    </Panes>
    </ajaxToolkit:Accordion>
    
                            </ContentTemplate>
                        </asp:UpdatePanel>
    
</asp:Content>
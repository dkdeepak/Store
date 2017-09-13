<%@ Page Title="Master|Vendor" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="VendorInfo.aspx.cs" Inherits="StoreManagement.Admin.VendorInfo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
<link href="../Style/chekbox.css" rel="stylesheet" />
 <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr > 
                    <td align="left"><h3 style="color:#2679b5;">Vendor</h3></td>
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
    <asp:Panel ID="pnlpopup" runat="server"   DefaultButton="btnUpdate">
         <asp:UpdatePanel ID="updateVendorBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                   
         <div class="col-lg-12">
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
                    <div class="row" style="display:none">
                         <div class="col-lg-6">Vendor Id:</div>
                         <div class="col-lg-6"><asp:TextBox ID="txtVendorID" runat="server" CssClass="form-control" /></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                                <asp:TextBox ID="txtVendorName" placeholder="Enter Name" ToolTip="Vendor Name" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvVendorName" ControlToValidate="txtVendorName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revVendorName" runat="server"
                                         ValidationGroup="vgVendorInfo" ForeColor="Red" ControlToValidate="txtVendorName" ErrorMessage="Invalid entry"
                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>

                           </div>
                        <div class="col-lg-6">
                               <asp:TextBox ID="txtVendorDisplayName" placeholder="Enter Display Name" ToolTip="Vendor Display Name" runat="server" CssClass="form-control"/>
                                        <asp:RequiredFieldValidator ID="rfvVendorDisplayName" ControlToValidate="txtVendorDisplayName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revVendorDisplayName" runat="server"
                                         ValidationGroup="vgVendorInfo" ForeColor="Red" ControlToValidate="txtVendorDisplayName" ErrorMessage="Invalid entry"
                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>

                           </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlTypeofVendorID" CssClass="form-control" ToolTip="Vendor Type" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvVendorType" ControlToValidate="ddlTypeofVendorID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtConcernPerson" placeholder="Enter Concern Person" ToolTip="Concern Person" runat="server" CssClass="form-control"/>
                                        <asp:RequiredFieldValidator ID="rfvConcernPerson" ControlToValidate="txtConcernPerson" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12"> 
                                <asp:TextBox ID="txtAddress" plceholder="Enter Address" ToolTip="Address" runat="server" TextMode="MultiLine" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvAddress" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlCountryID" CssClass="form-control" ToolTip="Country"   AutoPostBack="true" runat="server" 
                                            onselectedindexchanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCountryID" ControlToValidate="ddlCountryID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                             <asp:DropDownList ID="ddlStateID" CssClass="form-control" ToolTip="State" AutoPostBack="true" runat="server" 
                                            onselectedindexchanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvStateID" ControlToValidate="ddlStateID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlCityID" CssClass="form-control" ToolTip="City" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCityID" ControlToValidate="ddlCityID" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                             <asp:TextBox ID="txtPinID" placeholder="Enter Pin No" ToolTip="Pin No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvPinID" ControlToValidate="txtPinID" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPinID" runat="server" ForeColor="Red" ErrorMessage="Invalid entry"
                                                                        ControlToValidate="txtPinID" ValidationExpression="\d{6}" ValidationGroup="vgVendorInfo"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6"><asp:TextBox ID="txtMobileNo" ToolTip="Mobile No" placeholder="Enter Mobile No" runat="server" CssClass="form-control" />
                                         <asp:RequiredFieldValidator ID="rfvMobileNo" ControlToValidate="txtMobileNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                      <%--<asp:RegularExpressionValidator ID="rfvtxtMobileNo" runat="server" 
                                                         ControlToValidate="txtMobileNo" ErrorMessage="Invalid Mobile No" ForeColor="Red" ValidationGroup="vgVendorInfo"
                                                         ValidationExpression="^(((0|((\+)?91(\-)?))|((\((\+)?91\)(\-)?)))?[789]\d{9})?$"></asp:RegularExpressionValidator>--%></div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtPhoneNo" placeholder="Enter Phone No" ToolTip="Phone No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvPhoneNo" ControlToValidate="txtPhoneNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtWebsiteAddress" placeholder="Enter Website Address" ToolTip="Website Address" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvWebsiteAddress" ControlToValidate="txtWebsiteAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtEmailID" placeholder="Enter Email" ToolTip="Email" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="rfvEmailID" ControlToValidate="txtEmailID" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revtxtEmailID" ControlToValidate="txtEmailID"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid EmailId" 
                                        ValidationGroup="vgVendorInfo" runat="server"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtPanNo" placeholder="Enter PAN No" ToolTip="PAN No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPanNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtGstNo" placeholder="Enter GST No" ToolTip="GST No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtGstNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                        </div>
                    </div>

                     <div class="row">
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtServiceTaxNo" placeholder="Enter Service Tax No" ToolTip="Service Tax No" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtServiceTaxNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgVendorInfo" runat="server">
                                        </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 ">
                                   <div class="slideThree">	
	                                    <input type="checkbox" value="None" id="slideThree" name="check" />
	                                    <label for="slideThree"></label>
                                   </div>
                                    
                                    <asp:CheckBox ID="cbIsActive" CssClass="checkbox"  runat="server" /></div>
                         </div>
                                 <div class="row">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3"><asp:Button ID="btnUpdate"   CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgVendorInfo" Text="Submit" OnClick="btnUpdate_Click" /></div>
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
    <asp:UpdatePanel ID="updateVendorInfo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
       <%--                  <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>--%>
    
                                <asp:GridView ID="dgvVendorInfo" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="VendorID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Vendor Name" ItemStyle-CssClass="text_title" DataField="VendorName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Vendor Display Name" ItemStyle-CssClass="text_title" DataField="VendorDisplayName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Type of Vendor" ItemStyle-CssClass="text_title" DataField="TypeofVendorName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Address" ItemStyle-CssClass="text_title" DataField="Address" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Country" ItemStyle-CssClass="text_title" DataField="CountryName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="State" ItemStyle-CssClass="text_title" DataField="StateName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="City" ItemStyle-CssClass="text_title" DataField="CityName" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Pin" ItemStyle-CssClass="text_title" DataField="PinID" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="ConcernPerson" ItemStyle-CssClass="text_title" DataField="ConcernPerson" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="PhoneNo" ItemStyle-CssClass="text_title" DataField="PhoneNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="MobileNo" ItemStyle-CssClass="text_title" DataField="MobileNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="E-mailID" ItemStyle-CssClass="text_title" DataField="EmailID" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="WebsiteAddress" ItemStyle-CssClass="text_title" DataField="WebsiteAddress" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="PAN No" ItemStyle-CssClass="text_title" DataField="panNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="GST No" ItemStyle-CssClass="text_title" DataField="GstNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Service Tax No" ItemStyle-CssClass="text_title" DataField="ServiceTaxNo" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Is Active" ItemStyle-CssClass="text_title" DataField="IsActive" ItemStyle-Width="5%" />
                                        <asp:BoundField HeaderText="Created Date" ItemStyle-CssClass="text_title" DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="5%" />
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
         <%--   </Content>
        </ajaxToolkit:AccordionPane>
    </Panes>
    </ajaxToolkit:Accordion>--%>
    
                            </ContentTemplate>
                        </asp:UpdatePanel>
    
</asp:Content>
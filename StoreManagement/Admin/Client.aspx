<%@ Page Title="Master|Client" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="StoreManagement.Admin.Client" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../Style/chekbox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContain" runat="server">
    
    <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr >
                    <td align="left"><h3 style="color:#2679b5;">Client</h3></td>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" CssClass="btn btn-primary" runat="server" OnClick="linkButton_Click"> <span class="glyphicon glyphicon-pencil"></span>Add</asp:LinkButton>
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
    <asp:Panel ID="pnlpopup" runat="server"  DefaultButton="btnUpdate">
      <asp:UpdatePanel ID="updateClientBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                    
          <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <table width="100%">
                                <tr>
                                    <td align="left">Client Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                </div>
                <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="row" style="display:none">
                                <div class="col-lg-6">Client Id:</div>
                                <div class="col-lg-6"><asp:TextBox ID="txtClientId"  runat="server" CssClass="form-control" /></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                <asp:TextBox ID="txtClientName" placeholder="Enter Name" ToolTip="Client Name" runat="server" CssClass="form-control required" />
                                <asp:RequiredFieldValidator ID="rfvClientName" ControlToValidate="txtClientName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgClient" runat="server">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revClientName" runat="server" ValidationGroup="vgClient" ControlToValidate="txtClientName" ErrorMessage="Invalid entry" 
                                        ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-lg-6"><asp:TextBox ID="txtClientDisplayName" placeholder="Enter Dispaly Name" ToolTip="Client Dispaly Name" runat="server" CssClass="form-control" />
                                         <asp:RequiredFieldValidator ID="rfvClientDisplayName" ControlToValidate="txtClientDisplayName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgClient" runat="server">
                                        </asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="revClientDisplayName" runat="server" ValidationGroup="vgClient" ControlToValidate="txtClientDisplayName" ErrorMessage="Invalid entry" 
                                        ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12"><asp:TextBox ID="txtAddress" placeholder="Enter Address" ToolTip="Address" TextMode="MultiLine" runat="server" CssClass="form-control required"/>
                                        <asp:RequiredFieldValidator ID="rfvAddress" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgClient" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="ddlCountry" AutoPostBack="true" CssClass="form-control required ddl" ToolTip="Country"
                                         onselectedindexchanged="ddlCountryID_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="rfvCountry" ControlToValidate="ddlCountry" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgDistrict" runat="server">
                                        </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="ddlState" AutoPostBack="true" CssClass="form-control required ddl" ToolTip="State" 
                                        onselectedindexchanged="ddlStateID_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgDistrict" runat="server">
                                        </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="ddlCity" CssClass="form-control required ddl" runat="server" ToolTip="City"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="ddlCity" InitialValue="0" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgDistrict" runat="server">
                                        </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6"><asp:TextBox ID="txtPinId" ToolTip="Pin No" placeholder="Enter Pin No" runat="server" CssClass="form-control required ddl" />
                                        <asp:RequiredFieldValidator ID="rfvPinId" ControlToValidate="txtPinId" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgClient" runat="server">
                                        </asp:RequiredFieldValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4 ">
                                   <div class="slideThree">	
	                                    <input type="checkbox" value="None"  id="slideThree" name="check" />
	                                    <label for="slideThree"></label>
                                   </div>
                                    
                                    <asp:CheckBox ID="cbIsActive" CssClass="checkbox"  runat="server" /></div>
                                <div class="col-lg-4"></div>
                            </div>
                            <div class="row">&nbsp;</div>
                            <div class="row">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3"><asp:Button ID="btnUpdate"   CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgCat" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-lg-3"><asp:Button ID="btnCancel"  CssClass="form-control btn-primary"  
                                        runat="server" Text="Cancel" CausesValidation="false" 
                                        onclick="btnCancel_Click" />
                                </div>
                                <div class="col-lg-3"></div>
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
    <asp:UpdatePanel ID="updateClient" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="dgvClient" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ClientID">
                                    <Columns>
                                        <asp:BoundField HeaderText="Client Name" ItemStyle-CssClass="text_title" DataField="ClientName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Client Display Name" ItemStyle-CssClass="text_title" DataField="ClientDisplayName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Address" ItemStyle-CssClass="text_title" DataField="Address" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Country Name" ItemStyle-CssClass="text_title" DataField="CountryName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="State Name" ItemStyle-CssClass="text_title" DataField="StateName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="City Name" ItemStyle-CssClass="text_title" DataField="CityName" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Pin ID" ItemStyle-CssClass="text_title" DataField="PinID" ItemStyle-Width="10%" />
                                        <asp:BoundField HeaderText="Is Active" DataField="IsActive" ItemStyle-Width="10%" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

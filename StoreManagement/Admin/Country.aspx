<%@ Page Title="Master|Country" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="StoreManagement.Admin.Country" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validatorCalloutHighlight
{
    background-color: lemonchiffon;
    display:inline;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContain" runat="server">
     <div style="width: 100%">
        <div>
            <table style="width: 100%">
                <tr >
                    <td align="left"><h3 style="color:#2679b5;">Country</h3></td>
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
                  <asp:UpdatePanel ID="updateCountryBdInfo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                    <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                            <table width="100%">
                                <tr>
                                    <td align="left">Country Information</td>
                                    <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>
                                </tr>
                            </table>
                   
                </div>
                <div class="panel-body">
                        <div class="col-md-12">
                            <div class="row" style="display:none">
                                <div class="col-md-6">Country Id::</div>
                                <div class="col-md-6"><asp:TextBox ID="txtCountryId" runat="server" CssClass="form-control"/></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                <asp:TextBox ID="txtCountry" runat="server" ToolTip="Country Name" placeholder="Enter Country Name"  CssClass="form-control"/>
                                        <%--<asp:RequiredFieldValidator ID="rfvCountry" ControlToValidate="txtCountry" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCountry" runat="server">
                                        </asp:RequiredFieldValidator>--%>
                                         <asp:RegularExpressionValidator ID="revCountry" runat="server" ValidationGroup="vgCountry" ForeColor="Red"  ControlToValidate="txtCountry" ErrorMessage="Invalid entry" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator runat="server" ID="NReq"
                                            ControlToValidate="txtCountry" ValidationGroup="vgCountry"
                                                Display="None"
                                                ErrorMessage="<b>Required Field Missing</b><br />A name is required." />
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="NReqE"
                                                TargetControlID="NReq"
                                                HighlightCssClass="validatorCalloutHighlight" />
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
<asp:Content ID="cnt3" ContentPlaceHolderID="cphData" runat="server">
    <asp:UpdatePanel ID="updateCountry" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <%--<ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
        <ajaxToolkit:AccordionPane ID="acdFaq2" runat="server">
            <Header><a href="" class="accordionLink">View Data</a></Header>
            <Content>--%>
    
                 <asp:GridView ID="dgvCountry" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" Width="100%" 
                                    DataKeyNames="CountryID">
                                    
                                    <Columns>
                                        <asp:BoundField HeaderText="Country Name" DataField="CountryName" ItemStyle-CssClass="text_title" ItemStyle-Width="25%" />
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
    <%-- </Content>
        </ajaxToolkit:AccordionPane>
    </Panes>
    </ajaxToolkit:Accordion>  --%>      
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
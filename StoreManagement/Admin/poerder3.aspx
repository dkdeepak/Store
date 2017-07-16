<%@ Page Title="Master|Category" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="poerder3.aspx.cs" Inherits="StoreManagement.Admin.poerder3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style>
      autocomplete_completionListElement
    {
        margin: 0px !important;
        z-index:99999 !important;
        background-color: ivory;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        border-style: solid;
        cursor: 'default';
        overflow: auto;
        height: 200px;
        text-align: left;
        left: 0px;
        list-style-type: none;
    }
    /* AutoComplete highlighted item */
    .autocomplete_highlightedListItem
    {
        z-index:99999 !important;
        background-color: #ffff99;
        color: black;
        padding: 1px;
        cursor:hand;
    }
    /* AutoComplete item */
    .autocomplete_listItem
    {
        z-index:99999 !important;
        background-color: window;
        color: windowtext;
        padding: 1px;
        cursor:hand;
    }
}
    </style>--%>
    <style>
            .autoCompleteList {
      list-style: none outside none;
      border: 5px solid #123456;
      cursor: pointer;
      padding: 5px;
      margin: 0px;
      z-index:1000 !important;
    }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
 <div style="width: 100%">
        <div>
            <asp:HiddenField ID="rid" runat="server" />
            <table style="width: 100%">
                <tr>
                    <td style="text-align: right"> 
                        <asp:Button ID="btnShowPopup"  runat="server" Style="display: none" /></td>
                    <td style="text-align: right">  
                      <asp:UpdatePanel runat="server" ID="UpdatePnl" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkButton" runat="server" OnClick="linkButton_Click"><span class="glyphicon glyphicon-plus-sign"></span> New Category</asp:LinkButton>
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
                            <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false"  GridLines="None" OnRowDataBound="Gridview1_RowDataBound">
            <HeaderStyle HorizontalAlign="Right" />
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtItemName" placeholder="Enter Item Name" ToolTip="Item Name"     runat="server"  CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" CompletionListCssClass="autoCompleteList"  MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="true">  
                </ajaxToolkit:AutoCompleteExtender>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDec" placeholder="Item Description" ToolTip="Item Description"  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" placeholder="Unit Price" ToolTip="Unit Price"  runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount(%)">
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtDisPre" runat="server" ToolTip="Discount(%)" placeholder="Discount(%)"  OnTextChanged="txtDisPre_TextChanged" AutoPostBack="true"  CssClass="form-control"  ></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:TextBox ID="txtDis" ToolTip="Discount" placeholder="Discount"   runat="server" CssClass="form-control" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server"  ToolTip="Quantity" placeholder="Quantity" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                     <asp:TextBox ID="txtTotal" ToolTip="Total" placeholder="Total" runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
                         <div class="row">
                                <div class="col-md-6"><asp:Button ID="btnUpdate"  CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgCat" Text="Submit" OnClick="btnUpdate_Click" /></div>
                                <div class="col-md-6"><asp:Button ID="btnCancel" CssClass="form-control btn-primary"  
                                        runat="server" Text="Cancel" CausesValidation="false" 
                                        onclick="btnCancel_Click" /></div>
                            </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
<asp:Content ID="con" ContentPlaceHolderID="cphData" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ItemPrice.aspx.cs" Inherits="StoreManagement.Admin.ItemPrice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
     <asp:HiddenField ID="hfPoderId" runat="server" />
    <asp:UpdatePanel ID="upSearch" runat="server">
     <ContentTemplate>
          <div class="panel panel-primary col-lg-4 col-md-4 col-sm-4 col-xm-4 col-lg-offset-4" id="divSerach" runat="server">
           <div class="panel-heading">Item Price Info</div>
                <div class="panel-body">
                    <asp:TextBox ID="txtPoId" runat="server" placeholder="Enter Purchase Received No" CssClass="form-control" ValidationGroup="serach"></asp:TextBox>
                    <br />    
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-control btn-primary" OnClick="btnSearch_Click" />
                </div>
               
          </div>
     </ContentTemplate>
        </asp:UpdatePanel>
    <asp:UpdatePanel ID="up1" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
       <div id="divForm" runat="server">
            <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" GridLines="None" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
                 <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName"  Text='<%# Bind("ItemPrefix") %>' runat="server"  CssClass="form-control"></asp:TextBox>
                    <asp:HiddenField ID="hfItemId" Value='<%# Bind("ItemID") %>'  runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sale Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtSalesPrice"   runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="WindowFrom">
                    <ItemTemplate>
                        <asp:TextBox ID="txtWindowFrom"   runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="windowfrom" runat="server" TargetControlID="txtWindowFrom"></ajaxToolkit:CalendarExtender>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="WindowTo">
                    <ItemTemplate>
                        <asp:TextBox ID="txtWindowTo"   runat="server" CssClass="form-control"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="windowTo" runat="server" TargetControlID="txtWindowTo"></ajaxToolkit:CalendarExtender>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Discount">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDiscount"   runat="server" CssClass="form-control"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>    
            </asp:gridview>
           <div class="row">
             
        <div class="col-lg-3"></div>


        <div class="col-lg-2"><asp:Button ID="Button1" Text="Submit" CssClass="form-control btn-primary" runat="server" OnClick="btnSubmit_Click" />
             
         </div>

              <div class="col-lg-2"><asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" 
               CssClass="form-control btn-danger" OnClick="btnCancel_Click" /></div>
        </div>
           <div class="row">
             
        <div class="col-lg-12"></div>
                <div class="col-lg-12"></div>
               </div>

           
           
            <%--<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="form-control" Text="Submit" />--%>
        </div>

       
       </ContentTemplate>

        </asp:UpdatePanel>

    
    </asp:Content>
<asp:Content ID="con4" runat="server" ContentPlaceHolderID="cphData">
    <asp:UpdatePanel id="up2"  runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvItemPrice"
            runat="server" 
            DataKeyNames="ItemPriceID" 
             AutoGenerateColumns="false"
             Width="80%"
            AllowPaging="True" PageSize="20" >
            <HeaderStyle CssClass="dataTable" />
            <RowStyle CssClass="dataTable" />
            <AlternatingRowStyle CssClass="dataTableAlt" />
            <Columns>
            <asp:TemplateField HeaderText="Item Name" >
        <ItemTemplate>            
           <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemPrefix") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Sales Price" >
        <ItemTemplate>            
           <asp:Label ID="lblsalesPrice" runat="server" Text='<%# Eval("ItemSalePricePerUnit") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

                <asp:TemplateField HeaderText="WindowFrom" >
        <ItemTemplate>            
           <asp:Label ID="lblWindowFrom" runat="server" Text='<%# Eval("WindowFrom") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="WindowTo" >
        <ItemTemplate>            
           <asp:Label ID="lblWindowTo" runat="server" Text='<%# Eval("WindowTo") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>


            </Columns>
            </asp:GridView>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>

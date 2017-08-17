<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StoreManagement.ReportSection.WebForm1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <asp:UpdatePanel id="up2"  runat="server">
        <ContentTemplate>
             <%--OnRowDataBound="gvPOrder_RowDataBound"--%>
            <asp:GridView ID="gvPOrder"            runat="server"
          
            DataKeyNames="PurchaseOrderID" 
             AutoGenerateColumns="false"
             Width="80%"
            AllowPaging="True" PageSize="20" >
            <HeaderStyle CssClass="dataTable" />
            <RowStyle CssClass="dataTable" />
            <AlternatingRowStyle CssClass="dataTableAlt" />
            <Columns>
            <asp:TemplateField  ItemStyle-HorizontalAlign="Center"  HeaderText="View">
            <ItemTemplate>
                <asp:ImageButton ID="imgbtn"  border="1"  width="20px" height="20px" ImageUrl="~/Images/view.png" OnClick="imgbtn_Click" runat="server" />
            </ItemTemplate>

</asp:TemplateField>



    <asp:TemplateField HeaderText="PurchaseOrderID">
        <ItemTemplate>            
           <asp:Label ID="lblpo" runat="server" Text='<%# Eval("PurchaseOrderID") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date of purchase" >
        <ItemTemplate>            
           <asp:Label ID="lblpdate" runat="server" Text='<%# Eval("PurchaseDate") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Purchase Amount" >
        <ItemTemplate>            
           <asp:Label ID="lblamt" runat="server" Text='<%# Eval("PurchaseAmount") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Tax value" >
        <ItemTemplate>            
           <asp:Label ID="lbltax" runat="server" Text='<%# Eval("TaxValue") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Shipping & Handling Cost" >
        <ItemTemplate>            
           <asp:Label ID="lblshc" runat="server" Text='<%# Eval("ShipingAndHandlingCost") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText=" Miscellaneous Cost" >
        <ItemTemplate>            
           <asp:Label ID="lblMiscCost" runat="server" Text='<%# Eval("MiscCost") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Discount Amount" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Discount(%)" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscountPre" runat="server" Text='<%# Eval("DiscountPre") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>


</Columns>
</asp:GridView>
            <asp:Panel ID="pnl" Visible="false" GroupingText="purchase info" runat="server" >
               <asp:GridView ID="gv1"  runat="server" >
                                <Columns>
                                    <asp:TemplateField HeaderText="PurchaseOrderItemID">
        <ItemTemplate>            
           <asp:Label ID="lblpo" runat="server" Text='<%# Eval("PurchaseOrderItemID") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PurchaseOrderID" >
        <ItemTemplate>            
           <asp:Label ID="lblpdate" runat="server" Text='<%# Eval("PurchaseOrderID") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ItemID" >
        <ItemTemplate>            
           <asp:Label ID="lblamt" runat="server" Text='<%# Eval("ItemID") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ItemUnit" >
        <ItemTemplate>            
           <asp:Label ID="lbltax" runat="server" Text='<%# Eval("ItemUnit") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" >
        <ItemTemplate>            
           <asp:Label ID="lblshc" runat="server" Text='<%# Eval("Description") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TotalPrice" >
        <ItemTemplate>            
           <asp:Label ID="lblMiscCost" runat="server" Text='<%# Eval("TotalPrice") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ItemPrice" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Discount%" >
        <ItemTemplate>            
           <asp:Label ID="lblDiscountPre" runat="server" Text='<%# Eval("DiscountPre") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                               </Columns>
                            </asp:GridView>
                        
            </asp:Panel>
                           
                        

        </ContentTemplate>

    </asp:UpdatePanel>
    
</asp:Content>

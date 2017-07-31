<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="StoreManagement.WebForm2" %>


<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    <div class="col-md-12">
        <div class="panel panel-primary">
                <div class="panel-heading">
                            <table width="100%">
                                <tr>
                                    <td align="left">purchase order Information</td>
                                   <%-- <td align="right"><asp:LinkButton ID="lbtnClose" ForeColor="White" Font-Bold="true" runat="server" OnClick="lbtnClose_Click" >X</asp:LinkButton></td>--%>
                                </tr>
                            </table>

                            <table width="100%">
                     <div class="panel-body">
                         <table width="100%">

                             <tr>
                                 <td>
          <asp:GridView ID="gv1"  runat="server"  DataKeyNames="PurchaseOrderID"   AutoGenerateColumns="false"  Width="80%">
              <HeaderStyle CssClass="dataTable" />
            <RowStyle CssClass="dataTable" />
            <AlternatingRowStyle CssClass="dataTableAlt" />
            <Columns>
            <asp:TemplateField>
                    <ItemTemplate>

                        <div class="row">
                                <div class="col-md-6">purchase order Id::</div>
                                <div class="col-md-6">
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("PurchaseOrderID") %>' CssClass="form-control" ></asp:Label>
                                </div>
                            </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="row">
                                <div class="col-md-6">PurchaseDate:</div>
                                <div class="col-md-6">
                                      <asp:Label ID="lblpdate" runat="server" Text='<%# Eval("PurchaseDate") %>' ></asp:Label>
                                </div>
                            </div>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                         <div class="row">
                                <div class="col-md-6">PurchaseAmount::</div>
                                <div class="col-md-6">
                                     <<asp:Label ID="lblamt" runat="server" Text='<%# Eval("PurchaseAmount") %>' ></asp:Label>
                                </div>
                            </div>

                    </ItemTemplate>
                </asp:TemplateField>

                
                </Columns>
         </asp:GridView>
                                 </td>
                                 <td></td>
                             </tr>
                         </table>
                         <table>
                             <tr>
                                 <td></td>
                             </tr>
                         </table>
                     </div>
                    </table>

                            <table width="100%">
                                <asp:GridView ID="gv2" runat="server">
                                    <Columns>
                                        <asp:TemplateField>
                    <ItemTemplate>
                         <div class="row">
                                <div class="col-md-6">ShipingAndHandlingCost:</div>
                                <div class="col-md-6">
                                     <asp:Label ID="lblshcost" runat="server" Text='<%# Eval("ShipingAndHandlingCost") %>' ></asp:Label>
                                </div>
                            </div>
                           
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                         <div class="row">
                                <div class="col-md-6">TaxValue:</div>
                                <div class="col-md-6">
                                     <asp:Label ID="lblMiscCost" runat="server" Text='<%# Eval("MiscCost") %>' ></asp:Label>
                                </div>
                            </div>
                           
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                         <div class="row">
                                <div class="col-md-6">Discount:</div>
                                <div class="col-md-6">
                                     <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>' ></asp:Label>
                                </div>
                            </div>
                           
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="row">
                                <div class="col-md-6">Discount(%):</div>
                                <div class="col-md-6">
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("DiscountPre") %>' ></asp:Label>
                                </div>
                            </div>

                    </ItemTemplate>
                </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </table>
                   
                </div>
            </div>     




    </div>
</asp:Content>

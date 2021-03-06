﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PROrder.aspx.cs" Inherits="StoreManagement.Admin.POrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function insertPorder() {
            debugger;
            var selectedRows = $('#cphContain_Gridview1 tr').length;
            if (selectedRows < 1) {
                $('.status').html("Please select any row").addClass("statusError").removeClass("statusSuc").fadeIn().fadeOut(1000);
            }
            
            else {
                debugger;
                var subTotal = $('#cphContain_txtSubTotal').val();
                var dicPre = $('#cphContain_txtDicPre').val();
                var dic = $('#cphContain_txtDic').val();
                var tax = $('#cphContain_txtTax').val();
                var sHC = $('#cphContain_txtSHC').val();
                var miscCost = $('#cphContain_txtMiscCost').val();
                var ttotal = $('#cphContain_txttotal').val();


                $(document).ajaxStart(function () {
                    $("#loading").show();
                });

                jsonpurchase = '{"subtotal":"' + subTotal + '", "dicpre":"' + dicPre + '", "dic":"' + dic + '", "tax":"' + tax + '", "shc":"' + sHC + '", "misccost":"' + miscCost + '", "ttotal":"' + ttotal + '"}';
                $.ajax({
                    type: "POST",
                    url: location.protocol + "//" + location.hostname + "/" + location.pathname + "/insertpurchase",
                    data: jsonpurchase,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                    },
                    error: function (xhr, status) {
                        console.log(status + " - " + xhr.responseText);
                    }
                });
                $(document).ajaxStop(function () {
                    $("#loading").hide();
                });

                $('#cphContain_Gridview1 tr').each(function (event) {

                    debugger;
                    var id = "";
                    if ($(this)[0].cells['0'].childNodes.length > 1 && $(this)[0].cells['0'].childNodes['0'].defaultValue != "") {


                        var Name = $(this)[0].cells['0'].childNodes['0'].defaultValue;
                        var Description = $(this)[0].cells['1'].childNodes['0'].defaultValue;
                        var unitprice = $(this)[0].cells['2'].childNodes['0'].defaultValue;
                        var discountper = $(this)[0].cells['3'].childNodes['0'].defaultValue;
                        var discount = $(this)[0].cells['4'].childNodes['0'].defaultValue;
                        var quantity = $(this)[0].cells['5'].childNodes['0'].defaultValue;
                        var total = $(this)[0].cells['6'].childNodes['0'].defaultValue;

                        jsonDataNew = '{"name":"' + Name + '", "description":"' + Description + '", "unitprice":"' + unitprice + '", "discountper":"' + discountper + '", "discount":"' + discount + '", "quantity":"' + quantity + '", "total":"' + total + '"}';



                        var urlname = location.protocol + "//" + location.hostname + "/" + location.pathname + "/insertdata";
                        $.ajax({
                            type: "POST",
                            url: "http://localhost/storemanagement/admin/POrder.aspx/insertda",
                            data: jsonDataNew,
                            type: "POST", // data has to be POSTed
                            contentType: "application/json", // posting JSON content    
                            dataType: "JSON",  // type of data is JSON (must be upper case!)
                            timeout: 100000,    // AJAX timeout
                            success: function (data) {
                                alert('Data Save!!!');
                                location.reload();

                                //  if ($("#cphContain_Gridview1 tr").length == 1) {

                                //$("#cphContain_Gridview1 tbody").append("<tr><td colspan = '4' align ='center'>Found Zero records!.</td></tr>")
                                //$("#cphContain_btnSubmit").prop("disabled", true);
                                // }
                            },
                            error: function (xmlHttpRequest, textStatus, errorThrown) {
                                console.log('Error');
                            }
                        });

                    }
                });
                $('.status').html(selectedRows + " Row(s) deleted sucessfully").addClass("statusSuc").removeClass("statusError").fadeIn().fadeOut(1000);
            }
        }

    </script>
    <style>
        .loading1 {background: #000 none repeat scroll 0 0;display: block; height: 3372px; left: 0;  max-width: 100%; opacity: 0.5;position: fixed;top: 0; width: 1903px; z-index: 10000;}

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
    
 <asp:UpdatePanel ID="up1" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
        <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <%--<asp:TemplateField HeaderText="ItemCode">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemCode" runat="server" CssClass="form-control" OnTextChanged="txtItemCode_TextChanged"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemCode"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName" runat="server" OnTextChanged="txtItemName_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
                </ajaxToolkit:AutoCompleteExtender>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDec" runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount(%)">
                <ItemTemplate>
                   
                    <asp:TextBox ID="txtDisPre" runat="server" OnTextChanged="txtDisPre_TextChanged"  CssClass="form-control" AutoPostBack="true" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:TextBox ID="txtDis" runat="server" CssClass="form-control" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                     <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        
        <div >
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblSubTotal" Font-Bold="true" runat="server" Text="Sub Total"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtSubTotal" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblDicPre" Font-Bold="true" runat="server" Text="Discount(%)"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtDicPre" runat="server" AutoPostBack="true" OnTextChanged="txtDicPre_TextChanged1"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblDic" Font-Bold="true" runat="server" Text="Discount"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtDic" runat="server" ></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblTax" Font-Bold="true" runat="server" Text="Tax(%)"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtTax" runat="server" ></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblSHC" Font-Bold="true" runat="server" Text="Shiping And Handling Cost"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtSHC" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblMiscCost" Font-Bold="true" runat="server" Text="Misc Cost"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtMiscCost"  runat="server" AutoPostBack="true" OnTextChanged="txtMiscCost_TextChanged"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblTotal" Font-Bold="true" runat="server" Text="Total"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txttotal" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Button ID="btnSubmit" Text="Submit" CausesValidation="false" OnClientClick="javascript:insertPorder();"  runat="server" 
                CssClass="btn-info"  /></div>
        <div class="col-lg-4"></div>
        <div class="col-lg-5"></div>
</div>
        <div>
            <div id="loading" style="display:none;" runat="server" class="loading1"></div>
        </div>
</div>
    
    


    </ContentTemplate>
     <Triggers>
         <asp:AsyncPostBackTrigger ControlID ="Gridview1" />
         <asp:AsyncPostBackTrigger ControlID="txtDicPre" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtMiscCost" EventName="TextChanged" />
         
     </Triggers>
  </asp:UpdatePanel>      

<br />
<%--<asp:UpdatePanel ID="up2" UpdateMode="Conditional" runat="server">
    
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtDicPre" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtMiscCost" EventName="TextChanged" />

    </Triggers>
</asp:UpdatePanel>--%>
    <asp:HiddenField ID="hfpo" Value="0"  runat="server" />
    <asp:Label ID="lbl1" runat="server"></asp:Label>
</asp:Content>
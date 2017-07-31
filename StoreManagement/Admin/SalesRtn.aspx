<%@ Page Title="TRANSACTION| Sales Return" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesRtn.aspx.cs" Inherits="StoreManagement.Admin.SalesRtn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
  <%--<script type="text/javascript">
      function insertPorder() {
          debugger;
          var selectedRows = $('#cphContain_Gridview1 tr').length;
          if (selectedRows < 1) {
              $('.status').html("Please select any row").addClass("statusError").removeClass("statusSuc").fadeIn().fadeOut(1000);
          }

          else {
              debugger;
              var tax = $('#cphContain_txtTax').val();
              var sHC = $('#cphContain_txtSHC').val();
              var miscCost = $('#cphContain_txtMiscCost').val();
              var ttotal = $('#cphContain_txtSubTotal').val();


              $(document).ajaxStart(function () {
                  $("#loading").show();
              });

              jsonpurchase = '{"tax":"' + tax + '", "shc":"' + sHC + '", "misccost":"' + miscCost + '", "ttotal":"' + ttotal + '"}';
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
                      var quantity = $(this)[0].cells['4'].childNodes['0'].defaultValue;
                      jsonDataNew = '{"name":"' + Name + '", "description":"' + Description + '", "unitprice":"' + unitprice + '", "quantity":"' + quantity + '"}';



                      var urlname = location.protocol + "//" + location.hostname + "/" + location.pathname + "/insertdata";
                      $.ajax({
                          type: "POST",
                          url: "http://localhost/storemanagement/admin/SalesRtn.aspx/insertda",
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

    </script>--%>
    <style>
        .loading1 {background: #000 none repeat scroll 0 0;display: block; height: 3372px; left: 0;  max-width: 100%; opacity: 0.5;position: fixed;top: 0; width: 1903px; z-index: 10000;}

    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContain" runat="server">
     <asp:HiddenField ID="hfPoderId" runat="server" />
    <asp:UpdatePanel ID="upSearch" runat="server">
        <ContentTemplate>
            <%--<div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xm-4">
                    <asp:TextBox ID="txtPoId" runat="server" placeholder="Enter Purchase Order No" CssClass="form-control" ValidationGroup="serach"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xm-4">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>--%>
            <div class="panel panel-primary col-lg-4 col-md-4 col-sm-4 col-xm-4 col-lg-offset-4" id="divSerach"  style="margin-top:20px"  runat="server">
            <div style="height:20px" class="panel-heading"></div>
                <div class="panel-body">
                    <asp:TextBox ID="txtPoId" runat="server" placeholder="Enter Purchase Order No" CssClass="form-control" ValidationGroup="serach"></asp:TextBox>
                    <br />    
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-control btn-primary" OnClick="btnSearch_Click" />
                </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="up1" UpdateMode="Conditional"   runat="server">
   <ContentTemplate>
       <div id="divForm" runat="server">
                   <asp:gridview ID="Gridview1" runat="server" GridLines="None" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="Gridview1_RowDataBound">
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false"/>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtItemName" Text='<%# Bind("ItemPrefix") %>' runat="server" OnTextChanged="txtItemName_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtItemName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
                </ajaxToolkit:AutoCompleteExtender>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDec" Text='<%# Bind("Description") %>' runat="server" CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("ItemSalePrice") %>' CssClass="form-control"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQut" runat="server" Text='<%# Bind("ItemUnit") %>' CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:TextBox ID="txtTotal" runat="server" Text='<%# Bind("TotalPrice") %>' CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQut_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        
        <div >
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblSubTotal" Font-Bold="true" runat="server" Text="Sub Total"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtSubTotal" CssClass="form-control" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblTax" Font-Bold="true" runat="server" Text="Tax(%)"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtTax" CssClass="form-control" runat="server" ></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblSHC" Font-Bold="true" runat="server" Text="Shiping And Handling Cost"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtSHC" CssClass="form-control" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Label ID="lblMiscCost" Font-Bold="true" runat="server" Text="Miscellaneous Cost"></asp:Label></div>
        <div class="col-lg-4"><asp:TextBox ID="txtMiscCost" CssClass="form-control" runat="server"></asp:TextBox></div>
        <div class="col-lg-5"></div>
</div>
        <br />
        <br />
            <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Button ID="Button1" Text="Submit" CausesValidation="false"   runat="server" 
               CssClass="form-control btn-primary" OnClick="btnSubmit_Click"  /></div>
        <div class="col-lg-2"><asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false"   runat="server" 
               CssClass="form-control btn-danger" OnClick="btnCancel_Click"  /></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-5"></div>
</div>


        <%--<div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2"><asp:Button ID="btnSubmit" Text="Submit" CausesValidation="false"  runat="server" 
                CssClass="btn-info" OnClick="btnSubmit_Click"  /></div>
        <div class="col-lg-4"></div>
        <div class="col-lg-5"></div>
</div>--%>
        <div>
            <div id="loading" style="display:none;" runat="server" class="loading1"></div>
        </div>
</div>
    
    
</div>


    </ContentTemplate>
     <Triggers>
         <asp:AsyncPostBackTrigger ControlID ="Gridview1" />
         
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

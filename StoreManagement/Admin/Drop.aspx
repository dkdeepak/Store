<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Drop.aspx.cs" Inherits="StoreManagement.Admin.Drop" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ContentPlaceHolderID="head" ID="head" runat="server">
    
    <link href="../Style/chosen.css" rel="stylesheet" />
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
  
   
    
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
                            <div class="col-md-12">
                            <div class="row" style="display:none">
                                <div class="col-md-6">Category Id:</div>
                                <div class="col-md-6"><asp:TextBox ID="txtCategoryId" runat="server" CssClass="form-control" /></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                <asp:TextBox ID="txtCategoryName" placeholder="Enter Category Name"  ToolTip="Category Name"  runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvtCategoryName" ControlToValidate="txtCategoryName" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCat" runat="server">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCategory" runat="server"
                                                         ControlToValidate="txtCategoryName" ValidationGroup="vgCat" ErrorMessage="Invalid entry"
                                                         ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="container">
            <asp:DropDownList ID="DropDownList1" runat="server" class="chosen-search" Style="width: 350px;" data-placeholder="Choose a Country" AutoPostBack="true">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="United States " Value="United States"></asp:ListItem>
                <asp:ListItem Text="United Kingdom " Value="United Kingdom"></asp:ListItem>
                <asp:ListItem Text="Afghanistan " Value="Afghanistan"></asp:ListItem>
                <asp:ListItem Text="Aland Islands " Value="Aland Islands"></asp:ListItem>
                <asp:ListItem Text="Albania " Value="Albania"></asp:ListItem>
                <asp:ListItem Text="Algeria " Value="Algeria"></asp:ListItem>
                <asp:ListItem Text="American Samoa " Value="American Samoa"></asp:ListItem>
                <asp:ListItem Text="Andorra " Value="Andorra"></asp:ListItem>
                <asp:ListItem Text="Angola " Value="Angola"></asp:ListItem>
                <asp:ListItem Text="Anguilla " Value="Anguilla"></asp:ListItem>
                <asp:ListItem Text="Antarctica " Value="Antarctica"></asp:ListItem>
                <asp:ListItem Text="Antigua and Barbuda " Value="Antigua and Barbuda"></asp:ListItem>
                <asp:ListItem Text="Argentina " Value="Argentina"></asp:ListItem>
                <asp:ListItem Text="Armenia " Value="Armenia"></asp:ListItem>
                <asp:ListItem Text="Aruba " Value="Aruba"></asp:ListItem>
                <asp:ListItem Text="Australia " Value="Australia"></asp:ListItem>
                <asp:ListItem Text="Austria " Value="Austria"></asp:ListItem>
                <asp:ListItem Text="Azerbaijan " Value="Azerbaijan"></asp:ListItem>
                <asp:ListItem Text="Bahamas " Value="Bahamas"></asp:ListItem>
                <asp:ListItem Text="Bahrain " Value="Bahrain"></asp:ListItem>
                <asp:ListItem Text="Bangladesh " Value="Bangladesh"></asp:ListItem>
                <asp:ListItem Text="Barbados " Value="Barbados"></asp:ListItem>
                <asp:ListItem Text="Belarus " Value="Belarus"></asp:ListItem>
                <asp:ListItem Text="Belgium " Value="Belgium"></asp:ListItem>
                <asp:ListItem Text="Belize " Value="Belize"></asp:ListItem>
                <asp:ListItem Text="Benin " Value="Benin"></asp:ListItem>
                <asp:ListItem Text="Bermuda " Value="Bermuda"></asp:ListItem>
                <asp:ListItem Text="Bhutan " Value="Bhutan"></asp:ListItem>
                <asp:ListItem Text="Bolivia, Plurinational State of " Value="Bolivia, Plurinational State of"></asp:ListItem>
                <asp:ListItem Text="Cape Verde " Value="Cape Verde"></asp:ListItem>
                <asp:ListItem Text="Cayman Islands " Value="Cayman Islands"></asp:ListItem>
                <asp:ListItem Text="Central African Republic " Value="Central African Republic"></asp:ListItem>
                <asp:ListItem Text="Chad " Value="Chad"></asp:ListItem>
                <asp:ListItem Text="Chile " Value="Chile"></asp:ListItem>
                <asp:ListItem Text="China " Value="China"></asp:ListItem>
                <asp:ListItem Text="Christmas Island " Value="Christmas Island"></asp:ListItem>
                <asp:ListItem Text="Cocos (Keeling) Islands " Value="Cocos (Keeling) Islands"></asp:ListItem>
                <asp:ListItem Text="Colombia " Value="Colombia"></asp:ListItem>
                <asp:ListItem Text="Comoros " Value="Comoros"></asp:ListItem>
                <asp:ListItem Text="Congo " Value="Congo"></asp:ListItem>
                <asp:ListItem Text="Congo, The Democratic Republic of The " Value="Congo, The Democratic Republic of The"></asp:ListItem>
                <asp:ListItem Text="Cook Islands " Value="Cook Islands"></asp:ListItem>
                <asp:ListItem Text="Costa Rica " Value="Costa Rica"></asp:ListItem>
                <asp:ListItem Text="Cote D&apos;ivoire " Value="Cote D'ivoire"></asp:ListItem>
                <asp:ListItem Text="Croatia " Value="Croatia"></asp:ListItem>
                <asp:ListItem Text="Cuba " Value="Cuba"></asp:ListItem>
                <asp:ListItem Text="Curacao " Value="Curacao"></asp:ListItem>
                <asp:ListItem Text="Cyprus " Value="Cyprus"></asp:ListItem>
                <asp:ListItem Text="Czech Republic " Value="Czech Republic"></asp:ListItem>
                <asp:ListItem Text="Denmark " Value="Denmark"></asp:ListItem>
                <asp:ListItem Text="Djibouti " Value="Djibouti"></asp:ListItem>
                <asp:ListItem Text="Dominica " Value="Dominica"></asp:ListItem>
                <asp:ListItem Text="Dominican Republic " Value="Dominican Republic"></asp:ListItem>
                <asp:ListItem Text="Ecuador " Value="Ecuador"></asp:ListItem>
                <asp:ListItem Text="Egypt " Value="Egypt"></asp:ListItem>
                <asp:ListItem Text="El Salvador " Value="El Salvador"></asp:ListItem>
                <asp:ListItem Text="Equatorial Guinea " Value="Equatorial Guinea"></asp:ListItem>
                <asp:ListItem Text="Eritrea " Value="Eritrea"></asp:ListItem>
                <asp:ListItem Text="Estonia " Value="Estonia"></asp:ListItem>
                <asp:ListItem Text="Ethiopia " Value="Ethiopia"></asp:ListItem>
                <asp:ListItem Text="Falkland Islands (Malvinas) " Value="Falkland Islands (Malvinas)"></asp:ListItem>
                <asp:ListItem Text="Faroe Islands " Value="Faroe Islands"></asp:ListItem>
                <asp:ListItem Text="Fiji " Value="Fiji"></asp:ListItem>
                <asp:ListItem Text="Finland " Value="Finland"></asp:ListItem>
                <asp:ListItem Text="France " Value="France"></asp:ListItem>
                <asp:ListItem Text="French Guiana " Value="French Guiana"></asp:ListItem>
                <asp:ListItem Text="French Polynesia " Value="French Polynesia"></asp:ListItem>
                <asp:ListItem Text="French Southern Territories " Value="French Southern Territories"></asp:ListItem>
                <asp:ListItem Text="Gabon " Value="Gabon"></asp:ListItem>
                <asp:ListItem Text="Gambia " Value="Gambia"></asp:ListItem>
                <asp:ListItem Text="Georgia " Value="Georgia"></asp:ListItem>
                <asp:ListItem Text="Germany " Value="Germany"></asp:ListItem>
                <asp:ListItem Text="Ghana " Value="Ghana"></asp:ListItem>
                <asp:ListItem Text="Gibraltar " Value="Gibraltar"></asp:ListItem>
                <asp:ListItem Text="Greece " Value="Greece"></asp:ListItem>
                <asp:ListItem Text="Greenland " Value="Greenland"></asp:ListItem>
                <asp:ListItem Text="Grenada " Value="Grenada"></asp:ListItem>
                <asp:ListItem Text="Guadeloupe " Value="Guadeloupe"></asp:ListItem>
                <asp:ListItem Text="Guam " Value="Guam"></asp:ListItem>
                <asp:ListItem Text="Guatemala " Value="Guatemala"></asp:ListItem>
                <asp:ListItem Text="Guernsey " Value="Guernsey"></asp:ListItem>
                <asp:ListItem Text="Guinea " Value="Guinea"></asp:ListItem>
                <asp:ListItem Text="Guinea-bissau " Value="Guinea-bissau"></asp:ListItem>
                <asp:ListItem Text="Guyana " Value="Guyana"></asp:ListItem>
                <asp:ListItem Text="Haiti " Value="Haiti"></asp:ListItem>
                <asp:ListItem Text="Heard Island and Mcdonald Islands " Value="Heard Island and Mcdonald Islands"></asp:ListItem>
                <asp:ListItem Text="Holy See (Vatican City State) " Value="Holy See (Vatican City State)"></asp:ListItem>
                <asp:ListItem Text="Honduras " Value="Honduras"></asp:ListItem>
                <asp:ListItem Text="Hong Kong " Value="Hong Kong"></asp:ListItem>
                <asp:ListItem Text="Hungary " Value="Hungary"></asp:ListItem>
                <asp:ListItem Text="Iceland " Value="Iceland"></asp:ListItem>
                <asp:ListItem Text="India " Value="India"></asp:ListItem>
                <asp:ListItem Text="Indonesia " Value="Indonesia"></asp:ListItem>
                <asp:ListItem Text="Iran, Islamic Republic of " Value="Iran, Islamic Republic of"></asp:ListItem>
                <asp:ListItem Text="Iraq " Value="Iraq"></asp:ListItem>
                <asp:ListItem Text="Ireland " Value="Ireland"></asp:ListItem>
                <asp:ListItem Text="Isle of Man " Value="Isle of Man"></asp:ListItem>
                <asp:ListItem Text="Israel " Value="Israel"></asp:ListItem>
                <asp:ListItem Text="Italy " Value="Italy"></asp:ListItem>
                <asp:ListItem Text="Jamaica " Value="Jamaica"></asp:ListItem>
                <asp:ListItem Text="Japan " Value="Japan"></asp:ListItem>
                <asp:ListItem Text="Jersey " Value="Jersey"></asp:ListItem>
                <asp:ListItem Text="Jordan " Value="Jordan"></asp:ListItem>
                <asp:ListItem Text="Kazakhstan " Value="Kazakhstan"></asp:ListItem>
                <asp:ListItem Text="Kenya " Value="Kenya"></asp:ListItem>
                <asp:ListItem Text="Kiribati " Value="Kiribati"></asp:ListItem>
                <asp:ListItem Text="Korea, Democratic People&apos;s Republic of " Value="Korea, Democratic People's Republic of"></asp:ListItem>
                <asp:ListItem Text="Korea, Republic of " Value="Korea, Republic of"></asp:ListItem>
                <asp:ListItem Text="Kuwait " Value="Kuwait"></asp:ListItem>
                <asp:ListItem Text="Kyrgyzstan " Value="Kyrgyzstan"></asp:ListItem>
                <asp:ListItem Text="Lao People&apos;s Democratic Republic " Value="Lao People's Democratic Republic"></asp:ListItem>
                <asp:ListItem Text="Latvia " Value="Latvia"></asp:ListItem>
                <asp:ListItem Text="Lebanon " Value="Lebanon"></asp:ListItem>
                <asp:ListItem Text="Lesotho " Value="Lesotho"></asp:ListItem>
                <asp:ListItem Text="Liberia " Value="Liberia"></asp:ListItem>
                <asp:ListItem Text="Libya " Value="Libya"></asp:ListItem>
                <asp:ListItem Text="Liechtenstein " Value="Liechtenstein"></asp:ListItem>
                <asp:ListItem Text="Lithuania " Value="Lithuania"></asp:ListItem>
                <asp:ListItem Text="Luxembourg " Value="Luxembourg"></asp:ListItem>
                <asp:ListItem Text="Macao " Value="Macao"></asp:ListItem>
                <asp:ListItem Text="Macedonia, The Former Yugoslav Republic of " Value="Macedonia, The Former Yugoslav Republic of"></asp:ListItem>
                <asp:ListItem Text="Madagascar " Value="Madagascar"></asp:ListItem>
                <asp:ListItem Text="Malawi " Value="Malawi"></asp:ListItem>
                <asp:ListItem Text="Malaysia " Value="Malaysia"></asp:ListItem>
                <asp:ListItem Text="Maldives " Value="Maldives"></asp:ListItem>
                <asp:ListItem Text="Mali " Value="Mali"></asp:ListItem>
                <asp:ListItem Text="Malta " Value="Malta"></asp:ListItem>
                <asp:ListItem Text="Marshall Islands " Value="Marshall Islands"></asp:ListItem>
                <asp:ListItem Text="Martinique " Value="Martinique"></asp:ListItem>
                <asp:ListItem Text="Mauritania " Value="Mauritania"></asp:ListItem>
                <asp:ListItem Text="Mauritius " Value="Mauritius"></asp:ListItem>
                <asp:ListItem Text="Mayotte " Value="Mayotte"></asp:ListItem>
                <asp:ListItem Text="Mexico " Value="Mexico"></asp:ListItem>
                <asp:ListItem Text="Micronesia, Federated States of " Value="Micronesia, Federated States of"></asp:ListItem>
                <asp:ListItem Text="Moldova, Republic of " Value="Moldova, Republic of"></asp:ListItem>
                <asp:ListItem Text="Monaco " Value="Monaco"></asp:ListItem>
                <asp:ListItem Text="Mongolia " Value="Mongolia"></asp:ListItem>
                <asp:ListItem Text="Montenegro " Value="Montenegro"></asp:ListItem>
                <asp:ListItem Text="Montserrat " Value="Montserrat"></asp:ListItem>
                <asp:ListItem Text="Morocco " Value="Morocco"></asp:ListItem>
                <asp:ListItem Text="Mozambique " Value="Mozambique"></asp:ListItem>
                <asp:ListItem Text="Myanmar " Value="Myanmar"></asp:ListItem>
                <asp:ListItem Text="Namibia " Value="Namibia"></asp:ListItem>
                <asp:ListItem Text="Nauru " Value="Nauru"></asp:ListItem>
                <asp:ListItem Text="Nepal " Value="Nepal"></asp:ListItem>
                <asp:ListItem Text="Netherlands " Value="Netherlands"></asp:ListItem>
                <asp:ListItem Text="New Caledonia " Value="New Caledonia"></asp:ListItem>
                <asp:ListItem Text="New Zealand " Value="New Zealand"></asp:ListItem>
                <asp:ListItem Text="Nicaragua " Value="Nicaragua"></asp:ListItem>
                <asp:ListItem Text="Niger " Value="Niger"></asp:ListItem>
                <asp:ListItem Text="Nigeria " Value="Nigeria"></asp:ListItem>
                <asp:ListItem Text="Niue " Value="Niue"></asp:ListItem>
                <asp:ListItem Text="Norfolk Island " Value="Norfolk Island"></asp:ListItem>
                <asp:ListItem Text="Northern Mariana Islands " Value="Northern Mariana Islands"></asp:ListItem>
                <asp:ListItem Text="Norway " Value="Norway"></asp:ListItem>
                <asp:ListItem Text="Oman " Value="Oman"></asp:ListItem>
                <asp:ListItem Text="Pakistan " Value="Pakistan"></asp:ListItem>
                <asp:ListItem Text="Palau " Value="Palau"></asp:ListItem>
                <asp:ListItem Text="Palestinian Territory, Occupied " Value="Palestinian Territory, Occupied"></asp:ListItem>
                <asp:ListItem Text="Panama " Value="Panama"></asp:ListItem>
                <asp:ListItem Text="Papua New Guinea " Value="Papua New Guinea"></asp:ListItem>
                <asp:ListItem Text="Paraguay " Value="Paraguay"></asp:ListItem>
                <asp:ListItem Text="Peru " Value="Peru"></asp:ListItem>
                <asp:ListItem Text="Philippines " Value="Philippines"></asp:ListItem>
                <asp:ListItem Text="Pitcairn " Value="Pitcairn"></asp:ListItem>
                <asp:ListItem Text="Poland " Value="Poland"></asp:ListItem>
                <asp:ListItem Text="Portugal " Value="Portugal"></asp:ListItem>
                <asp:ListItem Text="Puerto Rico " Value="Puerto Rico"></asp:ListItem>
                <asp:ListItem Text="Qatar " Value="Qatar"></asp:ListItem>
                <asp:ListItem Text="Reunion " Value="Reunion"></asp:ListItem>
                <asp:ListItem Text="Romania " Value="Romania"></asp:ListItem>
                <asp:ListItem Text="Russian Federation " Value="Russian Federation"></asp:ListItem>
                <asp:ListItem Text="Rwanda " Value="Rwanda"></asp:ListItem>
                <asp:ListItem Text="Saint Barthelemy " Value="Saint Barthelemy"></asp:ListItem>
                <asp:ListItem Text="Saint Helena, Ascension and Tristan da Cunha " Value="Saint Helena, Ascension and Tristan da Cunha"></asp:ListItem>
                <asp:ListItem Text="Saint Kitts and Nevis " Value="Saint Kitts and Nevis"></asp:ListItem>
                <asp:ListItem Text="Saint Lucia " Value="Saint Lucia"></asp:ListItem>
                <asp:ListItem Text="Saint Martin (French part) " Value="Saint Martin (French part)"></asp:ListItem>
                <asp:ListItem Text="Saint Pierre and Miquelon " Value="Saint Pierre and Miquelon"></asp:ListItem>
                <asp:ListItem Text="Saint Vincent and The Grenadines " Value="Saint Vincent and The Grenadines"></asp:ListItem>
                <asp:ListItem Text="Samoa " Value="Samoa"></asp:ListItem>
                <asp:ListItem Text="San Marino " Value="San Marino"></asp:ListItem>
                <asp:ListItem Text="Sao Tome and Principe " Value="Sao Tome and Principe"></asp:ListItem>
                <asp:ListItem Text="Saudi Arabia " Value="Saudi Arabia"></asp:ListItem>
                <asp:ListItem Text="Senegal " Value="Senegal"></asp:ListItem>
                <asp:ListItem Text="Serbia " Value="Serbia"></asp:ListItem>
                <asp:ListItem Text="Seychelles " Value="Seychelles"></asp:ListItem>
                <asp:ListItem Text="Sierra Leone " Value="Sierra Leone"></asp:ListItem>
                <asp:ListItem Text="Singapore " Value="Singapore"></asp:ListItem>
                <asp:ListItem Text="Sint Maarten (Dutch part) " Value="Sint Maarten (Dutch part)"></asp:ListItem>
                <asp:ListItem Text="Slovakia " Value="Slovakia"></asp:ListItem>
                <asp:ListItem Text="Slovenia " Value="Slovenia"></asp:ListItem>
                <asp:ListItem Text="Solomon Islands " Value="Solomon Islands"></asp:ListItem>
                <asp:ListItem Text="Somalia " Value="Somalia"></asp:ListItem>
                <asp:ListItem Text="South Africa " Value="South Africa"></asp:ListItem>
                <asp:ListItem Text="South Georgia and The South Sandwich Islands " Value="South Georgia and The South Sandwich Islands"></asp:ListItem>
                <asp:ListItem Text="South Sudan " Value="South Sudan"></asp:ListItem>
                <asp:ListItem Text="Spain " Value="Spain"></asp:ListItem>
                <asp:ListItem Text="Sri Lanka " Value="Sri Lanka"></asp:ListItem>
                <asp:ListItem Text="Sudan " Value="Sudan"></asp:ListItem>
                <asp:ListItem Text="Suriname " Value="Suriname"></asp:ListItem>
                <asp:ListItem Text="Svalbard and Jan Mayen " Value="Svalbard and Jan Mayen"></asp:ListItem>
                <asp:ListItem Text="Swaziland " Value="Swaziland"></asp:ListItem>
                <asp:ListItem Text="Sweden " Value="Sweden"></asp:ListItem>
                <asp:ListItem Text="Switzerland " Value="Switzerland"></asp:ListItem>
                <asp:ListItem Text="Syrian Arab Republic " Value="Syrian Arab Republic"></asp:ListItem>
                <asp:ListItem Text="Taiwan, Province of China " Value="Taiwan, Province of China"></asp:ListItem>
                <asp:ListItem Text="Tajikistan " Value="Tajikistan"></asp:ListItem>
                <asp:ListItem Text="Tanzania, United Republic of " Value="Tanzania, United Republic of"></asp:ListItem>
                <asp:ListItem Text="Thailand " Value="Thailand"></asp:ListItem>
                <asp:ListItem Text="Timor-leste " Value="Timor-leste"></asp:ListItem>
                <asp:ListItem Text="Togo " Value="Togo"></asp:ListItem>
                <asp:ListItem Text="Tokelau " Value="Tokelau"></asp:ListItem>
                <asp:ListItem Text="Tonga " Value="Tonga"></asp:ListItem>
                <asp:ListItem Text="Trinidad and Tobago " Value="Trinidad and Tobago"></asp:ListItem>
                <asp:ListItem Text="Tunisia " Value="Tunisia"></asp:ListItem>
                <asp:ListItem Text="Turkey " Value="Turkey"></asp:ListItem>
                <asp:ListItem Text="Turkmenistan " Value="Turkmenistan"></asp:ListItem>
                <asp:ListItem Text="Turks and Caicos Islands " Value="Turks and Caicos Islands"></asp:ListItem>
                <asp:ListItem Text="Tuvalu " Value="Tuvalu"></asp:ListItem>
                <asp:ListItem Text="Uganda " Value="Uganda"></asp:ListItem>
                <asp:ListItem Text="Ukraine " Value="Ukraine"></asp:ListItem>
                <asp:ListItem Text="United Arab Emirates " Value="United Arab Emirates"></asp:ListItem>
                <asp:ListItem Text="United Kingdom " Value="United Kingdom"></asp:ListItem>
                <asp:ListItem Text="United States " Value="United States"></asp:ListItem>
                <asp:ListItem Text="United States Minor Outlying Islands " Value="United States Minor Outlying Islands"></asp:ListItem>
                <asp:ListItem Text="Uruguay " Value="Uruguay"></asp:ListItem>
                <asp:ListItem Text="Uzbekistan " Value="Uzbekistan"></asp:ListItem>
                <asp:ListItem Text="Vanuatu " Value="Vanuatu"></asp:ListItem>
                <asp:ListItem Text="Venezuela, Bolivarian Republic of " Value="Venezuela, Bolivarian Republic of"></asp:ListItem>
                <asp:ListItem Text="Viet Nam " Value="Viet Nam"></asp:ListItem>
                <asp:ListItem Text="Virgin Islands, British " Value="Virgin Islands, British"></asp:ListItem>
                <asp:ListItem Text="Virgin Islands, U.S. " Value="Virgin Islands, U.S."></asp:ListItem>
                <asp:ListItem Text="Wallis and Futuna " Value="Wallis and Futuna"></asp:ListItem>
                <asp:ListItem Text="Western Sahara " Value="Western Sahara"></asp:ListItem>
                <asp:ListItem Text="Yemen " Value="Yemen"></asp:ListItem>
                <asp:ListItem Text="Zambia " Value="Zambia"></asp:ListItem>
                <asp:ListItem Text="Zimbabwe " Value="Zimbabwe"></asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <br />

            <div style="padding-left: 130px">
                <asp:Button ID="btn1" runat="server" Text="Submit" />
            </div>

        </div>

                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-6"><asp:Button ID="btnUpdate"  CssClass="form-control btn-primary" CommandName="Update" runat="server" ValidationGroup="vgCat" Text="Submit"  /></div>
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
      <script type="text/javascript">
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 10 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "95%" }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
        </script>
</asp:Content>

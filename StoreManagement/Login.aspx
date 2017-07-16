<%@ Page Language="C#" AutoEventWireup="true" Title="Login" CodeBehind="Login.aspx.cs" Inherits="StoreManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- MetisMenu CSS -->
    <link href="vendor/metisMenu/metisMenu.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="dist/css/sb-admin-2.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <%--<script src="vendor/jquery/jquery.min.js"></script>--%>

    <!-- Bootstrap Core JavaScript -->
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>

   <%-- <!-- Metis Menu Plugin JavaScript -->
    <script src="vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="dist/js/sb-admin-2.js"></script>--%>

</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"  placeholder="E-mail" name="email"  autofocus></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserPass" CssClass="form-control" runat="server"  placeholder="Password" name="password" type="password"></asp:TextBox>
                                 </div>
                                <asp:Button ID="btnLogin" runat="server"  CssClass="btn btn-lg btn-success btn-block" Text="Login" OnClick="btnLogin_Click" />
                                
                            </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
      
    </form>
</body>
</html>

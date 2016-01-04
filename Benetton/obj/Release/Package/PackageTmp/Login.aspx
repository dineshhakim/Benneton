<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Benetton.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link type="image/x-icon" href="images/favicon.ico" rel="shortcut icon" />
    <title>United Colors of Benetton</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.default.css" rel="stylesheet" />
    <script src='<%# ResolveUrl("~/scripts/jquery-1.11.1.min.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/jquery-migrate-1.2.1.min.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/custom.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/bootstrap.min.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/modernizr.min.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/pace.min.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/retina.min.js")%>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/scripts/jquery.cookies.js")%>' type="text/javascript"></script>
    
</head>
<body class="signin pace-done">
    <div class="pace pace-inactive">
        <div class="pace-progress" style="width: 100%;" data-progress-text="100%" data-progress="99">
            <div class="pace-progress-inner">
            </div>
        </div>
        <div class="pace-activity">
        </div>
    </div>
    <section>
        <div class="panel panel-signin">
            <div class="panel-body">
                <div class="logo text-center">
                <img alt="Chain Logo" src="images/logo-benettton-g.png" />
                </div>
              <div class="mb30"></div>
              <form runat="server" id="frm">
                <div class="input-group mb15">
                <span class="input-group-addon">
                    <i class="glyphicon glyphicon-user"></i>
                    </span>
                      <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Username" required="required" ></asp:TextBox>
                     </div>
                    <div class="input-group mb15">
                    <span class="input-group-addon">
                    <i class="glyphicon glyphicon-lock"></i>
                    </span>
                         <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" required="required"></asp:TextBox>
                     </div>
                    <div class="clearfix">
                    <div class="pull-left">
                      <div class="ckbox ckbox-primary mt10">
                          <input type="checkbox" id="rememberMe" runat="server" value="1"/>
                          <label for="rememberMe">Remember Me</label>
                       </div>
                     </div>
                    <div class="pull-right">
                    <button id="btnLogin" class="btn btn-success" runat="server" OnServerClick="btnSubmit_Click">Sign In <i class="fa fa-angle-right ml5"></i></button>
                    </div>
                  </div>
            </form>
            </div>
        </div>
    </section>
</body>
</html>

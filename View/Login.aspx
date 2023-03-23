<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EHotelMS.View.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../Assets/Libraries/Bootstrap/css/bootstrap.min.css" />
    <style>
        body {
            background-image: url(../Assets/Images/hotel1.jpg);
            background-size: cover;
        }

        .container-fluid {
            opacity: 0.9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row" style="height: 200px"></div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4 bg-light rounded-2">
                        <br />
                        <h1 class="text-success text-center">Authentic Hotel</h1>
                        <form>
                            <div class="mb-3">
                                <label for="UserTb" class="form-label">User Account</label>
                                <input type="text" class="form-control" id="UserTb" runat="server" required="required" placeholder="enter:admin">
                            </div>
                            <div class="mb-3">
                                <label for="PasswordTb" class="form-label">Password</label>
                                <input type="password" class="form-control" runat="server" id="PasswordTb" required="required" placeholder="enter:1">
                            </div>
                            <div class="mb-3">
                                <label id="ErrMsg" class="text-danger" runat="server"></label>
                                <input type="radio" id="AdminCb" name="Role" runat="server"><label class="text-success">Admin</label>
                                <input type="radio" id="UserCb" name="Role" runat="server"><label class="text-success">User</label>
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="LoginBtn" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="LoginBtn_Click" />
                            </div>
                            <br />
                        </form>
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

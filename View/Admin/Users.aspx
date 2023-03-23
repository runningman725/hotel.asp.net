<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="EHotelMS.View.Admin.Users" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-3"></div>
            <div class="col-6">
                <h1 class="text-success text-center">User Management</h1>
            </div>
            <div class="col-3"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <form>
                    <div class="mb-3">
                        <label for="UNameTb" class="form-label">User Name</label>
                        <input type="text" class="form-control" id="UNameTb" runat="server">
                    </div>
                    <div class="mb-3">
                        <label for="PhoneTb" class="form-label">phone</label>
                        <input type="text" class="form-control" id="PhoneTb" runat="server">
                    </div>
                    <div class="mb-3">
                        <label for="GenTb" class="form-label">Gender</label>
                        <asp:DropDownList ID="GenTb" runat="server" class="form-control">
                            <asp:ListItem>male</asp:ListItem>
                            <asp:ListItem>female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="AddressTb" class="form-label">Address</label>
                        <input type="text" class="form-control" id="AddressTb" runat="server">
                    </div>
                    <div class="mb-3">
                        <label for="PasswordTb" class="form-label">Password</label>
                        <input type="text" class="form-control" id="PasswordTb" runat="server">
                    </div>
                    <div class="row">
                        <div class="col d-grid">
                            <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-warning btn-block" OnClick="EditBtn_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="DelBtn" runat="server" Text="Delete" class="btn btn-danger btn-block" OnClick="DelBtn_Click" />
                        </div>
                    </div>
                    <br />
                    <div class="d-grid">
                        <label id="ErrMsg" runat="server" class="text-danger"></label>
                        <asp:Button ID="SaveBtn" runat="server" Text="Save" class="btn btn-success btn-block" OnClick="SaveBtn_Click" />
                    </div>
                    <br />
                </form>
            </div>
            <div class="col-md-9">
                <asp:GridView ID="UserGV" runat="server" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="UserGV_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

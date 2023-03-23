<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="EHotelMS.View.Admin.Rooms" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-3"></div>
            <div class="col-6"><h1 class="text-success text-center">Room Management</h1></div>
            <div class="col-3"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <form>
                    <div class="mb-3">
                        <label for="RNameTb" class="form-label">Room Name</label>
                        <input type="text" class="form-control" id="RNameTb" required="required" runat="server">
                    </div>
                    <div class="mb-3">
                        <label for="CatCb" class="form-label">Room Type</label>
                        <asp:DropDownList ID="CatCb" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="LocationTb" class="form-label">Location</label>
                        <input type="text" class="form-control" id="LocationTb" runat="server" >
                    </div>
                    <div class="mb-3">
                        <label for="CostTb" class="form-label">Cost</label>
                        <input type="text" class="form-control" id="CostTb" runat="server" >
                    </div>
                    <div class="mb-3">
                        <label for="LabelTb" class="form-label">Label</label>
                        <input type="text" class="form-control" id="LabelTb" runat="server">
                    </div>
                    <div class="mb-3">
                        <label for="StatusCb" class="form-label">Status</label>
                        <asp:DropDownList ID="StatusCb" runat="server" class="form-control" >
                            <asp:ListItem>Free</asp:ListItem>
                            <asp:ListItem>Ordered</asp:ListItem>
                        </asp:DropDownList>
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
                <asp:GridView ID="RoomsGV" runat="server" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged">
                </asp:GridView>
            </div>
            <div></div>
        </div>
    </div>
</asp:Content>

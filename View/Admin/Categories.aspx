<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="EHotelMS.View.Admin.Categories" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-3"></div>
            <div class="col-6"><h1 class="text-success text-center">Room Type Management</h1></div>
            <div class="col-3"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <form>
                    <div class="mb-3">
                        <label for="CatNameTb" class="form-label">Room Type Name</label>
                        <input type="text" class="form-control" id="CatNameTb" runat="server">
                    </div>
                    <div class="mb-3">
                        <label for="RemarkTb" class="form-label">Label</label>
                        <input type="text" class="form-control" id="RemarkTb" runat="server">
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
                <asp:GridView ID="CategoriesGV" runat="server" class="table" OnSelectedIndexChanged="CategoriesGV_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                    </Columns>
                    
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

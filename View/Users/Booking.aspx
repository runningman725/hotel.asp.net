<%@ Page Title="" Language="C#" MasterPageFile="~/View/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="EHotelMS.View.Users.Booking" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <div class="row mt-3">
            <div class="col">
                <div class="row">
                    <div class="col">
                        <form>
                            <div class="row">
                                <div class="col">
                                    <div class="mb-3">
                                        <label for="RoomTb" class="form-label">Room Name</label>
                                        <input type="text" class="form-control" id="RoomTb" runat="server">
                                    </div>
                                    <div class="mb-3">
                                        <label for="DateInTb" class="form-label">In Date</label>
                                        <input type="date" class="form-control" id="DateInTb" runat="server">
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="mb-3">
                                        <label for="DateOutTb" class="form-label">Leave Date</label>
                                        <input type="date" class="form-control" id="DateOutTb" runat="server">
                                    </div>
                                    <div class="mb-3">
                                        <label for="CostTb" class="form-label">Cost</label>
                                        <input type="text" class="form-control" id="CostTb" runat="server">
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div>
                                        <label id="ErrMsg" runat="server" class="text-danger"></label>
                                        <asp:Button ID="BookBtn" runat="server" Text="Book" class="btn btn-warning" OnClick="BookBtn_Click" />
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <h3 class="text-primary mt-3 text-center">Room Info</h3>
                <asp:GridView ID="BookingGV" runat="server" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BookingGV_SelectedIndexChanged">
                </asp:GridView>
            </div>
            <div class="col">
                <div class="row">
                    <div class="col text-center">
                        <h2 class="text-primary">Room BookList</h2>
                    </div>

                </div>
                <div class="row">
                    <asp:GridView ID="BookedGV" runat="server" class="table" AutoGenerateSelectButton="True">
                        <Columns>
                            <%--<asp:BoundField DataField="BDate" DataFormatString="[{0:yyyy/MM/dd}]" HeaderText="Book Date" HtmlEncode="false" SortExpression="BDate"></asp:BoundField>
                            <asp:BoundField DataField="DateIn" DataFormatString="[{0:yyyy/MM/dd}]" HeaderText="DateIn" HtmlEncode="false" SortExpression="DateIn"></asp:BoundField>
                            <asp:BoundField DataField="DateOut" DataFormatString="[{0:yyyy/MM/dd}]" HeaderText="DateOut" HtmlEncode="false" SortExpression="DateOut"></asp:BoundField>
                            --%>

                        </Columns>


                    </asp:GridView>
                </div>
            </div>
        </div>
    </di>
</asp:Content>

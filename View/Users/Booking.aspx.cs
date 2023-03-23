using EHotelMS.View.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotelMS.View.Users
{
    public partial class Booking : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            ShowBookings();
        }

        private void ShowRooms()
        {
            string Query = "select RId as Id, RName as Name, RCategory as Category, RCost as Cost, Status as Status from RoomTbl where status='Free'";
            DataTable dt = Con.GetData(Query);
            BookingGV.DataSource = dt;   //告诉数据源
            BookingGV.DataBind();    //gridview绑定数据
            if (dt.Rows.Count == 0)
            {
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("Number");
                emptyDt.Columns.Add("Room Name");
                emptyDt.Columns.Add("Room Type");
                //emptyDt.Columns.Add("Room Location");
                emptyDt.Columns.Add("Room Cost");
                //emptyDt.Columns.Add("Room Label");
                emptyDt.Columns.Add("Room Status");
                emptyDt.Rows.Add(emptyDt.NewRow());
            }
            else
            {
                BookingGV.HeaderRow.Cells[1].Text = "Number";
                BookingGV.HeaderRow.Cells[2].Text = "Room Name";
                BookingGV.HeaderRow.Cells[3].Text = "Room Type";
                //BookingGV.HeaderRow.Cells[4].Text = "Room Location";
                BookingGV.HeaderRow.Cells[4].Text = "Room Cost";
                //BookingGV.HeaderRow.Cells[6].Text = "Room Label";
                BookingGV.HeaderRow.Cells[5].Text = "Room Status";
            }
        }
        private void ShowBookings()
        {
            string Query = "select BId,BDate,BRoom,Agent,DateIn,DateOut,Amount from BookingTbl";
            DataTable dt = Con.GetData(Query);
            BookedGV.DataSource = dt;   //告诉数据源
            BookedGV.DataBind();    //gridview绑定数据
            if (dt.Rows.Count == 0)
            {
                DataTable emptyDt2 = new DataTable();
                emptyDt2.Columns.Add("Number");
                emptyDt2.Columns.Add("Book Date");
                emptyDt2.Columns.Add("Book Room");
                emptyDt2.Columns.Add("Book Agent");
                emptyDt2.Columns.Add("Date In");
                emptyDt2.Columns.Add("Date Out");
                emptyDt2.Columns.Add("Amount");
                emptyDt2.Rows.Add(emptyDt2.NewRow());
            }
            else
            {
                BookedGV.HeaderRow.Cells[1].Text = "Number";
                BookedGV.HeaderRow.Cells[2].Text = "Book Date";
                BookedGV.HeaderRow.Cells[3].Text = "Book Room";
                BookedGV.HeaderRow.Cells[4].Text = "Book Agent";
                BookedGV.HeaderRow.Cells[5].Text = "DateIn";
                BookedGV.HeaderRow.Cells[6].Text = "DateOut";
                BookedGV.HeaderRow.Cells[7].Text = "Amount";
            }
        }


        private void UpdateRoom()
        {
            try
            {
                string status = "Ordered";
                string Query = "update RoomTbl set Status='{0}' where RId='{1}'";
                Query = string.Format(Query, status, BookingGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Guest Room is Updated！";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        int Key = 0;
        int Days = 1;
        protected void BookingGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(BookingGV.SelectedRow.Cells[1].Text);
            RoomTb.Value = BookingGV.SelectedRow.Cells[2].Text;
            int Cost = Days*Convert.ToInt32(BookingGV.SelectedRow.Cells[4].Text);
            CostTb.Value = Cost.ToString();
        }

        int TCost = 0;
        //private void GetCost()
        //{
        //    DateTime DIn = Convert.ToDateTime(DateInTb.Value);
        //    DateTime DOut = Convert.ToDateTime(DateOutTb.Value);
        //    TimeSpan value = DOut - DIn;
        //    int Days = Convert.ToInt32(value.TotalDays);
        //    if(Days <= 0)
        //    {
        //        ErrMsg.InnerText = "Leave Date must later than In Date";
        //        return;
        //    }
        //    TCost = Days * Convert.ToInt32(BookingGV.SelectedRow.Cells[4].Text);
        //}

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime DIn = Convert.ToDateTime(DateInTb.Value);
                DateTime DOut = Convert.ToDateTime(DateOutTb.Value);
                TimeSpan value = DOut - DIn;
                int Days = Convert.ToInt32(value.TotalDays);
                if (Days <= 0)
                {
                    ErrMsg.InnerText = "Leave Date must later than In Date";
                    return;
                }
                TCost = Days * Convert.ToInt32(BookingGV.SelectedRow.Cells[4].Text);

                string RId = BookingGV.SelectedRow.Cells[1].Text;
                string BDate = DateTime.Now.ToString("yyyy-MM-dd");
                string InDate = DateInTb.Value;
                string OutDate = DateOutTb.Value;
                string Agent = Session["UId"] as string;
                //GetCost();
                //int Amount = Convert.ToInt32(CostTb.Value.ToString());
                string Query = "insert into BookingTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, BDate, RId, Agent, InDate, OutDate, TCost);
                Con.setData(Query);
                //ShowRooms();
                UpdateRoom();
                ShowBookings();
                ErrMsg.InnerText = "Guest Room is Ordered！";
                RoomTb.Value = "";
                CostTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

    }
}
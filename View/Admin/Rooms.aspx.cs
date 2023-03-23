using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotelMS.View.Admin
{
    public partial class Rooms : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            GetCategories();
        }

        private void ShowRooms()
        {
            string Query = "select * from RoomTbl";
            DataTable dt = Con.GetData(Query);
            RoomsGV.DataSource = dt;   //告诉数据源
            RoomsGV.DataBind();    //gridview绑定数据
            if (dt.Rows.Count == 0)
            {
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("Number");
                emptyDt.Columns.Add("Room Name");
                emptyDt.Columns.Add("Room Type Id");
                emptyDt.Columns.Add("Room Location");
                emptyDt.Columns.Add("Room Cost");
                emptyDt.Columns.Add("Room Label");
                emptyDt.Columns.Add("Room Status");
                emptyDt.Rows.Add(emptyDt.NewRow());

            }
            else
            {
                RoomsGV.HeaderRow.Cells[1].Text = "Number";
                RoomsGV.HeaderRow.Cells[2].Text = "Room Name";
                RoomsGV.HeaderRow.Cells[3].Text = "Room Type Id";
                RoomsGV.HeaderRow.Cells[4].Text = "Room Location";
                RoomsGV.HeaderRow.Cells[5].Text = "Room Cost";
                RoomsGV.HeaderRow.Cells[6].Text = "Room Label";
                RoomsGV.HeaderRow.Cells[7].Text = "Room Status";
            }

        }

        private void GetCategories()    //获取房型数据
        {
            string Query = "select * from CategoryTbl";
            if (!Page.IsPostBack)
            {
                CatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString(); //设置值
                CatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();  //设置id
                CatCb.DataSource = Con.GetData(Query);
                CatCb.DataBind();
            }
        }


        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string Rloc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Label = LabelTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Query = "update RoomTbl set RName='{0}',RCategory='{1}',RLocation='{2}',RCost='{3}',RRemarks='{4}',Status='{5}' where RId='{6}'";
                Query = string.Format(Query, RName, RCat, Rloc, Cost, Label, Status, RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Guest Room is Revised！";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string Rloc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Label = LabelTb.Value;
                string Status = "Free";
                string Query = "if  not exists (select RLocation from RoomTbl where RLocation='{2}') insert into RoomTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, RName, RCat, Rloc, Cost, Label, Status);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Guest Room is Added！";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "delete from RoomTbl where RId='{0}'";
                Query = string.Format(Query, RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Guest Room Deleted！";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        int Key = 0;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RNameTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            CatCb.SelectedValue = RoomsGV.SelectedRow.Cells[3].Text;
            LocationTb.Value = RoomsGV.SelectedRow.Cells[4].Text;
            CostTb.Value = RoomsGV.SelectedRow.Cells[5].Text;
            LabelTb.Value = RoomsGV.SelectedRow.Cells[6].Text;
            StatusCb.SelectedValue = RoomsGV.SelectedRow.Cells[7].Text;

        }

    }
}
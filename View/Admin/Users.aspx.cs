using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotelMS.View.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        Models.Functions Con;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowUsers();
        }

        private void ShowUsers()
        {
            string Query = "select * from UserTbl";
            dt = Con.GetData(Query);  
            UserGV.DataSource = dt;   //告诉数据源
            UserGV.DataBind();    //gridview绑定数据
            if (dt.Rows.Count==0)
            {
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("Number");
                emptyDt.Columns.Add("User name");
                emptyDt.Columns.Add("Phone");
                emptyDt.Columns.Add("Gender");
                emptyDt.Columns.Add("Address");
                emptyDt.Columns.Add("Password");
                emptyDt.Rows.Add(emptyDt.NewRow());

            }
            else
            {
                UserGV.HeaderRow.Cells[1].Text = "Number";
                UserGV.HeaderRow.Cells[2].Text = "User name";
                UserGV.HeaderRow.Cells[3].Text = "Phone";
                UserGV.HeaderRow.Cells[4].Text = "Gender";
                UserGV.HeaderRow.Cells[5].Text = "Address";
                UserGV.HeaderRow.Cells[6].Text = "Password";
            }
        }

        int Key = 0;
        protected void UserGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(UserGV.SelectedRow.Cells[1].Text);
            UNameTb.Value = UserGV.SelectedRow.Cells[2].Text;
            PhoneTb.Value = UserGV.SelectedRow.Cells[3].Text;
            GenTb.SelectedValue = UserGV.SelectedRow.Cells[4].Text;
            AddressTb.Value = UserGV.SelectedRow.Cells[5].Text;
            PasswordTb.Value = UserGV.SelectedRow.Cells[6].Text;
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UName = UNameTb.Value;
                string Phone = PhoneTb.Value;
                string Gen = GenTb.SelectedValue;
                string Address = AddressTb.Value;
                string Password = PasswordTb.Value;
                string Query = "if  not exists (select * from UserTbl where UName='{0}') insert into UserTbl values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, UName, Phone, Gen, Address, Password);
                Con.setData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User is Added！";
                UNameTb.Value = "";
                PhoneTb.Value = "";
                GenTb.SelectedIndex = -1;
                AddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UName = UNameTb.Value;
                string Phone = PhoneTb.Value;
                string Gen = GenTb.SelectedValue;
                string Address = AddressTb.Value;
                string Password = PasswordTb.Value;
                string Query = "update UserTbl set UName='{0}',UPhone='{1}',UGen='{2}',UAdd='{3}',UPass='{4}' where UId='{5}'";
                Query = string.Format(Query, UName, Phone, Gen, Address, Password, UserGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User is Revised！";
                UNameTb.Value = "";
                PhoneTb.Value = "";
                GenTb.SelectedIndex = -1;
                AddressTb.Value = "";
                PasswordTb.Value = "";
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
                string Query = "delete from UserTbl where UId='{0}'";
                Query = string.Format(Query, UserGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User Deleted！";
                UNameTb.Value = "";
                PhoneTb.Value = "";
                GenTb.SelectedIndex = -1;
                AddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}
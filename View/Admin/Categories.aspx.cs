using EHotelMS.Models;
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
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
        }

        private void ShowCategories()
        {
            string Query = "select CatId as Id,CatName as Categories, CatRemarks from CategoryTbl";
            DataTable dt = Con.GetData(Query);
            CategoriesGV.DataSource = dt;   //告诉数据源
            CategoriesGV.DataBind();    //gridview绑定数据
            if (dt.Rows.Count == 0)
            {
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("Number");
                emptyDt.Columns.Add("Room Type");
                emptyDt.Columns.Add("Room Label");
                emptyDt.Rows.Add(emptyDt.NewRow());
            }
            else
            {
                CategoriesGV.HeaderRow.Cells[1].Text = "Number";
                CategoriesGV.HeaderRow.Cells[2].Text = "Room Type";
                CategoriesGV.HeaderRow.Cells[3].Text = "Room Label";
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Rem = RemarkTb.Value;
                string Query = "if  not exists (select * from CategoryTbl where CatName='{0}') insert into CategoryTbl values('{0}','{1}')";
                Query = string.Format(Query, CatName, Rem);
                Con.setData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room Type Added！";
                CatNameTb.Value = "";
                RemarkTb.Value = "";
            }
            catch (Exception Ex){ 
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Rem = RemarkTb.Value;
                string Query = "update CategoryTbl set CatName='{0}',CatRemarks='{1}' where CatId='{2}'";
                Query = string.Format(Query, CatName, Rem, CategoriesGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room Revised！";
                CatNameTb.Value = "";
                RemarkTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        int Key = 0;
        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);
            CatNameTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;
            RemarkTb.Value = CategoriesGV.SelectedRow.Cells[3].Text;
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "delete from CategoryTbl where CatId='{0}'";
                Query = string.Format(Query, CategoriesGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room Deleted！";
                CatNameTb.Value = "";
                RemarkTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        //protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //int Key = 0;
        //protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[0].Text);
        //    CatNameTb.Value = CategoriesGV.SelectedRow.Cells[1].Text;
        //    RemarkTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;
        //}


    }
}
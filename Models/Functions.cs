using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EHotelMS.Models
{
    public class Functions
    {
        private SqlConnection Con;  //sql server 对象，访问sql server数据库
        private SqlCommand Cmd; //sql server 对象，访问sql server数据库，对行数据选择，修改，删除等命令
        private DataTable dt;   //储存数据的临时表格类
        private string ConStr;
        private SqlDataAdapter sda; //datasize和sql server的连接器，用来填充，更新datasize的数据

        public int setData(string Query)
        {
            int Cnt;
            if(Con.State == ConnectionState.Closed) //判断数据库关闭
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();    //用来更新数据，执行目标操作
            Con.Close();

            return Cnt;
        }

        public DataTable GetData(string Query)  //数据库中获取数据
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);    //查询到的数据，填充到虚拟表格中
            sda.Fill(dt);   //填充数据时，为返回的数据创建表和类
            return dt;  //返回数据表的值

        }

        public Functions()  //用来连接数据库
        {
            ConStr = @"Data Source=47.103.43.55;Initial Catalog=hotel12;User ID=sa;Password=111111"; //连接数据库字符串
            Con = new SqlConnection(ConStr);    //创建新的数据库连接
            Cmd = new SqlCommand(); //创建command对象，允许在指定的数据库进行操作
            Cmd.Connection = Con;

        }



    }
}
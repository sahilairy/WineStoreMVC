using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WineStoreMVC.Models
{
    public class AdminBlockLogin
    {
        //global variable to create the connection 
        SqlConnection sqlConn;
        String connection_String = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=WineStore;Integrated Security=True";
        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;


        public String txtUserName { get; set; }
        public String txtUserPassword { get; set; }

        public AdminBlockLogin() {
                
        }
        // this code is used to in the details of a prticuar query from the table using the sql statement with the help of where clause 
        public DataTable verify_Login(String qry)
        {
            DataTable tbl = new DataTable();


            sqlConn = new SqlConnection(connection_String);

            sqlConn.Open();
            sqlCmd = new SqlCommand(qry, sqlConn);

            sqlDatareader = sqlCmd.ExecuteReader();

            tbl.Load(sqlDatareader);

            sqlConn.Close();

            return tbl;
        }

    }
}
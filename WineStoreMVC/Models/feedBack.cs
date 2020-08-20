using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WineStoreMVC.Models
{
    public class feedBack
    {
        //global variable to create the connection 
        SqlConnection sqlConn;
        String connection_String = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=WineStore;Integrated Security=True";
        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;

        //this statement is related to insert delete update query that is the main statement of any database record 
        public void AddMessage(String sqlStatement)
        {

            sqlConn = new SqlConnection(connection_String);
            sqlConn.Open();


            sqlCmd = new SqlCommand(sqlStatement, sqlConn);
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();

        }




        //use getter setter to pass the values to the database table 
        public String txtName { get; set; }
        public String txtEmail { get; set; }
        public String txtNo { get; set; }
        public String txtMsg { get; set; }

        //default constructor to pass the value 
        public feedBack() {

        }



    }
}
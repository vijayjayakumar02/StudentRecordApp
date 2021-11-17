using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StudentApplication1.Models;

namespace StudentApplication1.DAL
{
    public class Db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataSet GetAllStudent()
        {
            SqlCommand com = new SqlCommand("Sp_GetAllStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void Add_data(Student stud)
        {
            SqlCommand com = new SqlCommand("Sp_ADD_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", stud.StudentName);
            com.Parameters.AddWithValue("@Age", stud.StudentAge);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void update_data(Student stud)
        {
            SqlCommand com = new SqlCommand("Sp_UPDATE_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", stud.StudentId);
            com.Parameters.AddWithValue("@Name", stud.StudentName);
            com.Parameters.AddWithValue("@Age", stud.StudentAge);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void deleterecord(int id)
        {
            SqlCommand com = new SqlCommand("Sp_DELETE_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet Getdatabyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_StudentbyId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
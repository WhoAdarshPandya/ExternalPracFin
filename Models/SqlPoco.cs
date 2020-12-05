using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExternalPracFin.Models
{
    public class SqlPoco
    {

        private static SqlConnection con = new SqlConnection(loadConString());
        private static SqlCommand cmd = null;
        private static SqlDataReader rdr = null;
        private static string insertQuery = "insert into StudentTable(FirstName,Course,Year,Gender) VALUES(@Name,@Course,@Year,@Gender)";
        private static string selectQuery = "select * from StudentTable";
        private static string updateQuery = "update StudentTable set FirstName=@FirstName,Course=@Course,Year=@Year,Gender=@Gender where Id = @Id";
        private static string deleteQuery = "delete from StudentTable where Id = @Id";
        public static int insertStudent(string name,string course,string year,char gender)
        {
            int noro = 0;
            con.Open();
            cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Gender", gender);
            noro = cmd.ExecuteNonQuery();
            con.Close();
            return noro;
        }

        public static List<StudentModel> getAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            con.Open();
            cmd = new SqlCommand(selectQuery, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                students.Add(new StudentModel
                {
                    Id = Convert.ToInt32(rdr["Id"].ToString()),
                    FirstName=rdr["FirstName"].ToString(),
                    Course = rdr["Course"].ToString(),
                    Gender = Convert.ToChar(rdr["Gender"].ToString()),
                    Year = rdr["Year"].ToString()
                });
            }
            con.Close();
            return students;
        }

        public static int UpdateStudent(int id, string name, string course, string year,char gender)
        {
            int noro;
            con.Open();
            cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@FirstName", name);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@Id", id);
            noro = cmd.ExecuteNonQuery();
            con.Close();
            return noro;
        }

        public static int DeleteStudent(int id)
        {
            int noro;
            con.Open();
            cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@Id", id);
            noro = cmd.ExecuteNonQuery();
            con.Close();
            return noro;
        }

        public static string loadConString()
        {
            return ConfigurationManager.ConnectionStrings["myCon"].ConnectionString.ToString();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SqlClient;
namespace Farm_Project.Dao_Imp
{
  public  class user 
    {

       public string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";

        public bool searchLogin (string name , string password)
        {
            //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter param1;
            SqlParameter param2;

            string stored = "searchLogin  ";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            param1 = new SqlParameter("@name", name);
            param2 = new SqlParameter("@password", password);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bool x = dr.Read();
            return x;

        }

       public DataTable getAllUsers()
       {
           DataTable dt = new DataTable();
           //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
           SqlConnection con = new SqlConnection(connectionString);
           string stored = "geAllUser";
           SqlDataAdapter da = new SqlDataAdapter(stored, con);
           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           
           return dt;



       }

       public int getLastUserId()
       {
           //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
           SqlConnection con = new SqlConnection(connectionString);
           string stored = "lastUserId";
           SqlCommand cmd = new SqlCommand(stored, con);
           cmd.CommandType = CommandType.StoredProcedure;
           con.Open();
           int y = (Int32)cmd.ExecuteScalar();
           return y;
       }

       public bool addUser(Dto.User usr)
       {
           //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
           SqlConnection con = new SqlConnection(connectionString);
           string stored = "addUser";
           SqlParameter param1 = new SqlParameter("@Id", usr.id);
           SqlParameter param2 = new SqlParameter("@name", usr.name);
           SqlParameter param3 = new SqlParameter("@role", usr.role);
           SqlParameter param4 = new SqlParameter("@password", usr.password);


           SqlCommand cmd = new SqlCommand(stored, con);
           cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
           cmd.Parameters.Add(param3);
           cmd.Parameters.Add(param4);

           cmd.CommandType = CommandType.StoredProcedure;
           con.Open();
           cmd.ExecuteNonQuery();

           return true;


       }
        
       public int getUserIDBylogin(string name, string password)
       {
           DataTable dtdbase=new DataTable();
           //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
           SqlConnection con = new SqlConnection(connectionString);
           string sql = "getUserBylogin";

           SqlParameter param1 = new SqlParameter("@name", name);
           SqlParameter param2 = new SqlParameter("@password", password);
           SqlCommand cmd =new SqlCommand(sql ,con);
           cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
           cmd.CommandType=CommandType.StoredProcedure;
           con.Open();

           int y = (Int32)cmd.ExecuteScalar();
           con.Close();
           return y;
       
       }

       public void editUser(Dto.User usr)
       {
           //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
           SqlConnection com = new SqlConnection(connectionString);
           string sql = "editUser";
           SqlCommand cmd = new SqlCommand(sql, com);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param1 = new SqlParameter("@id",usr.id);
           SqlParameter param2 = new SqlParameter("@name", usr.name);
           SqlParameter param3 = new SqlParameter("@role",usr.role);
           cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
           cmd.Parameters.Add(param3);
           com.Open();
           cmd.ExecuteNonQuery();
           com.Close();
           
       }

       public void   deleteUserById(int userId)
       {
           DataTable dtdbase = new DataTable();
           //string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
           SqlConnection con = new SqlConnection(connectionString);
           string sql = "deleteUser";

           SqlParameter param1 = new SqlParameter("@userId", userId);
           SqlCommand cmd = new SqlCommand(sql, con);
           cmd.Parameters.Add(param1);
           cmd.CommandType = CommandType.StoredProcedure;
           con.Open();

           cmd.ExecuteNonQuery();
           con.Close();
          

       }

        //deleteProduct


    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;



namespace Farm_Project.Dao_Imp
{
    class Utility
    {
        public int getLastExpenseId()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastExpenseId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int y = (Int32)cmd.ExecuteScalar();
            con.Close();
            return y;
        }


        public int getLastWalletTransactionId()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastWalletTransactionId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int y = (Int32)cmd.ExecuteScalar();
            con.Close();
            return y;

            //lastWalletTransactionId
        }
        //getAllPayOff

        public DataTable getAllPayOff()
        {
            DataTable dtDB = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "geAllPayOff";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(stored, con);
            da.Fill(dtDB);
            con.Close();
            return dtDB;
         }

        //addPayOff

        public void addPayOff( int userId, int TraderId, float amount, DateTime date)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addPayOff";
            SqlParameter param2 = new SqlParameter("@userId", userId);
            SqlParameter param3 = new SqlParameter("@traderId", TraderId);
            SqlParameter param4 = new SqlParameter("@amount", amount);
            SqlParameter param5 = new SqlParameter("@date", date);
           // SqlParameter param11 = new SqlParameter("id", 3);

            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(param11);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
                
        }

        //lastPayOff

        public int getlastPayOff()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastPayOff";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int y = (Int32)cmd.ExecuteScalar();
            con.Close();
            return y;
        }

        public void addMoney(int id, DateTime date, float amount, int userId ,string desc)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addMoney";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id",id);
            SqlParameter param2 = new SqlParameter("@date",date.Date);
            SqlParameter param3 = new SqlParameter("@amount", amount);
            SqlParameter param4 = new SqlParameter("@userid",userId);
            SqlParameter param5 = new SqlParameter("@desc",desc);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

                    }
       
        public void addExpense(int id, DateTime date, float amount, int userId, string desc)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addExpense";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter param2 = new SqlParameter("@date", date.Date);
            SqlParameter param3 = new SqlParameter("@amount", amount);
            SqlParameter param4 = new SqlParameter("@userid", userId);
            SqlParameter param5 = new SqlParameter("@desc", desc);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

          }
         
        public DataTable geTAllWalletTransaction()
        {
            DataTable dtDB = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "geAllWalletTransaction";
            SqlDataAdapter da = new SqlDataAdapter(stored, con);
            da.Fill(dtDB);
            return dtDB;
        }

        public DataTable getAllExpense()
        {
            DataTable dtDB = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "geAllExpense";
            SqlDataAdapter da = new SqlDataAdapter(stored, con);
            da.Fill(dtDB);
            return dtDB;
        }

        public DataTable geAllPayOffByDate(DateTime d1, DateTime d2)
        {
            //return a datatable contain all items 
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllPayOffByDate";
            SqlParameter param1 = new SqlParameter("@datestart", d1);
            SqlParameter param2 = new SqlParameter("@dateEnd", d2);

            DataTable dbtable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(param1);
            da.SelectCommand.Parameters.Add(param2);
            con.Open();
            da.Fill(dbtable);
            return dbtable;
        }
        


        //method relted to current money

        public void increaseCurrentMoeny(float money)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "increaseCurrentMoeny";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@money", money);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void decreaseCurrentMoeny(float money)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "decreaseCurrentMoeny";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@money", money);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public float getCurrentMoney()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "getCurrentMoeny";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            float  y = float.Parse( cmd.ExecuteScalar().ToString());
            con.Close();
            return y;

            //lastWalletTransactionId
        }

        //deleteExpense

        public void deleteExpense(int  expenseId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "deleteExpense";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@expenseId", expenseId);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        //deleteWalletTransaction

        public void deleteWalletTransaction(int walletId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "deleteWalletTransaction";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@walletId", walletId);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void delteProductTransaction(int ProductTransactionId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "delteProductTransaction";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@ProductTransactionId", ProductTransactionId);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void deletePayOff(int PayOffId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "deletePayOff";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@payOffId", PayOffId);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        // methods to edit the values of expense
        public void decreasetotalExpense(float expense)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "decreasetotalExpense";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@money", expense);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void increasetotalExpense(float expense)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "increasetotalExpense";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@money", expense);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        //increaseWalletMoney

        public void increaseWalletMoney(float walletMoney)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "increaseWalletMoney";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@money", walletMoney);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void decreaseWalletMoney(float expense)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "decreaseWalletMoney";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@money", expense);
            cmd.Parameters.Add(param1);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        //get total Expense and total walley money

        public float getTotalWalletMoney()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "getTotalWalletMoney";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            float y = float.Parse( cmd.ExecuteScalar().ToString());
            con.Close();
            return y;
        }

        public float getTotalExpense()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "getTotalExpense";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            float y = float.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return y;
        }
    }
}
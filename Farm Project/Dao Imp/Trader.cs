using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Farm_Project.Dao_Imp
{
    class Trader
    {
        public DataTable getAllTrader()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllTrader";
            DataTable dbtable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dbtable);
            return dbtable;

        }

        public int getLastTraderId()
        {
            int y;
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastTraderId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            y = (Int32)cmd.ExecuteScalar();
            return y;
        }

        public bool addTrader(Dto.Trader trd)
        {


            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addTrader";
            SqlParameter param1 = new SqlParameter("@Id", trd.traderId);
            SqlParameter param2 = new SqlParameter("@Name", trd.tradername);
            SqlParameter param3 = new SqlParameter("@location", trd.location);
            SqlParameter param4 = new SqlParameter("@debit", trd.remaining);
            SqlParameter param5 = new SqlParameter("@telephone",trd.telephone);


            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            return true;


        }

        //decreaseDebitToTrader
        public void decreaseDebitToTrader(int id, float amount)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "decreaseDebitToTrader";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter param2 = new SqlParameter("@Amount", amount);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void iecreaseDebitToTrader(int id, float amount)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "iecreaseDebitToTrader";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter param2 = new SqlParameter("@Amount", amount);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public DataTable getAllTraderNames()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllTraderNames";
            DataTable dbtable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dbtable);
            return dbtable;

        }

        public DataTable getTraderIdByName(string traderName)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "getTraderIdByName";
            SqlDataAdapter da = new SqlDataAdapter(sql, com);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@traderName", traderName);
            da.SelectCommand.Parameters.Add(param);
            com.Open();
            da.Fill(dt);
            com.Close();
            return dt;
       }

                //editProduct
        public void editTrader(Dto.Trader trd)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "editTrader";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", trd.traderId);
            SqlParameter param2 = new SqlParameter("@name", trd.tradername);
            SqlParameter param3 = new SqlParameter("@location", trd.location);
            SqlParameter param4 = new SqlParameter("@telephone", trd.telephone);

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);

            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();

        }

        public DataTable getTraderByid(int traderId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "getTraderByid";
            DataTable dbtable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@TraderId", traderId);
            da.SelectCommand.Parameters.Add(param);
            con.Open();
            da.Fill(dbtable);
            con.Close();
            return dbtable;

        }

        public void deleteTrader(int traderid)
        {
            DataTable dtdbase = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "deleteTrader";

            SqlParameter param1 = new SqlParameter("@traderId", traderid);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(param1);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();


        }

        //addDeletedTrader

        public void addDeletedTrader(Dto.Trader  trd )
        {
            DataTable dtdbase = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "addDeletedTrader";

            SqlParameter param1 = new SqlParameter("@tradername", trd.tradername);
            SqlParameter param2 = new SqlParameter("@telephone", trd.telephone);
            SqlParameter param3 = new SqlParameter("@location", trd.location);
            SqlParameter param4 = new SqlParameter("@remaining", trd.remaining);

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Farm_Project.Dao_Imp
{
    class Bill
    {
        public void addBill(Dto.Bill bl)
        {
            string connectionString = "Database=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addBill";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@billId",bl.billid);
            SqlParameter param2 = new SqlParameter("@Date",bl.date);
            SqlParameter param3 = new SqlParameter("@total",bl.total);
            SqlParameter param4 = new SqlParameter("@paid",bl.paid);
            SqlParameter param5 = new SqlParameter("@quantity",bl.quantity);
            SqlParameter param6 = new SqlParameter("@discount",bl.discount);
            SqlParameter param7 = new SqlParameter("@traderid",bl.trd.traderId);
            SqlParameter param8 = new SqlParameter("@userid",bl.billUser.id);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable getAllBill()
        {
            // suspected to be here method to open connection and take variable connection string
            string connectionString = "Database=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "geAllBill";
            SqlCommand cmd = new SqlCommand(stored, con);
            SqlDataAdapter da = new SqlDataAdapter(stored, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt=new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;

          //  ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("" + "إسم_العميل" + " like '%{0}%'", txt_search.Text.Trim().Replace("'", "''"));

        }

        public DataTable geAllProductTransactionByDate(DateTime d1, DateTime d2)
        {
            //return a datatable contain all items 
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllBillByDate";
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

        public SqlDataReader getAllDescrippedBill(int billId)
        {
            // this method take an bill id and return a data table contain all the products on this bill

            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter param1 = new SqlParameter("@billId", billId);
            string stored = "getProductTransactionByBillId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.Parameters.Add(param1);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;


        }

        public SqlDataReader getBillByTraderName(string traderName)
        {
            // this method return all the bills which belong to specific trader
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter param1 = new SqlParameter("@traderName", traderName);
            string stored = "getBillByTraderName";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.Parameters.Add(param1);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;




        }

        public SqlDataReader getBillById(int billId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter param1 = new SqlParameter("@billId", billId);
            string stored = "getBillById";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.Parameters.Add(param1);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public int getLastBillId()
        {
            int y;
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastBillId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            y = (int)cmd.ExecuteScalar(); 
            //cmd.ExecuteScalar();
            return y;
          }

        public void addBillProduct(Dto.item itm ,Dto.Bill bll)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addBillProduct";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@billId", bll.billid);
            SqlParameter param2 = new SqlParameter("@billProductId", itm.itemId);
            SqlParameter param3 = new SqlParameter("@quantity", itm.quantity);
            SqlParameter param4 = new SqlParameter("@price", itm.quantity);

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

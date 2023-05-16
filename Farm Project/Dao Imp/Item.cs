using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Farm_Project.Dao_Imp
{
    class Item
    {
        Int32 y;
        public int getLastItemId()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastProductId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            y= (Int32)cmd.ExecuteScalar(); 
            return y;
                }

        public DataTable getAllItems()
        {
            //return a datatable contain all items 
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllProduct";
            DataTable dbtable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dbtable);
            return dbtable;

            /*
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            */
        
        
        }

        public DataTable getItemByname(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter param = new SqlParameter();
            param=new SqlParameter("@name",name);
            string sql = "searchProductByName";
            DataTable dt=new DataTable();
            // SqlCommand cmd = new SqlCommand(sql, con);
           // cmd.Parameters.Add(param);
       //     cmd.CommandType = CommandType.StoredProcedure;
        //     con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
            SqlDataAdapter da=new SqlDataAdapter(sql,con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(param);
            da.Fill(dt);
           
            
            return dt;
        
        
        
        
        }

        //METHOD TO ENSURE THE REQUIRED QUNATITY ON BILL IS AVAILABLE
        public float getQuantityOfItem(int itemId)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "itemQuantity";
            SqlParameter param = new SqlParameter("@id", itemId);

            SqlCommand cmd = new SqlCommand(stored,con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            return  (Int32)cmd.ExecuteScalar();
            


        }

        public bool addItem(Dto.item itm)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addProduct";
            SqlParameter param1 = new SqlParameter("@productId", itm.itemId);
            SqlParameter param2 = new SqlParameter("@productName", itm.itemName);
            SqlParameter param3 = new SqlParameter("@price", itm.price);
            SqlParameter param4 = new SqlParameter("@quantity", itm.quantity);


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

        public bool addProductTransaction   (int id , int userId ,int productId , DateTime date , float amount)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "addProductTransaction";
            SqlParameter param1 = new SqlParameter("@ID", id);
            SqlParameter param2 = new SqlParameter("@userId", userId);
            SqlParameter param3 = new SqlParameter("@productId", productId);
            SqlParameter param4 = new SqlParameter("@Date", date);
            SqlParameter param5 = new SqlParameter("@Amount", amount);



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

        public int getLastProductTransactionId()
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string stored = "lastProductTranactionId";
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            y = (Int32)cmd.ExecuteScalar();
            return y;
        }

        public DataTable getAllProductTransaction()
        {
            //return a datatable contain all items 
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllProductTransaction";
            DataTable dbtable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dbtable);
            return dbtable;
        }
        //geAllPayOffByDate
         public DataTable geAllProductTransactionByDate(DateTime d1,DateTime d2)
        {
            //return a datatable contain all items 
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "geAllProductTransactionByDate";
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

         //geAllProductTransactionByDate

        public void addQuantityToProduct(int id, float quantity)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql ="addQuantityToProduct";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@productId", id);
            SqlParameter param2 = new SqlParameter("@quantity", quantity);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public void decreaseQuantityToProduct(int id, float quantity)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "decreaseQuantityToProduct";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@productId", id);
            SqlParameter param2 = new SqlParameter("@quantity", quantity);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }


        public void editProduct(Dto.item itm)
        {
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "editProduct";
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", itm.itemId);
            SqlParameter param2 = new SqlParameter("@name", itm.itemName);
            SqlParameter param3 = new SqlParameter("@price", itm.price);

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);

            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();

        }

        public DataTable getProductIdByName(string productName)
        {


            DataTable dt111 = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection com = new SqlConnection(connectionString);
            string sql = "getProductIdByName";
            SqlDataAdapter da = new SqlDataAdapter(sql,com);
            SqlParameter param = new SqlParameter("@productName", productName);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(param);
            com.Open();
            da.Fill(dt111);
            return dt111;
            com.Close();




            /*
            SqlCommand cmd = new SqlCommand(sql, com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@productName", productName);
            cmd.Parameters.Add(param);
            com.Open();
            int y = Int32.Parse(cmd.ExecuteScalar().ToString());
            return y;
             * 
             */

        }


        public void deleteProductById(int productId)
        {
            DataTable dtdbase = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "deleteProductById";

            SqlParameter param1 = new SqlParameter("@productId", productId);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(param1);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void addDeletedProduct(Dto.item itm)
        {
            DataTable dtdbase = new DataTable();
            string connectionString = "Data Source=.;Initial Catalog=Farm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "addDeletedProduct";

            SqlParameter param1 = new SqlParameter("@productName", itm.itemName);
            SqlParameter param2 = new SqlParameter("@price", itm.price);
            SqlParameter param3 = new SqlParameter("@quantity", itm.quantity);


            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}

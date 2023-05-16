using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farm_Project.Dao_Imp;
using System.Data.SqlClient;
using Farm_Project.Dto;

namespace Farm_Project.Presentation
{
    public partial class AddProductTransaction : Form
    {
        Dao_Imp.Item itm = new Dao_Imp.Item();
        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
        //public static Dto.User Susr = new Dto.User();

        

        public AddProductTransaction(Dto.item DTOitm)
        {
           //this is a try to make autocomplete
            InitializeComponent();
            DataTable dt = itm.getAllItems();
            txtPrice.AutoCompleteCustomSource = MyCollection;

            // mirror the specs of the product here
                txtProductId.Text = DTOitm.itemId.ToString();
                txtName.Text = DTOitm.itemName;
                txtPrice.Text = DTOitm.price.ToString();
                txtQuantity.Text = DTOitm.quantity.ToString();
                txtId.Text = itm.getLastProductTransactionId().ToString();
                txtUser.Text = login.UserId.ToString()+",  " +login.UserName;

            //
               // txtUser.Text =
                    //login.UserName;

        /*    while ( int i < 5 ,i++)
            {
            MyCollection.Add(dt.Rows[i]);
            }
            */
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itm.addProductTransaction(Int16.Parse(txtId.Text),login.UserId,Int16.Parse(txtProductId.Text),dateTimePicker1.Value.Date,float.Parse(txtAmountToIncrease.Text));
            itm.addQuantityToProduct(Int16.Parse(txtProductId.Text), float.Parse(txtAmountToIncrease.Text));
            MessageBox.Show("Increasing quantity Done");
            this.Close();
        }

        private void AddProductTransaction_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int distance;
            if (int.TryParse(txtAmountToIncrease.Text, out distance) || txtAmountToIncrease.Text == "")
            {
                // it's a valid integer => you could use the distance variable here
                try
                {
                    txtAmountAfterIncrease.Text = (float.Parse(txtQuantity.Text) + float.Parse(txtAmountToIncrease.Text)).ToString();
                }
                catch { Exception E; }
            }
            else
            {
                MessageBox.Show("Please Enter Valid numeric Value");
                txtAmountToIncrease.Text = "";
            }
        }
    }
}

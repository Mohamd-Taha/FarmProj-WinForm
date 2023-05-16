using Farm_Project.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Farm_Project.Dao_Imp;
using Farm_Project.Dto;

namespace Farm_Project.Presentation
{
    public partial class SellingBill22222 : Form
    {
        Dao_Imp.Bill bll = new Dao_Imp.Bill();
        Dao_Imp.Trader trd = new Dao_Imp.Trader();
        //the table to store all items from the database as it load with it at initalization
        DataTable dbtable = new DataTable();
        Dao_Imp.Item itmDao = new Dao_Imp.Item();
        item itm = new Dto.item();
        
        Dto.Bill DtoBll =new Dto.Bill();
        float subTotal=0;
        DataSet ds;
        Stack st = new Stack();
        int quantityInt = 0;
        // Constructor
        public SellingBill22222()
        {
            InitializeComponent();

            dgvBillItems.ReadOnly = true;
            dgvBillItems.Columns[3].ReadOnly = false;

            //load the product
            dbtable = itmDao.getAllItems();
            BindingSource source = new BindingSource();
            source.DataSource = dbtable;
            inventoryDGV.DataSource = source;

            //load the last bill id
            txtBillId.Text=bll.getLastBillId().ToString();
            DtoBll.billid=bll.getLastBillId();

            //initalize the bill attributes to zero 
            DtoBll.total = 0;
            DtoBll.paid = 0;
            DtoBll.discount = 0;
            DtoBll.billUser.id = login.UserId;
            // link the bill attribute instance to text boxes
            txtSubTotal.Text ="0";
            txtReminder.Text = "0";
           // txtDiscount.Text = "0";
           // txtPaid.Text = "0";

            //fill the text box "trader" with all trader names
            //getAllTraderNames
            AutoCompleteStringCollection sourceName = new AutoCompleteStringCollection();
            DataTable dttt = new DataTable();
           // dttt

            //int i = 0;

            foreach (DataRow row in trd.getAllTraderNames().Rows)
            {
                sourceName.Add(row[0].ToString());
                
            }

            txtTraderName.AutoCompleteCustomSource = sourceName;
            txtTraderName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTraderName.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
       
        
        //ds=dataGridView1.Datsour
       

        private void button3_Click(object sender, EventArgs e)
        {
            // clear Bill Items DGV
            BindingSource source1 = new BindingSource();
            source1.DataSource = null;
            dgvBillItems.DataSource = source1;
            // RESET THE TEXT BOXES
            txtDiscount.Text = "0";
            txtPaid.Text = "0";
            txtTraderName.Text = null;
           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            itm.itemId = Int16.Parse(textBox8.Text);
            itm.itemName = textBox10.Text;
            itm.price = float.Parse(textBox9.Text);
            itm.quantity = float.Parse(textBox11.Text);
             * */
            try
            {
                if (float.Parse(txtPrice.Text) > 0 | float.Parse(txtQuantity.Text) > 0)
                {
                    if (txtPrice.Text == null | txtQuantity.Text == null)
                    {
                        MessageBox.Show("fill all boxes with data");
                    }
                    else
                    {
                        //float quant = itmDao.getQuantityOfItem((Int16.Parse(txtId.Text)));
                        //if (quant >= Int16.Parse(txtQuantity.Text))
                        // {
                        // that's what supposed to do 
                        dgvBillItems.Rows.Add(Int16.Parse(txtId.Text), txtName.Text, float.Parse(txtPrice.Text), float.Parse(txtQuantity.Text));
                        DtoBll.total += float.Parse(txtPrice.Text) * float.Parse(txtQuantity.Text);
                        txtSubTotal.Text = DtoBll.total.ToString();
                        //clean all textboxes after add    
                        txtId.Text = null;
                        txtName.Text = null;
                        txtPrice.Text = null;
                        txtQuantity.Text = null;

                        //update reminder
                        txtReminder.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text) - float.Parse(txtPaid.Text)).ToString();
                        quantityInt++;



                        //  }
                        // else
                        // {
                        //     MessageBox.Show("The required Quantity is less Than Available , decrease the required quantity or  go to increase the product quantity");
                        // }
                    }
                }
                else
                {
                    MessageBox.Show("can't insert any negative value,try again");
                }
            }
            catch { Exception E; }

        }

        private void dgvBillItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // int i = dgvBillItems.Rows[1].Cells[0] ;
        }

        private void SellingBill22222_Load(object sender, EventArgs e)
        {

        }

        private void dgvBillItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                
                dgvBillItems.Rows.RemoveAt(e.RowIndex);
                if (float.Parse(txtDiscount.Text) > float.Parse(txtSubTotal.Text))
                {
                    txtDiscount.Text = "0";
                
                }
                if (float.Parse(txtPaid.Text) > (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text)))
                {
                    txtPaid.Text = "0";
                
                }
                               
            }
        }

        private void dgvBillItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // mirror of the rows selected to the text boxes on the left
            txtId.Text = inventoryDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = inventoryDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = inventoryDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
           // txtQuantity.Text = inventoryDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dgvBillItems_RowContextMenuStripChanged(object sender, DataGridViewRowEventArgs e)
        {
            //dgvBillItems.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            itmDao = new Dao_Imp.Item();
            BindingSource source = new BindingSource();
            source.DataSource = itmDao.getItemByname(textBox1.Text); 
            inventoryDGV.DataSource = source
             * */
            DataView DV = new DataView(dbtable);
            
            DV.RowFilter=string.Format("Name LIKE '%{0}%'", textBox1.Text);
            inventoryDGV.DataSource = DV;

           
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {


            if (txtPaid.Text == "")
            {
                txtReminder.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text)).ToString();
            
            }
            int distance;
            if (int.TryParse(txtPaid.Text, out distance) || txtPaid.Text == "")
            {
                // it's a valid integer => you could use the distance variable here
                try
                {
                    if (float.Parse(txtPaid.Text) > (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text)) )
                    {
                        MessageBox.Show("Paid  must be equal or less than the total");
                        txtPaid.Text = "0";
                    }
                    txtReminder.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text) - float.Parse(txtPaid.Text)).ToString();
                }
                catch { Exception E; }
            }
            else
            {
                MessageBox.Show("Please Enter Valid numeric Value");
                txtPaid.Text = "";
            }
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            if (float.Parse(txtDiscount.Text) > float.Parse(txtSubTotal.Text))
            {
                MessageBox.Show("Discount must be equal or less than the subtotal");
                txtDiscount.Text = "0";
            }
            
                txtReminder.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text) - float.Parse(txtPaid.Text)).ToString();
            
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            DtoBll.total = float.Parse(txtSubTotal.Text);
            DtoBll.paid = float.Parse(txtPaid.Text);
            DtoBll.discount = float.Parse(txtDiscount.Text);
            DtoBll.date = dtPicker.Value.Date.ToString();
            // get trader id by method depend on name
            DtoBll.quantity = quantityInt;

            if (trd.getTraderIdByName(txtTraderName.Text).ToString() == null)
            {
                MessageBox.Show(" enter vaild client name ");
            }
            else
            {
                MessageBox.Show(" yyyy");

                DtoBll.trd.traderId = Int32.Parse(trd.getTraderIdByName(txtTraderName.Text).Rows[0][0].ToString());

                bll.addBill(DtoBll);
                float reminder = DtoBll.total - DtoBll.paid - DtoBll.discount;
                trd.iecreaseDebitToTrader(DtoBll.trd.traderId, reminder);
                // add bill itself 
                //bll.addBill(DtoBll);
                // if (
                foreach (DataGridViewRow dgv in dgvBillItems.Rows)
                {

                    // first add bill product 
                    Dto.item itm = new Dto.item();
                    itm.itemId = Convert.ToInt32(dgv.Cells[0].Value.ToString());
                    itm.itemName = dgv.Cells[1].Value.ToString();
                    itm.price = float.Parse(dgv.Cells[2].Value.ToString());
                    itm.quantity = float.Parse(dgv.Cells[3].Value.ToString());
                    bll.addBillProduct(itm, DtoBll);

                    itmDao.decreaseQuantityToProduct(itm.itemId, itm.quantity);

                }

                MessageBox.Show("DONE ,BRO");
            }
        }

        private void dgvBillItems_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBillItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            

            //txtSubTotal.Text = dgvBillItems.Row[e.RowIndex][2];
            float sbtotal = 0;
            foreach (DataGridViewRow dgv in dgvBillItems.Rows)
            {

                sbtotal += float.Parse(dgv.Cells[2].Value.ToString()) * float.Parse(dgv.Cells[3].Value.ToString());

            }
            txtSubTotal.Text = sbtotal.ToString();
            txtReminder.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text) - float.Parse(txtPaid.Text)).ToString();
            quantityInt--;

        }

        private void dgvBillItems_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

    }
}


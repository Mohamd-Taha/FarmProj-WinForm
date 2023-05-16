using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm_Project.Presentation
{
    public partial class ProductTransactions : Form
    {
        Dao_Imp.Item itm = new Dao_Imp.Item();
        Dao_Imp.Utility utl = new Dao_Imp.Utility();
        DataTable dbdataset;
        DataTable dbdataset1;
        BindingSource source = new BindingSource();

        BindingSource source1 = new BindingSource();

        int selectedProductTransactionId;
        int selectedRow;


        public ProductTransactions()
        {
            InitializeComponent();
            dbdataset = itm.getAllProductTransaction();
            source.DataSource = dbdataset;
            productTransactionDGV.DataSource = source;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dateFilter.Checked == true)
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("Product LIKE '%{0}%' OR User LIKE'%{0}%' ", textBox1.Text);
                productTransactionDGV.DataSource = DV;
            }
            else
            {

                DataView DV = new DataView(dbdataset1);
                DV.RowFilter = string.Format("Product LIKE '%{0}%' OR User LIKE'%{0}%' ", textBox1.Text);
                productTransactionDGV.DataSource = DV;
            }
        }

        private void productTransactionDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = productTransactionDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUser.Text = productTransactionDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtItem.Text = productTransactionDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = productTransactionDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAmount.Text = productTransactionDGV.Rows[e.RowIndex].Cells[4].Value.ToString();

            selectedProductTransactionId = Int32.Parse(productTransactionDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            selectedRow = e.RowIndex;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                //geAllProductTransactionByDate(
                dbdataset1 = itm.geAllProductTransactionByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                source1.DataSource = dbdataset1;
                productTransactionDGV.DataSource = source1;
              }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dbdataset1 = itm.geAllProductTransactionByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                source1.DataSource = dbdataset1;
                productTransactionDGV.DataSource = source1;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dbdataset1 = itm.geAllProductTransactionByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                source1.DataSource = dbdataset1;
                productTransactionDGV.DataSource = source1;
            }
        }

        private void dateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (dateFilter.Checked == true)
            {
                productTransactionDGV.DataSource = source;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            utl.delteProductTransaction(Int32.Parse(txtid.Text));
            int X = Int32.Parse(itm.getProductIdByName(txtItem.Text).Rows[0][0].ToString());
            itm.decreaseQuantityToProduct(X,float.Parse(txtAmount.Text));
            MessageBox.Show("this transaction has been removed and the quantity of this item decreased");
            //update the DGV
            /*
            dbdataset = itm.getAllProductTransaction();
            source.DataSource = dbdataset;
            productTransactionDGV.DataSource = source;
             * */
        }
    }
}

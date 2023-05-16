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
using Farm_Project.Dto;

namespace Farm_Project.Presentation
{
    public partial class DescripedBill : Form
    {
        Dao_Imp.Bill bll = new Dao_Imp.Bill();
        
        public DescripedBill(Dto.Bill dtoBll)
        {
            InitializeComponent();
           // billProductsDGV.DataSource=bll.getAllDescrippedBill(x);
            BindingSource source = new BindingSource();
            source.DataSource = bll.getAllDescrippedBill(dtoBll.billid);
            billProductsDGV.DataSource = source;

            //mirror the values from the  passing parameter to the textboxes
            txtId.Text = dtoBll.billid.ToString();
            txtDate.Text = dtoBll.date.ToString();
            txtTotal.Text = dtoBll.total.ToString();
            txtPiad.Text = dtoBll.paid.ToString();
            txtDiscount.Text = dtoBll.discount.ToString();
            txtTrader.Text = dtoBll.trd.tradername;
            
            if ( dtoBll.total - dtoBll.discount == dtoBll.paid )
            {
                txtPayement.Text = "Complete paid";
            }
            else
            
                txtPayement.Text = "Not Complete";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLineTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

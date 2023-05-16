using Farm_Project.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farm_Project.DaoInterface;
using Farm_Project.Dao_Imp;
using Farm_Project.Dao_Imp;
using System.Data.SqlClient;
using Farm_Project.Dto;


namespace Farm_Project
{
    public partial class bills : Form
    {

        BindingSource source = new BindingSource();
        Dto.Bill dtoBll;
        Dao_Imp.Bill bll = new Dao_Imp.Bill();
        public  DataTable dt = new DataTable();
        public DataView currentState = new DataView();



        public bills()
        {
            InitializeComponent();
          //  dateTimePicker1.Enabled = false;
          //  dateTimePicker2.Enabled = false;
           // gunaShadowPanel1.
         //  BindingSource source = new BindingSource();
           // dt = bll.getAllBill();
            dt = bll.getAllBill();
            source.DataSource = dt; 
            billDGV.DataSource = source;
         }


        public bills(string traderName)
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            source.DataSource = bll.getBillByTraderName(traderName);
            billDGV.DataSource = source;
        }
        //new constractor to get the bills of specified trader rather than all bills for all traders

       
      //  DataTable dt =new DataTable();
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;

           
           
                dt=  bll.geAllProductTransactionByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                source.DataSource = dt;
                billDGV.DataSource = source;

            
         }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //refresh the dgv 
            dt = bll.getAllBill();
            source.DataSource = dt;
            billDGV.DataSource = source;

            //disable the date buttons 
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            dateFilter.Checked = true;
            allpayement.Checked = true;
            txtBillId.Text = null;
            txtTrader.Text = null;
            BindingSource source = new BindingSource();
            source.DataSource = bll.getAllBill();
            billDGV.DataSource = source;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                    BindingSource source = new BindingSource();
                    source.DataSource = bll.getBillById(Int16.Parse(txtBillId.Text));
                billDGV.DataSource = source;
            }
        }

        private void Trader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
               // bll.getBillByTraderName(txtTrader.Text);
                BindingSource source = new BindingSource();
                source.DataSource = bll.getBillByTraderName(txtTrader.Text);
                billDGV.DataSource = source;
            }

        }

        private void txtTrader_TextChanged(object sender, EventArgs e)
        {
            if (rdPaid.Checked == true)
            {


                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("Client LIKE '%{0}%' AND Payement = 'Complete' ", txtTrader.Text);
                billDGV.DataSource = DV;
                // currentState = DV;
            }
            else if (rdRemaining.Checked == true)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("Client LIKE '%{0}%' AND Payement = 'Not Complete' ", txtTrader.Text);
                billDGV.DataSource = DV;
                //string.Format(Client LIKE '%{0}%' , txtTrader.Text);
            }
            else
            {

                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("Client LIKE '%{0}%'", txtTrader.Text);
                billDGV.DataSource = DV;
            }
           // if ( txtTrader.Text==null)
                /*
         BindingSource source2 = new BindingSource();
         source2.DataSource = bll.getAllBill();
          billDGV.DataSource = source;
                 * */


        }

        private void billDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // the above comment is just a trial to pass the one bill attribute rather than retrive it from data base

            /*
            Dto.Bill b = new Dto.Bill();
            b.billid = Int16.Parse(billDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            b.
            b.total = float.Parse(billDGV.Rows[e.RowIndex].Cells[2].Value.ToString());
            b.paid=
             * 
             * */



            // price >> 
            // price per quantity 

            try {
            dtoBll = new Dto.Bill();
            string x = billDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            dtoBll.billid = Int16.Parse(x);
            //dtoBll.date =  Convert.ToDateTime(billDGV.Rows[e.RowIndex].Cells[7].Value.ToString());
            dtoBll.date = billDGV.Rows[e.RowIndex].Cells[8].Value.ToString();

            dtoBll.total = float.Parse(billDGV.Rows[e.RowIndex].Cells[3].Value.ToString());
            dtoBll.paid = float.Parse(billDGV.Rows[e.RowIndex].Cells[4].Value.ToString());
            dtoBll.quantity = Int16.Parse(billDGV.Rows[e.RowIndex].Cells[2].Value.ToString());
            dtoBll.discount = float.Parse(billDGV.Rows[e.RowIndex].Cells[7].Value.ToString());
            dtoBll.trd.tradername = billDGV.Rows[e.RowIndex].Cells[1].Value.ToString();


            DescripedBill DescripedBillObj = new DescripedBill(dtoBll);
            DescripedBillObj.Show();
            this.Close();
               }
            catch{Exception E;}
        }

        private void txtTrader_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdPaid_CheckedChanged(object sender, EventArgs e)
        {
           // DataRow[] dr = dt.Select("ali  =   Client");
          //  dt = dr.CopyToDataTable();

            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format(" Payement LIKE 'Complete'  AND Client LIKE '%{0}%' ", txtTrader.Text     );
            billDGV.DataSource = DV;

        }

        private void rdRemaining_CheckedChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format(" Payement LIKE 'Not Complete'  AND Client LIKE '%{0}%' ", txtTrader.Text);
            billDGV.DataSource = DV;
         }

        private void allpayement_CheckedChanged(object sender, EventArgs e)
        {
            /*
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format(" Payement LIKE '%%'       ");
            billDGV.DataSource = DV;
             */
            source.DataSource = dt;
            billDGV.DataSource = source;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt = bll.geAllProductTransactionByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            source.DataSource = dt;

            if (rdPaid.Checked == true)
            {
                // get the date specified to the date
                // make the paid filter
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format(" Payement LIKE 'Complete'       ");
                billDGV.DataSource = DV;
            }
            else if (rdRemaining.Checked==true)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format(" Payement LIKE 'Not Complete'       ");
                billDGV.DataSource = DV;
            
            }
            else
                billDGV.DataSource = source;


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dt = bll.geAllProductTransactionByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            source.DataSource = dt;

            if (rdPaid.Checked == true)
            {
                // get the date specified to the date
                // make the paid filter
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format(" Payement LIKE 'Complete'       ");
             //   DV.RowFilter = string.Format("Client LIKE '%{0}%' OR User LIKE'{0}%' OR Payement LIKE '{0}%'  ", txtTrader.Text);

                billDGV.DataSource = DV;
            }
            else if (rdRemaining.Checked == true)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format(" Payement LIKE 'Not Complete'       ");
              //  DV.RowFilter = string.Format("Client LIKE '%{0}%' OR User LIKE'{0}%' OR Payement LIKE '{0}%'  ", txtTrader.Text);

                billDGV.DataSource = DV;

            }
            else
                billDGV.DataSource = source;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dt.Select("Client='osama'");
            int x = dr.Length;
          // = x.ToString();
          
            DataTable mmm = new DataTable();
            foreach (DataRow row in dr)
            {
                mmm.ImportRow(row);
            }
            DataView dv = new DataView(mmm);
            dv.RowFilter = string.Format(" User  like 'Mohamed'");
            /*
            BindingSource BNDSRC = new BindingSource();
            BNDSRC.DataSource = mmm;
            dataGridView1.DataSource=BNDSRC;
             * */
           

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



// need function to 
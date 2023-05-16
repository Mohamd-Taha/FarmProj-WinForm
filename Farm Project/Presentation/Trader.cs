using System;
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
namespace Farm_Project.Presentation

{
    public partial class Trader : Form
    {
        Dao_Imp.Trader trd = new Dao_Imp.Trader();
        Dao_Imp.Bill bll = new Dao_Imp.Bill();
        DataTable dbtable = new DataTable();
        Dto.Trader Dtotrd;
        int selectedTrader;
        BindingSource source = new BindingSource();
        bool xSave = true;
        bool xEdit = true;
        bool editFlag = true;
        public Trader()
        {
         //   InitializeComponent();
            InitializeComponent();
            dbtable = trd.getAllTrader();
            source.DataSource = dbtable;
            traderDGV.DataSource = source;
            this.traderDGV.Font = new Font("Times", 12);

        }
        
        
        private void Trader_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bll.getBillByTraderName(txtName.Text).Read())
            {

                bills billObj = new bills();
                billObj.Show();
                billObj.txtTrader.Text = traderDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            traderDGV.Rows.Add(Int16.Parse(txtId.Text), txtName.Text, Int16.Parse(txtTelephone.Text), txtLocation.Text
                , Int16.Parse(txtReamining.Text));
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void traderDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = traderDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = traderDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLocation.Text = traderDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtReamining.Text = traderDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTelephone.Text = traderDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                selectedTrader = Int16.Parse(txtId.Text);
                //11-8-2021 i can't forget i write the following part
                Dtotrd = new Dto.Trader();
                Dtotrd.traderId = Int16.Parse(txtId.Text);
                Dtotrd.tradername = txtName.Text;
                Dtotrd.location = txtLocation.Text;
                Dtotrd.telephone = txtTelephone.Text;
                Dtotrd.remaining = float.Parse(txtReamining.Text);
                // enable the four buttons of edit and add
                btnEdit.Enabled = true;
                btnSaveEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnSaveAdd.Enabled = true;

                txtName.Enabled = false;
                txtLocation.Enabled = false;
                txtReamining.Enabled = false;
                txtTelephone.Enabled = false;
                xSave = true;
                xEdit = true;
            }
            catch { Exception E; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbtable);
            DV.RowFilter = string.Format("Name LIKE'%{0}%'  ", textBox1.Text);
            traderDGV.DataSource = DV;
            //
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //selectedTrader
          //  Dtotrd = new Dto.Trader();
            PayOff py = new PayOff(Dtotrd);
            py.Show();
            this.Close();
            
        }

        private void traderDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = traderDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = traderDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLocation.Text = traderDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtReamining.Text = traderDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTelephone.Text = traderDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                selectedTrader = Int16.Parse(txtId.Text);

                Dtotrd = new Dto.Trader();
                Dtotrd.traderId = Int16.Parse(txtId.Text);
                Dtotrd.tradername = txtName.Text;
                Dtotrd.location = txtLocation.Text;
                Dtotrd.telephone = txtTelephone.Text;
                Dtotrd.remaining = float.Parse(txtReamining.Text);

                //disable the textboxes
                txtName.Enabled = false;
                txtLocation.Enabled = false;
                txtReamining.Enabled = false;
                txtTelephone.Enabled = false;
            }
            catch { Exception E; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Change enabled attribute of all text boxes to true
            txtName.Enabled = true;
            txtLocation.Enabled = true;
            txtReamining.Enabled = true;
            txtTelephone.Enabled = true;
            txtId.Text = trd.getLastTraderId().ToString();
            // disable the other buttons
            btnEdit.Enabled = false;
            btnSaveEdit.Enabled = false;
           // clear the text boxes 
            txtName.Text = null;
            txtLocation.Text = null;
            txtReamining.Text = null;
            txtTelephone.Text=null;
            //change the flag to false
            xSave = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            txtName.Enabled = true;
            txtLocation.Enabled = true;
            txtTelephone.Enabled = true;
            btnAdd.Enabled = false;
            btnSaveAdd.Enabled = false;
            xEdit = false;
            editFlag = false;
        }

        private void traderDGV_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (xSave ==false)
            {
                if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtLocation.Text) || String.IsNullOrEmpty(txtReamining.Text) || String.IsNullOrEmpty(txtTelephone.Text))
                {
                    MessageBox.Show("Fill all attributes");
                }
                else
                {
                   

                    // make sure that the  client name is  UNIQUE     
                    //getTraderIdByName
                 //   if (trd.getTraderIdByName(txtName.Text) == null)
                    DataTable dttt = new DataTable();
                    dttt=trd.getTraderIdByName(txtName.Text);

                     if (dttt == null || dttt.Rows == null || dttt.Rows.Count == 0)
                    
                    {
                        Dtotrd = new Dto.Trader();
                        Dtotrd.traderId = Int16.Parse(txtId.Text);
                        Dtotrd.tradername = txtName.Text;
                        Dtotrd.location = txtLocation.Text;
                        Dtotrd.telephone = txtTelephone.Text;
                        Dtotrd.remaining = float.Parse(txtReamining.Text);
                        trd.addTrader(Dtotrd);
                        MessageBox.Show("your Client have been added sucessuflly");

                        // Refresh the DGV
                        dbtable = trd.getAllTrader();
                        source.DataSource = dbtable;
                        traderDGV.DataSource = source;
                    }
                    else
                    {
                         if (dttt.Rows[0][5].ToString() == "True")
                        MessageBox.Show("this client name \" " + txtName.Text + "\"," + "is already exist");
                         else
                         {
                            Dtotrd = new Dto.Trader();
                            Dtotrd.traderId = Int32.Parse(dttt.Rows[0][0].ToString());
                            Dtotrd.tradername = txtName.Text;
                            Dtotrd.telephone = txtTelephone.Text;
                            Dtotrd.location =txtLocation.Text;
                            Dtotrd.remaining = float.Parse(txtReamining.Text);


                            MessageBox.Show("this product was in the last but deleted and have the ID ," + dttt.Rows[0][0].ToString() + "  if u want to add it again by the same name , press Yes");
                            trd.addDeletedTrader(Dtotrd);

                            // Refresh the DGV
                            dbtable = trd.getAllTrader();
                            source.DataSource = dbtable;
                            traderDGV.DataSource = source;
                           


                         }
                    }
                
                }
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (xEdit == false)
            {
                if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtLocation.Text) || String.IsNullOrEmpty(txtReamining.Text) || String.IsNullOrEmpty(txtTelephone.Text))
                {
                    MessageBox.Show("Fill all attributes");
                }
                else
                {
                    Dtotrd = new Dto.Trader();
                Dtotrd.traderId = Int16.Parse(txtId.Text);
                Dtotrd.tradername = txtName.Text;
                Dtotrd.location = txtLocation.Text;
                Dtotrd.telephone = txtTelephone.Text;
                Dtotrd.remaining = float.Parse(txtReamining.Text);
                //call edit function
                trd.editTrader(Dtotrd);
                MessageBox.Show(" edit have been done");
                     // Refresh the DGV
                dbtable = trd.getAllTrader();
                source.DataSource = dbtable;
                traderDGV.DataSource = source;
                    //disable the Textboxes
                txtName.Enabled = false;
                txtLocation.Enabled = false;
                txtReamining.Enabled = false;
                txtTelephone.Enabled = false;



                }
            
            
            
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dbtable = trd.getAllTrader();
            source.DataSource = dbtable;
            traderDGV.DataSource = source;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            trd.deleteTrader(selectedTrader);
            MessageBox.Show("the client has been removed");
            // Refresh the DGV
            /*
            dbtable = trd.getAllTrader();
            source.DataSource = dbtable;
            traderDGV.DataSource = source;
             * */

        }
    }
}

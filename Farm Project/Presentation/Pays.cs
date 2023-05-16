using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farm_Project.Dto;
using Farm_Project.Dao_Imp;
using Farm_Project.Dto;

namespace Farm_Project.Presentation
{
    public partial class Pays : Form
    {
        Dao_Imp.Utility utl = new Dao_Imp.Utility();
        DataTable dbdataset = new DataTable();
        DataTable dbdataset1 = new DataTable();
        Dao_Imp.Trader trd = new Dao_Imp.Trader();
        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();
        

        public Pays()
        {

            InitializeComponent();
            dbdataset = utl.getAllPayOff();
            source.DataSource = dbdataset;
            paysDGV.DataSource = source;
            paysDGV.ReadOnly = true;
            //geAllPayOff
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;

            if (radioButton2.Checked == true)
            {
               dbdataset1= utl.geAllPayOffByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
               source1.DataSource = dbdataset1;
               paysDGV.DataSource = source1;


            }
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateFilter_CheckedChanged(object sender, EventArgs e)
        {

            paysDGV.DataSource = source;

          //  dateTimePicker1.Enabled = false;
          //  dateTimePicker2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dateFilter.Checked == true)
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("Client LIKE'%{0}%'  ", textBox1.Text);
                paysDGV.DataSource = DV;
            }
            else
            {

                DataView DV = new DataView(dbdataset1);
                DV.RowFilter = string.Format("Client LIKE'%{0}%'  ", textBox1.Text);
                paysDGV.DataSource = DV;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dbdataset1 = utl.geAllPayOffByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                source1.DataSource = dbdataset1;
                paysDGV.DataSource = source1;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dbdataset1 = utl.geAllPayOffByDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                source1.DataSource = dbdataset1;
                paysDGV.DataSource = source1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void paysDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Dto.Trader DtoTrd = new Dto.Trader();
            int id = Int32.Parse(trd.getTraderIdByName(paysDGV.Rows[e.RowIndex].Cells[2].ToString()).Rows[0][0].ToString());
            DtoTrd.traderId = id;
            DataTable DT = new DataTable();
            DT = trd.getTraderByid(id);
            DtoTrd.tradername = DT.Rows[0][1].ToString();
            DtoTrd.telephone = DT.Rows[0][2].ToString();
            DtoTrd.location = DT.Rows[0][3].ToString();
            DtoTrd.remaining = float.Parse( DT.Rows[0][4].ToString());

            PayOff py = new PayOff(DtoTrd);
            py.Show();

            
        }

        private void paysDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            txtid.Text = paysDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUser.Text = paysDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtClient.Text = paysDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = paysDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAmount.Text = paysDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            utl.deletePayOff(Int32.Parse(txtid.Text));
            int y = Int32.Parse(trd.getTraderIdByName(txtClient.Text).Rows[0][0].ToString());
            if (trd.getTraderIdByName(txtClient.Text).Rows[0][5].ToString() == "False")
                MessageBox.Show("this client doesn't exist");
            else
            {
                trd.iecreaseDebitToTrader(y, float.Parse(txtAmount.Text));
                MessageBox.Show("this transaction has been removed and the remaining of this client increased");
            }


        }
    }
}

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

namespace Farm_Project.Presentation
{
    public partial class Money_Transactions : Form
    {
        DataTable dbdatabaseWalletTransactions = new DataTable();
        DataTable dbdatabaseExpenses = new DataTable();
        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();
        Dao_Imp.Utility utl = new Dao_Imp.Utility();
        int selectedExpenseId;
        float selectedExpenseAmount;

        int selectedWalletId;
        float selectedWalletAmount;
      
        bool x=true;
        bool y = true;
        
        public Money_Transactions()
        {
            InitializeComponent();

            //bind wallet trrans dgv 
            dbdatabaseWalletTransactions = utl.geTAllWalletTransaction();
            source.DataSource = dbdatabaseWalletTransactions;
            WalletDGV.DataSource = source;

            //bind expense dgv
            dbdatabaseExpenses = utl.getAllExpense();
            source1.DataSource = dbdatabaseExpenses;
            expenseDGV.DataSource = source1;
            //MAKE TWO dgv READONLY
            expenseDGV.ReadOnly = true;
            WalletDGV.ReadOnly = true;
            
            txtuserMoeny.Text = login.UserId.ToString()+ ",  "  + login.UserName;
            TxtUserExpense.Text = login.UserId.ToString() + ",  " + login.UserName;

            txtTotalWalletMoney.Text = utl.getTotalWalletMoney().ToString();
            txtTotalExpense.Text = utl.getTotalExpense().ToString();

        }
        

       // dataGridView1.ReadOnly

        private void Money_Transactions_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtuserMoeny.Text) || String.IsNullOrEmpty(txtAmountMoney.Text) || String.IsNullOrEmpty(txtDescMoney.Text))
            {

                MessageBox.Show(" Fill All Fields");


            }
            else
            {
                //ExpensesDGV.Rows.Add(Int16.Parse(idExpenxeTxt.Text), userExpenxetxt.Text, dateTimePicker1.Text, descriptionExpenxeTxt.Text, amountExpenxeTxt.Text);
                if (x == false)
                {
                    utl.addMoney(Convert.ToInt32(TxtidMoney.Text), dateTimePicker1.Value.Date, float.Parse(txtAmountMoney.Text), login.UserId, txtDescMoney.Text);
                    MessageBox.Show("MONEY ADDEDD ,DONE");
                    //increse the current money
                    utl.increaseCurrentMoeny(float.Parse(txtAmountMoney.Text));
                    utl.increaseWalletMoney(float.Parse(txtAmountMoney.Text));
                    ////////////////
                    
                    
                    // update the presentation 

                    TxtidMoney.Text = utl.getLastWalletTransactionId().ToString();
                    //refresh the DGV
                    dbdatabaseWalletTransactions = utl.geTAllWalletTransaction();
                    source.DataSource = dbdatabaseWalletTransactions;
                    WalletDGV.DataSource = source;
                    

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //7/8/2021 , I CAN'T REMEMBER I USE THIS CONDITION , TO CHECK FROM WHAT ?
           // if (x == 1)
        //    {
            /*
            try
            {
                // this part is responsible to add the new expense to DGV 
                
                TxtidMoney.Text = WalletDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtuserMoeny.Text = WalletDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker1.Text = WalletDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDescMoney.Text = WalletDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAmountMoney.Text = WalletDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                 
                //////////////////////////

                txtAmountMoney.Enabled = false;
                txtDescMoney.Enabled = false;
                dateTimePicker1.Enabled = false;
                x = true;

            }
            catch { Exception E; }
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtUserExpense.Text) || String.IsNullOrEmpty(txtAmountExpense.Text) || String.IsNullOrEmpty(txtDescExpense.Text))
            {

                MessageBox.Show(" Fill All Fields");


            }
            else
            {
                //ExpensesDGV.Rows.Add(Int16.Parse(idExpenxeTxt.Text), userExpenxetxt.Text, dateTimePicker1.Text, descriptionExpenxeTxt.Text, amountExpenxeTxt.Text);
                if (y == false)
                {

                    utl.addExpense(utl.getLastExpenseId(), dateTimePicker2.Value.Date, float.Parse(txtAmountExpense.Text), login.UserId, txtDescExpense.Text);
                    MessageBox.Show("Expense ADDEDD ,DONE");
                    //decrease the current money 
                    utl.decreaseCurrentMoeny(float.Parse(txtAmountExpense.Text));
                    utl.increasetotalExpense(float.Parse(txtAmountExpense.Text));

                    //update the presentatio
                    TxtidMoney.Text = utl.getLastExpenseId().ToString();
                    //REFRESH THE DGV
                    dbdatabaseExpenses = utl.getAllExpense();
                    source1.DataSource = dbdatabaseExpenses;
                    expenseDGV.DataSource = source1;

                
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // idExpenxeTxt.Text = null;
          //  userExpenxetxt.Text = null;
            dateTimePicker1.Text = null;
            txtDescMoney.Text = null;
            txtAmountMoney.Text = null;
            //make all buttons read only false

          //  idExpenxeTxt.ReadOnly = false;
           // userExpenxetxt.ReadOnly = false;
            txtDescMoney.Enabled = true;
            txtAmountMoney.Enabled = true;
           // txtuserMoeny.Enabled = true;
            dateTimePicker1.Enabled = true;
            // change the read only attributr 
            txtDescMoney.ReadOnly = false;
            txtAmountMoney.ReadOnly = false;

            TxtidMoney.Text = utl.getLastWalletTransactionId().ToString();
            x = false;


            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtAmountExpense.Text=null;
            txtDescExpense.Text = null;

            txtAmountExpense.Enabled = true;
            txtDescExpense.Enabled = true;
            dateTimePicker2.Enabled = true;
            txtIdExpense.Text = utl.getLastWalletTransactionId().ToString();
            y = false;
        }

        private void WalletDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // this part is responsible to add the new expense to DGV 

                TxtidMoney.Text = WalletDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtuserMoeny.Text = WalletDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker1.Text = WalletDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDescMoney.Text = WalletDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAmountMoney.Text = WalletDGV.Rows[e.RowIndex].Cells[3].Value.ToString();

                //////////////////////////

                txtAmountMoney.Enabled = false;
                txtDescMoney.Enabled = false;
                dateTimePicker1.Enabled = false;
                x = true;
                //reflect the forst two cells 
                  selectedWalletId=Int32.Parse(WalletDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                  selectedWalletAmount = Int32.Parse(WalletDGV.Rows[e.RowIndex].Cells[3].Value.ToString());


            }
            catch { Exception E; }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DDD_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdExpense.Text = expenseDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtUserExpense.Text = expenseDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker2.Text = expenseDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDescExpense.Text = expenseDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAmountExpense.Text = expenseDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            //turn enable to off 
            txtDescExpense.Enabled = false;
            dateTimePicker2.Enabled = false;
            txtAmountExpense.Enabled = false;

            //get the id of tht selected expense 
            selectedExpenseId = Int32.Parse( expenseDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            selectedExpenseAmount = float.Parse(expenseDGV.Rows[e.RowIndex].Cells[4].Value.ToString());





        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this action will lead to  increase the current money by the expense amount , if you don't need this press no ");
            utl.deleteExpense(selectedExpenseId);
            utl.increaseCurrentMoeny(selectedExpenseAmount);
            utl.decreasetotalExpense(selectedExpenseAmount);
            //update the DGV
            dbdatabaseExpenses = utl.getAllExpense();
            source1.DataSource = dbdatabaseExpenses;
            expenseDGV.DataSource = source1;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            MessageBox.Show("this action will lead to  increase the current money by the expense amount , if you don't need this press no ");

            utl.deleteWalletTransaction(selectedWalletId);
            utl.decreaseCurrentMoeny(selectedWalletAmount);
            utl.decreaseWalletMoney(selectedWalletAmount);

            //update the WalletDGV

            dbdatabaseWalletTransactions = utl.geTAllWalletTransaction();
            source.DataSource = dbdatabaseWalletTransactions;
            WalletDGV.DataSource = source;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Farm_Project.MoneyTransactions;

namespace Farm_Project.Presentation
{
    public partial class Home_Screen : Form
    {
        public Home_Screen(string name)
        {
            InitializeComponent();
            DateTime dateTime = new DateTime();

            GOGO.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
            gunaLineTextBox1.Text = login.UserName;
            txtCurrentMoney.Text = login.currentMoney.ToString();
        }
        //another construcor 
        public Home_Screen()
        {
            InitializeComponent();
            DateTime dateTime = new DateTime();

            GOGO.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
           
        }
        //All Objext may be need
        Trader traderObj;
        bills billsObj;
        items itemsObj;
        users usersObj;
        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {
            usersObj = new users();
            usersObj.Show();
        }

        private void Home_Screen_MouseMove(object sender, MouseEventArgs e)
        {
            GOGO.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            traderObj = new Trader();
            traderObj.Show();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            billsObj = new bills();
            billsObj.Show();
            
        }

        private void gunaCircleButton3_Click(object sender, EventArgs e)
        {
            itemsObj = new items();
            itemsObj.Show();

        }

        private void gunaCircleButton5_Click(object sender, EventArgs e)
        {
            Money_Transactions MT = new Money_Transactions();
            MT.Show();
        }

        private void gunaCircleButton6_Click(object sender, EventArgs e)
        {
            SellingBill22222 bb = new SellingBill22222();
            bb.Show();
        }

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            Pays pyys = new Pays();
            pyys.Show();
        }

        private void gunaGradientCircleButton2_Click(object sender, EventArgs e)
        {
            ProductTransactions PT = new ProductTransactions();
            PT.Show();
        }

        private void Home_Screen_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void date_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

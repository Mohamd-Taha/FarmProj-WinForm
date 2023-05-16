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
using System.Data.SqlClient;
using Farm_Project.Dao_Imp;
namespace Farm_Project
{
    public partial class login : Form
    {
        DataTable dt;
        public static string UserName;
        public static int UserId;
        public static float currentMoney;
        Dao_Imp.Utility utl = new Utility();

        public login()
        {
            InitializeComponent();
           
        }
        Dao_Imp.user usr = new Dao_Imp.user();
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            
           if (usr.searchLogin(textBox1.Text, textBox3.Text))
            {


             UserName = textBox1.Text.ToLower() ;
            UserId=usr.getUserIDBylogin(textBox1.Text, textBox3.Text);

            dt = new DataTable();
         
               
                Home_Screen OBJ = new Home_Screen(textBox1.Text);
                OBJ.Show();
                this.Close();
                currentMoney=  utl.getCurrentMoney();
                
            }
           else
            {
                MessageBox.Show("Name or Password is incorrect");
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

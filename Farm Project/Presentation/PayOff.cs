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
    public partial class PayOff : Form
    {
        Dao_Imp.Trader trd = new Dao_Imp.Trader();
        Dao_Imp.Utility utl = new Utility();
         
        public PayOff(Dto.Trader trd)
        {
            InitializeComponent();
            txtClientId.Text = trd.traderId.ToString();
            txtName.Text = trd.tradername;
            txtLocation.Text = trd.location;
            txtTelephone.Text = trd.telephone;
            txtReamining.Text = trd.remaining.ToString();
            txtId.Text = utl.getlastPayOff().ToString();
            txtUser.Text = login.UserId.ToString() + ",  " + login.UserName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int distance;
            if (int.TryParse(txtAmount.Text, out distance) || txtAmount.Text == "")
            {
                // it's a valid integer => you could use the distance variable here
                try
                {
                    txtAmountAfter.Text = (float.Parse(txtReamining.Text) - float.Parse(txtAmount.Text)).ToString();
                }
                catch { Exception E; }
            }
            else
            {
                MessageBox.Show("Please Enter Valid numeric Value");
                txtAmount.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {

                MessageBox.Show(" Enter the amount of money to pay ");
               
            }
            else
            {

                if (float.Parse(txtAmountAfter.Text) < 0)
                {
                    MessageBox.Show("the paid value must be equal or less than the remaining value, edit the value and try again");
                    txtAmount.Text = null;
                    txtAmountAfter.Text = null;
                }
                else
                {
                    float remind = float.Parse(txtReamining.Text);
                    utl.addPayOff( login.UserId, Int16.Parse(txtClientId.Text), float.Parse(txtAmount.Text),
                        dateTimePicker1.Value.Date);
                    trd.decreaseDebitToTrader(Int16.Parse(txtClientId.Text), float.Parse(txtAmount.Text));
                    
                    MessageBox.Show("The remaining value have been decreases");
                    txtReamining.Text = (remind - float.Parse(txtAmount.Text)).ToString();
                    txtAmountAfter.Text = (remind - float.Parse(txtAmount.Text)).ToString();
                    txtAmount.Text = "0";

                    
                
                
                }
            }


        }
    }
}

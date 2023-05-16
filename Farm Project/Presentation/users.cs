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
    public partial class users : Form
    {
        Dao_Imp.user usr = new user();
        Dao_Imp.Utility utl = new Utility();
        Dto.User DTOusr;

        DataTable dbtable = new DataTable();
        BindingSource source = new BindingSource();

        bool editFlag = true;
        int selectedUserId;


        public users()
        {
            InitializeComponent();
            dbtable = usr.getAllUsers();
            source.DataSource = dbtable;
            uerDGV.DataSource = source;
            txtCurrentMoney.Text=utl.getCurrentMoney().ToString();
            this.uerDGV.Font = new Font("Times", 12);

         }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(combRole.Text) )
            {
                MessageBox.Show("Fill all attributes ");

            }
            else
            {
                uerDGV.Rows.Add(Int16.Parse(txtId.Text), txtName.Text, txtPassword.Text, combRole.Text);
                // put here the  DATA ACESS method 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtPassword.ReadOnly = false;
            combRole.Enabled = true;


        }

        private void uerDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          //  txtName.ReadOnly = true;
         //   txtPassword.ReadOnly = true;
          //  combRole.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This action will result to remove some money transaction for ever , are you sure",
                      "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    MessageBox.Show("The user have been removed for ever ");

                    // put method to delete 
                    break;

                case DialogResult.No:
                    MessageBox.Show("Nothing is removed , thanks for your understanding ");
                    break;
            }
        }

        private void uerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // make mirror code from dataGridView to the group of text boxes on the left

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbtable);
          //  string rd_type = rd_all == true ? "": rd_paid == true ? "paid" : "remaining";
         //   DV.RowFilter = string.Format("Name LIKE '%{0}%' OR Role LIKE'%{0}%' and bill_type = '%{1}%' ", textBox.text , rd_type );
            DV.RowFilter = string.Format(" Name LIKE '%{0}%' OR Role LIKE'%{0}%' ", textBox5.Text);
            uerDGV.DataSource = DV;
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtId.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(combRole.Text))
            {
                MessageBox.Show("Fill all attributes ");

            }
            else
            {
                // instintiate new instance to pass it as a parameter

                DTOusr = new Dto.User();
                DTOusr.id = Int16.Parse(txtId.Text);
                DTOusr.name = txtName.Text;
                DTOusr.role = combRole.Text;
                DTOusr.password = txtPassword.Text;
                usr.addUser(DTOusr);
                MessageBox.Show("the User have been added successfully");
                txtId.Text = txtId.Text = usr.getLastUserId().ToString();
                txtName.Text = null;
                txtPassword.Text = null;
                combRole.Text = null;

                //Refresh the DGV
                dbtable = usr.getAllUsers();
                source.DataSource = dbtable;
                uerDGV.DataSource = source;


                //the comment below is a trying to show the added row immediatley
                //uerDGV.Rows.Add(Int16.Parse(txtId.Text), txtName.Text, txtPassword.Text, combRole.Text);
                // put here the  DATA ACESS method 
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtPassword.ReadOnly = false;
            combRole.Enabled = true;
            editFlag = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            txtPassword.Text = null;
           combRole.Text = null;
            txtName.Enabled = true;
            txtPassword.Enabled = true;
            combRole.Enabled = true;
            // Disable other buttons
            btnEdit.Enabled = false;
            btnSaveEdit.Enabled = false;


            
            txtId.Text= usr.getLastUserId().ToString();
        }

        private void combRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                                
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (editFlag == false)
            {
                DTOusr = new Dto.User();
                DTOusr.id = Int16.Parse(txtId.Text);
                DTOusr.name = txtName.Text;
                DTOusr.role = combRole.Text;
                DTOusr.password = txtPassword.Text;
                usr.editUser(DTOusr);
                MessageBox.Show("your edit have been done");
            }
        }

        private void uerDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txtId.Text = uerDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = uerDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                combRole.Text = uerDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPassword.Text = uerDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                btnEdit.Enabled = true;
                btnSaveEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnSaveAdd.Enabled = true;
                // disable the textboxes again
                txtName.Enabled = false;
                txtPassword.Enabled = false;
                combRole.Enabled = false;
                editFlag = true;
                selectedUserId = Int32.Parse(uerDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch { Exception E; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dbtable = usr.getAllUsers();
            source.DataSource = dbtable;
            uerDGV.DataSource = source;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("are you sure ? ");
            usr.deleteUserById(selectedUserId);
            //update the DGV
            dbtable = usr.getAllUsers();
            source.DataSource = dbtable;
            uerDGV.DataSource = source;
            uerDGV.Update();
        }
    }
}

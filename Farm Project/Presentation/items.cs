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
    public partial class items : Form
    {
        Dao_Imp.Item itm = new Dao_Imp.Item();
        DataTable dbdataset = new DataTable();
        BindingSource source = new BindingSource();
        int selectedProductId;

        bool addButtonFlag = false;
        Dto.item dtoitm;
        public items()
        {
            InitializeComponent();
            dbdataset=itm.getAllItems();
            source.DataSource = dbdataset;
            itemDGV.DataSource = source;
            btnEdit.Enabled = true;
            btnSaveEdit.Enabled = true;
            this.itemDGV.Font = new Font("Times", 12);
           
        }
        AddProductTransaction ProductTransactionObj;

        private void items_Load(object sender, EventArgs e)
        {

        }
        bool x=true;
        private void button1_Click(object sender, EventArgs e)
        {
            
            x=!x;
            txtName.Enabled = true;
            txtName.Text = null;
            txtPrice.Enabled = true;
            txtPrice.Text = null;
            txtQuantity.Enabled = true;
            txtQuantity.Text = null;
            btnEdit.Enabled=x  ;
            btnSaveEdit.Enabled = x;
           // AddItem n = new AddItem();
           // n.Show();
            txtId.Text=itm.getLastItemId().ToString();
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //take the values of product attributes to send it to the next form
                dtoitm = new Dto.item();
                dtoitm.itemId = Int16.Parse(txtId.Text);
                dtoitm.itemName = txtName.Text;
                dtoitm.price = float.Parse(txtPrice.Text);
                dtoitm.quantity = float.Parse(txtQuantity.Text);


                ProductTransactionObj = new AddProductTransaction(dtoitm);
                ProductTransactionObj.Show();
                this.Close();
            }
            catch { Exception E; }
        }

        private void itemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPrice.Text) || String.IsNullOrEmpty(txtQuantity.Text) )
            {
                MessageBox.Show("Fill all attributes ");

            }
            else
            {

                if (x == false)
                {
                    DataTable dtTest =new DataTable();
                    dtTest = itm.getProductIdByName(txtName.Text);

                    //check if there was an item with the same name or no
                    if (dtTest == null || dtTest.Rows == null || dtTest.Rows.Count == 0)
                    {

                        // new item instance to pass it 
                        dtoitm = new Dto.item();
                        dtoitm.itemId = Int16.Parse(txtId.Text);
                        dtoitm.itemName = txtName.Text;
                        dtoitm.price = float.Parse(txtPrice.Text);
                        dtoitm.quantity = float.Parse(txtQuantity.Text);
                        //make dynamic 

                        itm.addItem(dtoitm);

                        MessageBox.Show("the item added successfully");
                        btnEdit.Enabled = true;
                        btnSaveEdit.Enabled = true;
                        txtId.Text = itm.getLastItemId().ToString();
                        txtName.Text = null;
                        txtPrice.Text = null;
                        txtQuantity.Text = null;

                        // Refresh the DGV 
                        dbdataset = itm.getAllItems();
                        source.DataSource = dbdataset;
                        itemDGV.DataSource = source;

                    }
                    else
                    {
                        if (dtTest.Rows[0][4].ToString() == "True")
                            MessageBox.Show("this Product name \" " + txtName.Text + "\"," + "is already exist");
                        else
                        {
                            dtoitm = new Dto.item();
                            dtoitm.itemId = Int32.Parse(dtTest.Rows[0][0].ToString());
                            dtoitm.itemName = txtName.Text;
                            dtoitm.price = float.Parse(txtPrice.Text);
                            dtoitm.quantity = float.Parse(txtQuantity.Text);

                            MessageBox.Show("this product was in the last but deleted and have the ID ," + dtTest.Rows[0][0].ToString() + "  if u want to add it again by the same name , press Yes");
                            itm.addDeletedProduct(dtoitm);

                            //update the DGV
                            dbdataset = itm.getAllItems();
                            source.DataSource = dbdataset;
                            itemDGV.DataSource = source;
                           


                        }
                    }



                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Name LIKE'%{0}%'  ", textBox1.Text);
            itemDGV.DataSource = DV;
        }

        private void itemDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // i want to find a better way to refer to the content of the cell click method rather than copy the same code
            try
            {
                txtId.Text = itemDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = itemDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPrice.Text = itemDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtQuantity.Text = itemDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                x = true;
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;

                txtName.Enabled = false;
                txtPrice.Enabled = false;
                txtQuantity.Enabled = false;
                selectedProductId = Int32.Parse(itemDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
             
            }
            catch { Exception E; }
        }

        private void itemDGV_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            dtoitm = new Dto.item();
            dtoitm.itemId = Int16.Parse(txtId.Text);
            dtoitm.itemName = txtName.Text;
            dtoitm.price = float.Parse(txtPrice.Text);
            dtoitm.quantity = float.Parse(txtQuantity.Text);
            itm.editProduct(dtoitm);
            MessageBox.Show("your edit have been done");
            // Refresh the DGV 
            dbdataset = itm.getAllItems();
            source.DataSource = dbdataset;
            itemDGV.DataSource = source;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtPrice.Enabled = true;
            txtName.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dbdataset = itm.getAllItems();
            BindingSource source = new BindingSource();
            source.DataSource = dbdataset;
            itemDGV.DataSource = source;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            itm.deleteProductById(selectedProductId);
            MessageBox.Show("this item has been removed");
            dbdataset = itm.getAllItems();
            source.DataSource = dbdataset;
            itemDGV.DataSource = source;
        }

        private void btnSaveDelete_Click(object sender, EventArgs e)
        {

        }
    }
}

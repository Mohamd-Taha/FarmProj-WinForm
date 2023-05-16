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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            Dao_Imp.Item itm = new Dao_Imp.Item();


            txtId.Text = itm.getLastItemId().ToString();
            InitializeComponent();
        }
    }
}

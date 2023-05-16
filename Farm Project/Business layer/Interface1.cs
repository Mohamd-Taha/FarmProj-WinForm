using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Farm_Project.Dto;

namespace Farm_Project.Business_layer
{
    interface Interface1
    {
        //User function
        bool adduser(int id, string name, float price, int quantity);
        bool editUser( int id,string name, float price, int quantity);
        DataTable getallusers ();
        DataTable GetspecificUser(int id);

        //we will use the methond in below on the selling_bill screen
        void AddDescrippedDroductFromDGV(DataTable dt);

        //we will use the methond in below on the login screen
        bool checklogin(String name, String password);

        //we will use it in selling_bill screen to compute the total value
        float gettotalmoneyforbill(DataTable dt);

        //function in sellingBill screen 
        void AddRowinDGV(item prdct, DataRow DR);
       







        //



    }
}

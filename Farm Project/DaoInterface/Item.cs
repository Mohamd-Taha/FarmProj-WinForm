using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm_Project.DaoInterface
{
    interface Item
    {
        DataTable getallitems();
        void Addquantity(Dto.item Itm,DateTime dt,User usr);
        DataTable searchItem(String itm);
        void editItem(Dto.item itm);
        void deleteItem(Dto.item itm);
        //method will be used in detailedBill to add every item in the bill
        void AddbillToDetailedBill(Dto.item itm,int detailedid,int billId);
    }
}

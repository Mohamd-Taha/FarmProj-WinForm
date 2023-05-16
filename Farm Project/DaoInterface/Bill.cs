using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Farm_Project.DaoInterface
{
    interface Bill
    {
        DataTable getallBills();
        DataTable searchById(int id);
        DataTable SearchByTrader(String trd);
        void AddBill(Dto.Bill bll);
        void deleteBill(Dto.Bill bll);


        // Generic Function to apply all contraints e.g. payement type , Date , trader 
    }
}

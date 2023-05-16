using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Farm_Project.DaoInterface
{
    interface Trader
    {
        DataTable getalTraders();
        void addTrader(Dto.Trader trd);
        //!!!!!!!!!!!!!!!!maybe we need a way to pay off debts!!!!!!!!!!!!!
        //void Addquantity(Dto.item Itm);
        DataTable searchTrader(String trd);
        void editTrader(Dto.Trader trd);
        void deleteTrader(Dto.Trader trd);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm_Project.DaoInterface
{
    interface User
    {
        DataTable getallusers();
       // void Addquantity(Dto.item Itm);
        DataTable searchuser(String usr);
        void editusr(Dto.User usr);
        void deleteusr(Dto.User usr);
    }
}

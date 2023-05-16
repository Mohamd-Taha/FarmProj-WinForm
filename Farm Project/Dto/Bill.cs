using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm_Project.Dto;

namespace Farm_Project.Dto
{
  public  class Bill
    {
       public Trader trd = new Trader();
       public User billUser = new User();
        
        public int billid;
      //  public DateTime date;
        public string date;
        public float total;
        public float paid;
        public float discount;
        public int quantity;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDAL;
using QLPMDTO;
namespace QLPMBUS
{
    public class ChandoanBUS
    {
        private ChandoanDAL cdDAL;
        public ChandoanBUS()
        {
            cdDAL = new ChandoanDAL();
        }
        public bool them(ChandoanDTO cd)
        {
            return cdDAL.them(cd);
        }
        public List<ChandoanDTO> select()
        {
            return cdDAL.select();
        }
    }
}

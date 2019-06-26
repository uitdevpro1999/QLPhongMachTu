using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDAL;
using QLPMDTO;

namespace QLPMBUS
{
    public class BenhBUS
    {
        private BenhDAL beDAL;
        public BenhBUS()
        {
            beDAL = new BenhDAL();
        }
        public bool them(BenhDTO be)
        {
            bool re = beDAL.them(be);
            return re;
        }
        public bool sua(BenhDTO be, string maBenhold)
        {
            bool re = beDAL.sua(be, maBenhold);
            return re;
        }
        public bool xoa(BenhDTO be)
        {
            bool re = beDAL.xoa(be);
            return true;
        }
        public List<BenhDTO> select()
        {
            return beDAL.select();
        }
        public List<BenhDTO> selectByKeyWord(string sKeyword)
        {
            return beDAL.selectByKeyWord(sKeyword);
        }
        public int autogenerate_mabenh()
        {
            return beDAL.autogenerate_mabenh();
        }
    }
}

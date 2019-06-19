using QLPMDAL;
using QLPMDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLPMBUS
{
    public class BenhNhanBUS
    {
        private BenhNhanDAL bnDAL;
        public BenhNhanBUS()
        {
            bnDAL = new BenhNhanDAL();
        }
        public bool them(BenhNhanDTO bn)
        {
            bool re = bnDAL.them(bn);
            return re;
        }
        public bool sua(BenhNhanDTO bn,string maBNold)
        {
            bool re = bnDAL.sua(bn,maBNold);
            return re;
        }
        public bool themmapkb(BenhNhanDTO bn, string mapkb)
        {
            bool re = bnDAL.themmapkb(bn, mapkb);
            return re;
        }

        public bool xoa(BenhNhanDTO bn)
        {
            bool re = bnDAL.xoa(bn);
            return true;
        }
        //public bool timkiem(string mabn)
        //{
        //    bool re = bnDAL.timkiem(mabn);
        //    return true;
        //}
        

        public List<BenhNhanDTO> select()
        {
            return bnDAL.select();
        }
        public List<BenhNhanDTO> selectByKeyWord(string sKeyword)
        {
            return bnDAL.selectByKeyWord(sKeyword);
        }
        public int autogenerate_ma(List<BenhNhanDTO> listbenhnhan)
        {
            int max=0;
            foreach (BenhNhanDTO bn in listbenhnhan)
            {
                if (bn.MaBN > max)
                {
                    max = bn.MaBN;
                }
            }
            return max;
        }
    }
}

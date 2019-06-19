using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDAL;
using QLPMDTO;
namespace QLPMBUS
{
    public class HoadonBUS
    {
        private HoadonDAL hdDAL;
        public HoadonBUS()
        {
            hdDAL = new HoadonDAL();
        }
        public bool them(HoadonDTO hd)
        {
            bool re = hdDAL.them(hd);
            return re;
        }
        public float tienthuoc(HoadonDTO hd,string mapkb)
        {
           float re = hdDAL.tienthuoc(hd,mapkb);
            return re;
        }
       
    }
}

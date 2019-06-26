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
        public int autogenerate_mahd()
        {
            return hdDAL.autogenerate_mahd();
        }
        public List<HoadonDTO> selectByMonth(string month, string year)
        {
            return hdDAL.selectByMonth(month, year);
        }
        public int sobenhnhan(string ngHD)
        {
            return hdDAL.sobenhnhan(ngHD);
        }
        public float doanhthu(string ngHD)
        {
            return hdDAL.doanhthu(ngHD);
        }
    }
}

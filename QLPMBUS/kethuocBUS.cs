using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDAL;
using QLPMDTO;
namespace QLPMBUS
{
    public class KethuocBUS
    {
        private KethuocDAL ktDAL;
        public KethuocBUS()
        {
            ktDAL = new KethuocDAL();
        }
        public bool kethuoc(KethuocDTO kt)
        {
            bool re = ktDAL.kethuoc(kt);
            return re;
        }
        public List<KethuocDTO> selectbypkb(string mapkb)
        {
            return ktDAL.selectbypkb(mapkb);
        }
        public List<KethuocDTO> baocaobymonth(string month, string year)
        {
            return ktDAL.baocaobymonth(month, year);
        }
        public int solandungbymonth(string mathuoc, string month, string year)
        {
            return ktDAL.solandungbymonth(mathuoc, month, year);
        }
    }
}

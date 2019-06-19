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

    }
}

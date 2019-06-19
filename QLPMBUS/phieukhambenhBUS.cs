using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QLPMDTO;
using QLPMDAL;
namespace QLPMBUS
{
    public class PhieukhambenhBUS
    {
        private PhieukhambenhDAL pkbDAL;
        public PhieukhambenhBUS()
        {
            pkbDAL = new PhieukhambenhDAL();
        }
        public bool them(PhieukhambenhDTO pkb)
        {
            bool re = pkbDAL.them(pkb);
            return re;
        }
        public bool sua(PhieukhambenhDTO pkb)
        {
            bool re = pkbDAL.sua(pkb);
            return re;
        }
        public List<PhieukhambenhDTO> select()
        {
            return pkbDAL.select();
        }
        public List<PhieukhambenhDTO> selectByKeyWord(string skeyword)
        {
            return pkbDAL.selectByKeyWord(skeyword);
        }
        public int autogenerate_mapkb()
        {
            return pkbDAL.autogenerate_mapkb();
        }
    }
}

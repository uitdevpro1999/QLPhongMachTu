using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPMDAL;
using QLPMDTO;

namespace QLPMBUS
{
    public class ThuocBUS
    {
        private ThuocDAL thDAL;
        public ThuocBUS()
        {
            thDAL = new ThuocDAL();
        }
        public bool them(ThuocDTO th)
        {
            bool re = thDAL.them(th);
            return re;
        }
        public bool sua(ThuocDTO th, string maThuocold)
        {
            bool re = thDAL.sua(th, maThuocold);
            return re;
        }
        public List<ThuocDTO> select()
        {
            return thDAL.select();
        }
        public bool xoa(ThuocDTO th)
        {
            bool re = thDAL.xoa(th);
            return re;
        }
        public List<ThuocDTO> selectByKeyWord(string sKeyword)
        {
            return thDAL.selectByKeyWord(sKeyword);
        }
        public int autogenerate_mathuoc()
        {
            return thDAL.autogenerate_mathuoc();
        }
        public List<ThuocDTO> selectbypkb(string mapkb)
        {
            return thDAL.selectbypkb(mapkb);
        }
        public List<ThuocDTO> baocaobymonth(string month, string year)
        {
            return thDAL.baocaobymonth(month, year);
        }
        public List<Donvi> getdonvi()
        {
            return thDAL.getdonvi();
        }
        public List<Cachdung> getcachdung()
        {
            return thDAL.getcachdung();
        }
        public bool thaydoiCD(string cdmoi, string cdcu)
        {
            bool re = thDAL.thaydoiCD(cdmoi,cdcu);
            return re;
        }
        public bool thaydoiDV(string dvmoi, string dvcu)
        {
            bool re = thDAL.thaydoiDV(dvmoi, dvcu);
            return re;
        }
        public bool xoaDV(string dv)
        {
            bool re = thDAL.xoaDV(dv);
            return re;
        }
        public bool xoaCD(string cd)
        {
            bool re = thDAL.xoaCD(cd);
            return re;
        }
        public bool themdv(string dv)
        {
            bool re = thDAL.themdv(dv);
            return re;
        }
        public bool themcd(string cd)
        {
            bool re = thDAL.themcd(cd);
            return re;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPMDTO
{
    public class PhieukhambenhDTO
    {
        private string maPkb;
        private DateTime ngayKham;
        private string trieuChung;


        public string MaPkb { get => maPkb; set => maPkb = value; }
        public string TrieuChung { get => trieuChung; set => trieuChung = value; }
        public DateTime NgayKham { get => ngayKham; set => ngayKham = value; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPMDTO
{
    public class HoadonDTO
    {
        private string maHd;
        private DateTime ngayHd;
        private string maPkb;
        private float tongTien;

        public string MaPkb { get => maPkb; set => maPkb = value; }
        public string MaHd { get => maHd; set => maHd = value; }
        public DateTime NgayHd { get => ngayHd; set => ngayHd = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
    }
}

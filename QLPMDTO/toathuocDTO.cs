using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPMDTO
{
    public class ToathuocDTO
    {
        private string maToa;
        private DateTime ngayKetoa;
        private string maPkb;
      


        public string MaToa { get => maToa; set => maToa = value; }
        public string MaPkb { get => maPkb; set => maPkb = value; }
        public DateTime NgayKetoa { get => ngayKetoa; set => ngayKetoa = value; }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPMDTO
{
    public class NhanvienDTO
    {
        private int maNV;
        private string tenNV;
        private string diachiNV;
        private string gtNV;
        private string sodtNV;
        private string chucvu;
        private DateTime ngsinhNV;


        public int MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string DiachiNV { get => diachiNV; set => diachiNV = value; }
        public string GtBN { get => gtNV; set => gtNV = value; }
        public DateTime NgsinhBN { get => ngsinhNV; set => ngsinhNV = value; }
        private string SodtNV { get => sodtNV; set => sodtNV = value; }
        private string Chucvu { get => chucvu; set => chucvu = value; }

    }
}

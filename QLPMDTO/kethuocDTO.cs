using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPMDTO
{
    public class KethuocDTO
    {
        private string maThuoc;
        private string maToa;
        private int soLuong;



        public string MaThuoc { get => maThuoc; set => maThuoc = value; }
        public string MaToa { get => maToa; set => maToa = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}

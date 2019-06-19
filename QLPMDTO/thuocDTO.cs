using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPMDTO
{
    public class ThuocDTO
    {
        private string maThuoc;
        private string tenThuoc;
        private float donGia;
        private string dVt;
        private string cachDung;


        public string MaThuoc { get => maThuoc; set => maThuoc = value; }
        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public string DVT { get => dVt; set => dVt = value; }
        public string CachDung { get => cachDung; set => cachDung = value; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QLPMDAL;
using QLPMDTO;
using QLPMBUS;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace QLPM
{
    /// <summary>
    /// Interaction logic for HoaDon.xaml
    /// </summary>
    public partial class HoaDon : Window
    {
        public HoadonBUS hdBus;
        public ThuocBUS thBus;
        public KethuocBUS ktBus;
        public float tkham=30000;
        public float tt;
        public int stt;
        public HoaDon()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            PhieukhambenhBUS pkb = new PhieukhambenhBUS();
            pkb.tk();
            hdBus = new HoadonBUS();
            mahd.Text=hdBus.autogenerate_mahd().ToString();
            ngayhd.Content = DateTime.UtcNow.Date.ToString();
            load_combobox();
        }
        public void load_combobox()
        {
            BenhNhanBUS bnBus = new BenhNhanBUS();
            List<BenhNhanDTO> listBenhnhan = bnBus.select();
            this.loadData_Vao_Combobox(listBenhnhan);

        }
        public void load_TenBN()
        {
            BenhNhanBUS bnBus = new BenhNhanBUS();
            List<BenhNhanDTO> listBenhnhan = bnBus.select();
            this.loadData_TenBN(listBenhnhan);

        }
        private void loadData_Vao_Combobox(List<BenhNhanDTO> listBenhnhan)
        {

            if (listBenhnhan == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            foreach (BenhNhanDTO bn in listBenhnhan)
            {
                if (bn.MaPKB != null)
                {
                    mapkb.Items.Add(bn.MaPKB);
                }
            }
        }
        private void loadData_TenBN(List<BenhNhanDTO> listBenhnhan)
        {

            if (listBenhnhan == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            foreach (BenhNhanDTO bn in listBenhnhan)
            {
                if (bn.MaPKB == mapkb.Text)
                {
                    tenbn.Text = bn.TenBN;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tt = 0;
            stt = 1;
            hdBus = new HoadonBUS();
            
            HoadonDTO hd = new HoadonDTO();
            load_TenBN();
            load_data(mapkb.Text);
            string tthuoc=hdBus.tienthuoc(hd, mapkb.Text).ToString();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(tthuoc, System.Globalization.NumberStyles.AllowThousands);
            tienthuoc.Text = String.Format(culture, "{0:N0}", value);
            tienthuoc.Select(tienthuoc.Text.Length, 0);
            decimal value1 = decimal.Parse(PhieukhambenhDTO.TienKham.ToString(), System.Globalization.NumberStyles.AllowThousands);
            tienkham.Text = String.Format(culture, "{0:N0}", value1);
            tienkham.Select(tienkham.Text.Length, 0);
            string ttien = (float.Parse(tthuoc)+PhieukhambenhDTO.TienKham).ToString();
            tt = float.Parse(tthuoc)+tkham;
            decimal value2 = decimal.Parse(ttien, System.Globalization.NumberStyles.AllowThousands);
            tongtien.Text = String.Format(culture, "{0:N0}", value2);
            tongtien.Select(tongtien.Text.Length, 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HoadonDTO hd = new HoadonDTO();
            hd.MaHd = mahd.Text.ToString();
            hd.TongTien = tt;
            hd.MaPkb = mapkb.Text;
            hd.NgayHd = DateTime.UtcNow.Date;
            hdBus = new HoadonBUS();
            bool kq = hdBus.them(hd);
            if (kq == false)
                MessageBox.Show("Lưu hóa đơn thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            else
                MessageBox.Show("Lưu hóa đơn thành công", "Result");
        }
        public void load_data(string mapkb)
        {
            thBus = new ThuocBUS();
            ktBus = new KethuocBUS();
            List<ThuocDTO> listThuoc = thBus.selectbypkb(mapkb);
            List<KethuocDTO> listkethuoc = ktBus.selectbypkb(mapkb);
            this.loadData_Vao_GridView(listThuoc,listkethuoc);

        }
        private void loadData_Vao_GridView(List<ThuocDTO> listThuoc,List<KethuocDTO> listkethuoc)
        {

            if (listThuoc == null || listkethuoc==null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("tenThuoc", typeof(string));
            table.Columns.Add("DVT", typeof(string));
            table.Columns.Add("Dongia", typeof(string));
            table.Columns.Add("soLuong", typeof(string));
            table.Columns.Add("thanhTien", typeof(string));
            table.Columns.Add("sTT", typeof(int));
            foreach (ThuocDTO th in listThuoc)
            {
                foreach (KethuocDTO kt in listkethuoc)
                {
                    if (th.MaThuoc == kt.MaThuoc)
                    {
                       
                        DataRow row = table.NewRow();
                        row["tenThuoc"] = th.TenThuoc;
                        row["DVT"] = th.DVT;
                        row["Dongia"] = th.DonGia;
                        row["soLuong"] = kt.SoLuong;
                        row["thanhTien"] = (kt.SoLuong*th.DonGia).ToString();
                        row["sTT"] = stt;
                        table.Rows.Add(row);
                        stt += 1;            
                    }
                }
            }
            grid.ItemsSource = table.DefaultView;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

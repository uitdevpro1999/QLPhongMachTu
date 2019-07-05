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
using QLPMBUS;
using QLPMDTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLPM
{
    /// <summary>
    /// Interaction logic for suaThuoc.xaml
    /// </summary>
    public partial class suaThuoc : Window
    {
        public string temp;
        private ThuocBUS thBus;
        public suaThuoc()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {

            ThuocBUS thBus = new ThuocBUS();
            mathuoc.Text = thBus.autogenerate_mathuoc().ToString();
            List<Cachdung> listcd = thBus.getcachdung();
            List<Donvi> listdv = thBus.getdonvi();
            this.load_combobox(listdv, listcd);
        }
        private void load_combobox(List<Donvi> listdv, List<Cachdung> listcd)
        {
            if (listdv == null || listcd == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB","Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            DataTable table1 = new DataTable();

            table.Columns.Add("donVi", typeof(string));
            table1.Columns.Add("cachDung", typeof(string));
            foreach (Donvi dv in listdv)
            {
                DataRow row = table.NewRow();
                row["donVi"] = dv.DonVi;
                table.Rows.Add(row);
            }
            foreach (Cachdung cd in listcd)
            {
                DataRow row = table1.NewRow();
                row["cachDung"] = cd.CachDung;
                table1.Rows.Add(row);
            }
            donvi.ItemsSource = table.DefaultView;
            donvi.DisplayMemberPath = "donVi";
            cachdung.ItemsSource = table1.DefaultView;
            cachdung.DisplayMemberPath = "cachDung";
        }


        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            bool kt;
            try
            {
                float.Parse(dongia.Text);
                kt = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập số và không được để trống", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                kt = false;
            }
            if (kt == false)
            {
                dongia.Text = "";
                dongia.Focus();
            }
            else if (mathuoc.Text == null || tenthuoc.Text == null || cachdung.Text == "" || donvi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại thuốc");
            }
            else
            {
                ThuocDTO th = new ThuocDTO();
                th.MaThuoc = mathuoc.Text;
                th.TenThuoc = tenthuoc.Text;
                th.DonGia = float.Parse(dongia.Text);
                th.DVT = donvi.Text;
                th.CachDung = cachdung.Text;

                thBus = new ThuocBUS();
                bool kq = thBus.sua(th, temp);
                if (kq == false)
                    MessageBox.Show("Sửa Thuốc thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sửa Thuốc thành công", "Result");
            }
        }

        private void quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

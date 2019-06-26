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
    /// Interaction logic for xoaThuoc.xaml
    /// </summary>
    public partial class xoaThuoc : Window
    {
        private ThuocBUS thBus;
        private string temp;
        public xoaThuoc()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            thBus = new ThuocBUS();
            List<ThuocDTO> listThuoc = thBus.select();
            this.loadData_Vao_GridView(listThuoc);

        }
        private void loadData_Vao_GridView(List<ThuocDTO> listThuoc)
        {

            if (listThuoc == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("maThuoc", typeof(string));
            table.Columns.Add("tenThuoc", typeof(string));
            table.Columns.Add("DVT", typeof(string));
            table.Columns.Add("Dongia", typeof(float));
            table.Columns.Add("CachDung", typeof(string));
            foreach (ThuocDTO th in listThuoc)
            {
                DataRow row = table.NewRow();
                row["maThuoc"] = th.MaThuoc;
                row["tenThuoc"] = th.TenThuoc;
                row["DVT"] = th.DVT;
                row["Dongia"] = th.DonGia;
                row["CachDung"] = th.CachDung;
                table.Rows.Add(row);
            }
            grid.ItemsSource = table.DefaultView;
        }
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                xoa.IsEnabled = true;
                temp = row_selected["maThuoc"].ToString();
            }
            else
            {
                xoa.IsEnabled = false;
            }
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            ThuocDTO th=new ThuocDTO();
            th.MaThuoc = temp;
            thBus = new ThuocBUS();
            bool kq = thBus.xoa(th);
            if (kq == false)
                MessageBox.Show("Xóa Thuốc thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Xóa Thuốc thành công");
            load_data();
        }
    }
}

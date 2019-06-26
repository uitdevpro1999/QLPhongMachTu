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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using QLPMBUS;
using QLPMDAL;
using QLPMDTO;

namespace QLPM
{
    /// <summary>
    /// Interaction logic for Xoa.xaml
    /// </summary>
    public partial class Xoa : Window
    {
        private BenhNhanBUS bnBus;
        private string temp;
        public Xoa()
        {
            InitializeComponent();
            load_data();
        }

        public void load_data()
        {
            bnBus = new BenhNhanBUS();
            List<BenhNhanDTO> listBenhNhan = bnBus.select();
            this.loadData_Vao_GridView(listBenhNhan);

        }
        private void loadData_Vao_GridView(List<BenhNhanDTO> listBenhNhan)
        {

            if (listBenhNhan == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("maBN", typeof(string));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("NgaySinh", typeof(string));
            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("GioiTinh", typeof(string));
            foreach (BenhNhanDTO bn in listBenhNhan)
            {
                DataRow row = table.NewRow();
                row["maBN"] = bn.MaBN;
                row["tenBN"] = bn.TenBN;
                row["NgaySinh"] = bn.NgsinhBN;
                row["DiaChi"] = bn.DiachiBN;
                row["GioiTinh"] = bn.GtBN;
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
                temp= row_selected["maBN"].ToString();
            }
            else
            {
                xoa.IsEnabled = false;
            }
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            BenhNhanDTO bn = new BenhNhanDTO();
            bn.MaBN = int.Parse(temp);
            bnBus = new BenhNhanBUS();
            bool kq = bnBus.xoa(bn);
            if (kq == false)
                MessageBox.Show("Xóa Bệnh nhân thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Xóa Bệnh nhân thành công");
            load_data();
        }
    }
}

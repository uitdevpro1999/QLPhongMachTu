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
    /// Interaction logic for xoaBenh.xaml
    /// </summary>
    public partial class xoaBenh : Window
    {
        private BenhBUS beBus;
        private string temp;
        public xoaBenh()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            beBus = new BenhBUS();
            List<BenhDTO> listBenh = beBus.select();
            this.loadData_Vao_GridView(listBenh);

        }
        private void loadData_Vao_GridView(List<BenhDTO> listBenh)
        {

            if (listBenh == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("maBenh", typeof(string));
            table.Columns.Add("tenBenh", typeof(string));
            foreach (BenhDTO be in listBenh)
            {
                DataRow row = table.NewRow();
                row["maBenh"] = be.MaBenh;
                row["tenThuoc"] = be.TenBenh;
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
                temp = row_selected["maBenh"].ToString();
            }
            else
            {
                xoa.IsEnabled = false;
            }
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            BenhDTO be = new BenhDTO();
            be.MaBenh = temp;
            beBus = new BenhBUS();
            bool kq = beBus.xoa(be);
            if (kq == false)
                MessageBox.Show("Xóa Bệnh thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Xóa Bệnh thành công");
            load_data();
        }
    }
}

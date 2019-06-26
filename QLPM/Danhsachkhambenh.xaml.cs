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
using QLPM;
using QLPMDTO;
using QLPMBUS;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace QLPM
{
    /// <summary>
    /// Interaction logic for Danhsachkhambenh.xaml
    /// </summary>
    public partial class Danhsachkhambenh : Window
    {
        int mabenhnhan;
        MainWindow themwin;
        private BenhNhanBUS bnBus;
        private PhieukhambenhBUS pkbBus;
        private DataTable table;
        private BenhNhanDTO bn;
        public Danhsachkhambenh()
        {
            InitializeComponent();
           
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            themwin = new MainWindow();
            themwin.Show();
            themwin.them.Click += button_click;
            

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

            table = new DataTable();
            table.Columns.Add("maBN", typeof(int));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("NgaySinh", typeof(string));
            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("GioiTinh", typeof(string));
            pkbBus = new PhieukhambenhBUS();
            string ngkham;
            ngkham=String.Format("{0:M/d/yyyy}", ngaykham.SelectedDate);
            List<PhieukhambenhDTO> listpkb = pkbBus.selectByKeyWord(ngkham);
            foreach (BenhNhanDTO bn in listBenhNhan)
            {
                foreach (PhieukhambenhDTO pkb in listpkb)
                {   if (bn.MaPKB == pkb.MaPkb)
                    {
                        DataRow row = table.NewRow();
                        row["maBN"]=bn.MaBN;
                        row["tenBN"] = bn.TenBN;
                        row["NgaySinh"] = bn.NgsinhBN;
                        row["DiaChi"] = bn.DiachiBN;
                        row["GioiTinh"] = bn.GtBN;
                        table.Rows.Add(row);
                    }
                }
            }
            danhsach.ItemsSource = table.DefaultView;
        }
        public void button_click(object sender, EventArgs e)
        {
            mabenhnhan = int.Parse(themwin.mabenhnhan.Text.ToString());
            load_data();
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            bn = new BenhNhanDTO();
            if (row_selected != null)
            {

                bn.TenBN = row_selected["tenBN"].ToString();
                bn.MaBN = int.Parse(row_selected["maBN"].ToString());
                bn.DiachiBN = row_selected["DiaChi"].ToString();
                bn.NgsinhBN = DateTime.Parse(row_selected["NgaySinh"].ToString());
                bn.GtBN = row_selected["GioiTinh"].ToString();
            }

        }
        private void ngaykham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            load_data();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            themPKB pkb = new themPKB();
            pkb.mabenhnhan.Text = bn.MaBN.ToString();
            pkb.hoten.Content = bn.TenBN;
            pkb.Show();
        }
    }
}

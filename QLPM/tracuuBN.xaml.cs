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
    /// Interaction logic for tracuuBN.xaml
    /// </summary>
    public partial class tracuuBN : Window
    {
        public DataTable db1 = new DataTable("tblBENHNHAN");
        private BenhNhanBUS bnBus;
        private BenhNhanDTO bn;
        private string temp;
        public tracuuBN()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            db1.Clear();
            db1.Columns.Add("MaHD", typeof(System.Int32));


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
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("maBN", typeof(int));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("NgaySinh", typeof(string));
            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("GioiTinh", typeof(string));
            table.Columns.Add("maPKB", typeof(string));
            foreach (BenhNhanDTO bn in listBenhNhan)
            {
                DataRow row = table.NewRow();
                row["maBN"] = int.Parse(bn.MaBN.ToString());
                row["tenBN"] = bn.TenBN;
                row["NgaySinh"] = bn.NgsinhBN;
                row["DiaChi"] = bn.DiachiBN;
                row["GioiTinh"] = bn.GtBN;
                row["maPKB"] = bn.MaPKB;
                table.Rows.Add(row);
            }
            grid.ItemsSource = table.DefaultView;
        }
        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            bnBus = new BenhNhanBUS();
            string sKeyword = mabn.Text;
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<BenhNhanDTO> listBenhNhan = bnBus.select();
                this.loadData_Vao_GridView(listBenhNhan);
            }
            else
            {
                List<BenhNhanDTO> listBenhNhan = bnBus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listBenhNhan);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Sua sua = new Sua();
            DataTable db = new DataTable();
            sua.temp = bn.MaBN.ToString();
            sua.mabenhnhan.Text = bn.MaBN.ToString();
            sua.hoten.Text = bn.TenBN;
            sua.ngaysinh.SelectedDate = bn.NgsinhBN;
            sua.diachi.Text = bn.DiachiBN;
            if(bn.GtBN=="Nam")
            {
                sua.radio1.IsChecked = true;
                sua.radio2.IsChecked = false;
            } else
                if(bn.GtBN == "Nữ")
            {
                sua.radio1.IsChecked = false;
                sua.radio2.IsChecked = true;
            }
            sua.Show();
            sua.quaylai.Click += quaylai_click;
             
        }
        private void quaylai_click(object sender, EventArgs e)
        {
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
                temp = bn.MaBN.ToString();

            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            bn = new BenhNhanDTO();
            bn.MaBN = int.Parse(temp);
            bnBus = new BenhNhanBUS();
            bool kq = bnBus.xoa(bn);
            if (kq == false)
                MessageBox.Show("Xóa Bệnh nhân thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            else
                MessageBox.Show("Xóa Bệnh nhân thành công", "Result");
            load_data();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }    
}

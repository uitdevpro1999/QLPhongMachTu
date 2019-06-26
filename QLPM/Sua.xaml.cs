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
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private BenhNhanBUS bnBus;
        public string temp;
        public Sua()
        {
            InitializeComponent();
            
        }
        //public void load_data()
        //{
        //    bnBus = new BenhNhanBUS();
        //    List<BenhNhanDTO> listBenhNhan = bnBus.select();
        //    this.loadData_Vao_GridView(listBenhNhan);

        //}
        //private void loadData_Vao_GridView(List<BenhNhanDTO> listBenhNhan)
        //{
           
        //    if (listBenhNhan == null)
        //    {
        //        MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
        //        return;
        //    }
           
        //    DataTable table = new DataTable();
        //    table.Columns.Add("maBN", typeof(string));
        //    table.Columns.Add("tenBN", typeof(string));
        //    table.Columns.Add("NgaySinh", typeof(string));
        //    table.Columns.Add("DiaChi", typeof(string));
        //    table.Columns.Add("GioiTinh", typeof(string));
        //    foreach (BenhNhanDTO bn in listBenhNhan)
        //    {
        //        DataRow row = table.NewRow();
        //        row["maBN"] = bn.MaBN;
        //        row["tenBN"] = bn.TenBN;
        //        row["NgaySinh"] = bn.NgsinhBN;
        //        row["DiaChi"] = bn.DiachiBN;
        //        row["GioiTinh"] = bn.GtBN;
        //        table.Rows.Add(row);
        //    }
        //    grid.ItemsSource = table.DefaultView;
        //}

        //private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DataGrid gd = (DataGrid)sender;
        //    DataRowView row_selected = gd.SelectedItem as DataRowView;
        //    if (row_selected != null)
        //    {
        //        hoten.IsEnabled = true;
        //        mabenhnhan.IsEnabled = true;
        //        diachi.IsEnabled = true;
        //        ngaysinh.IsEnabled = true;
        //        radio2.IsEnabled = true;
        //        radio1.IsEnabled = true;
        //        hoten.Text = row_selected["tenBN"].ToString();
        //        mabenhnhan.Text = row_selected["maBN"].ToString();
        //        temp= row_selected["maBN"].ToString();
        //        diachi.Text = row_selected["DiaChi"].ToString();
        //        ngaysinh.SelectedDate=DateTime.Parse(row_selected["NgaySinh"].ToString());
        //        if (row_selected["GioiTinh"].ToString() == "Nam")
        //        {
        //            radio1.IsChecked = true;
        //            radio2.IsChecked = false;
        //        }
        //        else if (row_selected["GioiTinh"].ToString() == "Nữ")
        //        {
        //            radio2.IsChecked = true;
        //            radio1.IsChecked = false;
        //        }
        //        else
        //        {
        //            radio2.IsChecked = false;
        //            radio1.IsChecked = false;
        //        }
        //    }
        //    else if(row_selected==null)
        //    {
        //        hoten.Text = null;
        //        mabenhnhan.Text = null;
        //        diachi.Text = null;
        //        ngaysinh.SelectedDate = null;
        //        hoten.IsEnabled = false;
        //        mabenhnhan.IsEnabled = false;
        //        diachi.IsEnabled = false;
        //        ngaysinh.IsEnabled = false;
        //        radio2.IsChecked = false;
        //        radio1.IsChecked = false;
        //        radio2.IsEnabled = false;
        //        radio1.IsEnabled = false;
        //    }
        //}

        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            BenhNhanDTO bn = new BenhNhanDTO();
            bn.MaBN = int.Parse(mabenhnhan.Text);
            bn.TenBN = hoten.Text;
            if (radio1.IsChecked == true)
            {
                bn.GtBN = "Nam";
            }
            else
            {
                bn.GtBN = "Nữ";
            }
            bn.NgsinhBN = ngaysinh.SelectedDate.Value;
            bn.DiachiBN = diachi.Text;
            bnBus = new BenhNhanBUS();
            bool kq = bnBus.sua(bn,temp);
            if (kq == false)
                MessageBox.Show("Sửa Bệnh nhân thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Sửa Bệnh nhân thành công");
            
        }

        private void Quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

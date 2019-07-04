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
    /// Interaction logic for danhsachthuoc.xaml
    /// </summary>
    public partial class danhsachthuoc : Window
    {
        public DataTable db1 = new DataTable("tblTHUOC");
        private ThuocBUS thBus;
        private ThuocDTO th;
        private string temp;
        public danhsachthuoc()
        {
            InitializeComponent();
            load();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string query = string.Empty;
        //    query += "Select * from [tblTHUOC] where maBN=@maBN ";
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = query;
        //    cmd.Parameters.AddWithValue("@maBN", mabn.Text);
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable db1 = new DataTable("tblBENHNHAN");
        //    da.Fill(db1);
        //    grid.ItemsSource = db1.DefaultView;

        //}
        private void load()
        {
            db1.Clear();
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
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            thBus = new ThuocBUS();
            string sKeyword = mathuoc.Text;
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ThuocDTO> listThuoc = thBus.select();
                this.loadData_Vao_GridView(listThuoc);
            }
            else
            {
                List<ThuocDTO> listThuoc = thBus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listThuoc);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            suaThuoc suath = new suaThuoc();
            DataTable db = new DataTable();
            suath.temp = th.MaThuoc.ToString();
            suath.mathuoc.Text = th.MaThuoc.ToString();
            suath.tenthuoc.Text = th.TenThuoc.ToString();
            suath.donvi.Text = th.DVT.ToString();
            suath.cachdung.Text = th.CachDung.ToString();
            suath.dongia.Text = th.DonGia.ToString();
            suath.Show();
            suath.quaylai.Click += quaylai_click;

        }
        private void quaylai_click(object sender, EventArgs e)
        {
            load_data();
        }
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            th = new ThuocDTO();
            if (row_selected != null)
            {

                th.TenThuoc = row_selected["tenThuoc"].ToString();
                th.MaThuoc = row_selected["maThuoc"].ToString();
                th.DVT = row_selected["DVT"].ToString();
                th.DonGia = float.Parse(row_selected["Dongia"].ToString());
                th.CachDung = row_selected["CachDung"].ToString();
                temp = th.MaThuoc.ToString();

            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            th = new ThuocDTO();
            th.MaThuoc = temp;
            thBus = new ThuocBUS();
            bool kq = thBus.xoa(th);
            if (kq == false)
                MessageBox.Show("Xóa Thuốc thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            else
                MessageBox.Show("Xóa Thuốc thành công","Result");
            load_data();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            themThuoc thth = new themThuoc();
            thth.Show();
        }
    }
}


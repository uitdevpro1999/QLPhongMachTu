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
using MaterialDesignThemes;
using MaterialDesignColors;
namespace QLPM
{
    /// <summary>
    /// Interaction logic for danhsachbenh.xaml
    /// </summary>
    public partial class danhsachbenh : Window
    {
        public DataTable db1 = new DataTable("tblBENH");
        private BenhBUS beBus;
        private BenhDTO be;
        private string temp;
        public danhsachbenh()
        {
            InitializeComponent();
        }
        private void load()
        {
            db1.Clear();
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
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB","Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("maBenh", typeof(string));
            table.Columns.Add("tenBenh", typeof(string));
            foreach (BenhDTO be in listBenh)
            {
                DataRow row = table.NewRow();
                row["maBenh"] = be.MaBenh;
                row["tenBenh"] = be.TenBenh;
         
                table.Rows.Add(row);
            }
            grid.ItemsSource = table.DefaultView;
        }
        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            beBus = new BenhBUS();
            string sKeyword = mabenh.Text;
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<BenhDTO> listBenh = beBus.select();
                this.loadData_Vao_GridView(listBenh);
            }
            else
            {
                List<BenhDTO> listBenh = beBus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listBenh);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            suaBenh suabe = new suaBenh();
            DataTable db = new DataTable();
            suabe.temp = be.MaBenh.ToString();
            suabe.mabenh.Text = be.MaBenh.ToString();
            suabe.tenbenh.Text = be.TenBenh.ToString();
            suabe.quaylai.Click += quaylai_click;

        }
        private void quaylai_click(object sender, EventArgs e)
        {
            load_data();
        }
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            be = new BenhDTO();
            if (row_selected != null)
            {

                be.TenBenh = row_selected["tenBenh"].ToString();
                be.MaBenh = row_selected["maBenh"].ToString();
                temp = be.MaBenh.ToString();

            }

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            be = new BenhDTO();
            be.MaBenh = temp;
            beBus = new BenhBUS();
            bool kq = beBus.xoa(be);
            if (kq == false)
                MessageBox.Show("Xóa loại bệnh thất bại. Vui lòng kiểm tra lại dũ liệu","Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            else
                MessageBox.Show("Xóa loại bệnh thành công","Result");
            load_data();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            themBenh thbe = new themBenh();
            thbe.Show();
        }
    }
}

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
    /// Interaction logic for Ketoa.xaml
    /// </summary>
    public partial class Ketoa : Window
    {
        
        public DataTable db1 = new DataTable();
        private ToathuocBUS ttBus;
        private KethuocBUS ktBus;
        private ThuocBUS thBus;
        string id;
        public Ketoa()
        {
            InitializeComponent();
            load_data();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int row = db1.Rows.Count;
            ToathuocDTO tt = new ToathuocDTO();
            tt.MaToa = matoa.Text.ToString();
            tt.MaPkb = mapkb.Text.ToString();
            tt.NgayKetoa = DateTime.UtcNow.Date;
            ttBus = new ToathuocBUS();
            bool kq = ttBus.them(tt);
            if (kq == false)
                MessageBox.Show("Kê toa thất bại", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            else
            { MessageBox.Show("Kê toa thành công", "Result"); }
            KethuocDTO kt = new KethuocDTO();
            for (int i = 0; i < row; i++)
            {
                kt.MaToa = matoa.Text;
                TextBlock x = grid.Columns[0].GetCellContent(grid.Items[i]) as TextBlock;
                kt.MaThuoc = x.Text;
                TextBlock y = grid.Columns[5].GetCellContent(grid.Items[i]) as TextBlock;
                int val;
                bool check = Int32.TryParse(y.Text,out val);
                if (!check)
                {
                    return;
                }
                else { kt.SoLuong = val; }
                ktBus = new KethuocBUS();
                bool kq1 =ktBus.kethuoc(kt);
            }
        }
        
        public void load_data()
        {
            db1.Clear();
            db1.Columns.Add("soLuong", typeof(System.Int32));
            db1.Columns.Add("maThuoc", typeof(string));
            db1.Columns.Add("tenThuoc", typeof(string));
            db1.Columns.Add("DVT", typeof(string));
            db1.Columns.Add("Dongia", typeof(float));
            db1.Columns.Add("CachDung", typeof(string));
            ThuocBUS thBus = new ThuocBUS();
            List<ThuocDTO> listThuoc = thBus.select();
            this.loadData_Vao_Combobox(listThuoc);
            ttBus = new ToathuocBUS();
            matoa.Text = ttBus.autogenerate_matoa().ToString();

        }
        private void loadData_Vao_Combobox(List<ThuocDTO> listThuoc)
        {

            if (listThuoc == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            
            table.Columns.Add("tenThuoc", typeof(string));
            foreach (ThuocDTO th in listThuoc)
            {
                DataRow row = table.NewRow();
                row["tenThuoc"] = th.TenThuoc;
                table.Rows.Add(row);
            }
            thuoc.ItemsSource = table.DefaultView;
            thuoc.DisplayMemberPath = "tenThuoc";
        }
     
        private void loadData_Vao_GridView(List<ThuocDTO> listThuoc, string soluong)
        {

            if (listThuoc == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            } 
            foreach (ThuocDTO th in listThuoc)
            {
                if (th.TenThuoc == thuoc.Text)
                {
                    DataRow row = db1.NewRow();
                    row["maThuoc"] = th.MaThuoc;
                    row["tenThuoc"] = th.TenThuoc;
                    row["DVT"] = th.DVT;
                    row["Dongia"] = th.DonGia;
                    row["CachDung"] = th.CachDung;
                    row["soLuong"] = soluong;
                    db1.Rows.Add(row);
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            bool notExist=true;
            DataRow[] rows = db1.Select();
            if (rows.Length == 0)
            {
                thBus = new ThuocBUS();
                List<ThuocDTO> listThuoc = thBus.select();
                this.loadData_Vao_GridView(listThuoc, soluong.Text);
                grid.ItemsSource = db1.DefaultView;
            }
            else
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i]["tenThuoc"].ToString() == thuoc.Text.ToString())
                    {
                        int sl = 0;
                        sl = int.Parse(rows[i]["soLuong"].ToString());
                        db1.Rows[i][0] = sl + int.Parse(soluong.Text.ToString());
                        notExist = false;
                        break;
                    }   
                }
                if(notExist==true)
                {
                    thBus = new ThuocBUS();
                    List<ThuocDTO> listThuoc = thBus.select();
                    this.loadData_Vao_GridView(listThuoc, soluong.Text);
                    grid.ItemsSource = db1.DefaultView;
                }
            }
            
            
            

        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            
            if (row_selected != null)
            {

                id = row_selected["maThuoc"].ToString();

            }
           
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataRow[] drr = db1.Select("maThuoc='" + id + "'"); 
            for (int i = 0; i < drr.Length; i++)
                drr[i].Delete();
            db1.AcceptChanges();
            grid.ItemsSource = db1.DefaultView;
        }
    }
}

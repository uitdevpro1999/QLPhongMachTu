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
using QLPMDTO;
using QLPMBUS;
using System.Data;
namespace QLPM
{
    /// <summary>
    /// Interaction logic for baocaodoanhthu.xaml
    /// </summary>
    public partial class baocaodoanhthu : Window
    {
        public HoadonBUS hdBus;
        public int stt;
        public baocaodoanhthu()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            stt = 1;
            string month = thang.Text.ToString();
            string year = nam.Text.ToString();
            hdBus = new HoadonBUS();
            List<HoadonDTO> listHoadon = hdBus.selectByMonth(month, year);
            this.loadData_Vao_GridView(listHoadon);
        }
        private void loadData_Vao_GridView(List<HoadonDTO> listhoadon)
        {
            if (listhoadon == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB","Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            float tongdoanhthu=0;
            DataTable table = new DataTable();
            table.Columns.Add("nglapHD", typeof(string));
            table.Columns.Add("sobn", typeof(int));
            table.Columns.Add("doanhthu", typeof(float));
            table.Columns.Add("sTT", typeof(int));
            table.Columns.Add("tyle", typeof(string));
            foreach (HoadonDTO hd in listhoadon)
            {
                string ngkham;
                ngkham = String.Format("{0:M/d/yyyy}", hd.NgayHd);
                tongdoanhthu+=float.Parse(hdBus.doanhthu(ngkham).ToString());
            }
            foreach (HoadonDTO hd in listhoadon)
            { 
                        DataRow row = table.NewRow();
                        row["nglapHD"] = hd.NgayHd.ToString();
                        string ngkham;
                        ngkham = String.Format("{0:M/d/yyyy}", hd.NgayHd);
                        row["sobn"] = int.Parse(hdBus.sobenhnhan(ngkham).ToString());
                        row["doanhthu"] = float.Parse(hdBus.doanhthu(ngkham).ToString());
                        row["tyle"] = Math.Round(((double)float.Parse(hdBus.doanhthu(ngkham).ToString()) / (double)tongdoanhthu) * 100,2).ToString()+"%";
                        row["sTT"] = stt;
                        table.Rows.Add(row);
                        stt += 1;
            }
            
            grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            load_data();
        }
    }
}


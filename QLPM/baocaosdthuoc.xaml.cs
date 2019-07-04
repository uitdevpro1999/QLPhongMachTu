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
    /// Interaction logic for baocaosdthuoc.xaml
    /// </summary>
    public partial class baocaosdthuoc : Window
    {
        public ThuocBUS thBus;
        public KethuocBUS ktBus;
        public int stt;
        public baocaosdthuoc()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            stt = 1;
            string month = thang.Text.ToString();
            string year = nam.Text.ToString();
            thBus = new ThuocBUS();
            ktBus = new KethuocBUS();
            List<ThuocDTO> listThuoc = thBus.baocaobymonth(month, year);
            List<KethuocDTO> listkethuoc = ktBus.baocaobymonth(month, year);
            this.loadData_Vao_GridView(listThuoc, listkethuoc, month, year);
        }
        private void loadData_Vao_GridView(List<ThuocDTO> listThuoc, List<KethuocDTO> listkethuoc, string month, string year)
        {
            if (listThuoc == null || listkethuoc == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB","Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("tenThuoc", typeof(string));
            table.Columns.Add("DVT", typeof(string));
            table.Columns.Add("sTT", typeof(int));
            table.Columns.Add("sLD",typeof(int));
            table.Columns.Add("soLuong", typeof(int));
            foreach (ThuocDTO th in listThuoc)
            {
                foreach (KethuocDTO kt in listkethuoc)
                {
                    if (th.MaThuoc == kt.MaThuoc)
                    {

                        DataRow row = table.NewRow();
                        row["tenThuoc"] = th.TenThuoc;
                        row["DVT"] = th.DVT;
                        row["soLuong"] = kt.SoLuong;
                        row["sLD"] = ktBus.solandungbymonth(th.MaThuoc, month, year);
                        row["sTT"] = stt;
                        table.Rows.Add(row);
                        stt += 1;
                    }
                }
            }
            grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            load_data();
        }
    }
}

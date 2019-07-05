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
using System.Windows.Media.TextFormatting;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLPMDTO;
using QLPMBUS;




namespace QLPM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BenhNhanBUS bnBus;
        public MainWindow()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            bnBus = new BenhNhanBUS();
            mabenhnhan.Text = bnBus.autogenerate_mabn().ToString();
        }
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            if (mabenhnhan.Text == null || hoten.Text == "" || (radio1.IsChecked == false && radio2.IsChecked == false) || ngaysinh.SelectedDate == null || diachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bệnh nhân");
            }
            else
            {
                BenhNhanDTO bn = new BenhNhanDTO();
                PhieukhambenhDTO pkb = new PhieukhambenhDTO();
                PhieukhambenhBUS pkbBus = new PhieukhambenhBUS();
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
                bn.MaPKB = pkbBus.autogenerate_mapkb().ToString();
                pkb.MaPkb = pkbBus.autogenerate_mapkb().ToString();
                pkb.NgayKham = DateTime.UtcNow.Date;
                bnBus = new BenhNhanBUS();
                bool kq1 = pkbBus.them(pkb);
                bool kq2 = bnBus.them(bn);
                if (kq1 == true && kq2 == true)
                    MessageBox.Show("Thêm Bệnh nhân thành công", "Result");
                else
                    MessageBox.Show("Thêm Bệnh nhân thất bại", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

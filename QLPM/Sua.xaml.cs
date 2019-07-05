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
        
        private void Sua_Click(object sender, RoutedEventArgs e)
        {

            if (mabenhnhan.Text == null || hoten.Text == "" || (radio1.IsChecked == false && radio2.IsChecked == false) || ngaysinh.SelectedDate == null || diachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bệnh nhân");
            }
            else
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
                bool kq = bnBus.sua(bn, temp);
                if (kq == false)
                    MessageBox.Show("Sửa Bệnh nhân thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sửa Bệnh nhân thành công", "Result");
            }
            
        }

        private void Quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

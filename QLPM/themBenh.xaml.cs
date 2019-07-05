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
namespace QLPM
{
    /// <summary>
    /// Interaction logic for themBenh.xaml
    /// </summary>
    public partial class themBenh : Window
    {
        private BenhBUS beBus;
        public themBenh()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            beBus = new BenhBUS();
            mabenh.Text = beBus.autogenerate_mabenh().ToString();
        }
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            if (mabenh.Text == null || tenbenh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại bệnh");
            }
            else
            {
                BenhDTO be = new BenhDTO();
                be.MaBenh = mabenh.Text;
                be.TenBenh = tenbenh.Text;

                beBus = new BenhBUS();
                bool kq = beBus.them(be);
                if (kq == false)
                    MessageBox.Show("Thêm loại bệnh thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Thêm loại bệnh thành công", "Result");
            }

        }
    }
}

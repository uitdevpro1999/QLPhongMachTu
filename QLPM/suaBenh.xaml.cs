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
using System.Data.SqlClient;
using System.Configuration;
namespace QLPM
{
    /// <summary>
    /// Interaction logic for suaBenh.xaml
    /// </summary>
    public partial class suaBenh : Window
    {
        private BenhBUS beBus;
        public string temp;
        public suaBenh()
        {
            InitializeComponent();
           
        }           
        private void Sua_Click(object sender, RoutedEventArgs e)
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
                bool kq = beBus.sua(be, temp);
                if (kq == false)
                    MessageBox.Show("Sửa Bệnh thất bại. Vui lòng kiểm tra lại dũ liệu", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sửa Bệnh thành công", "Result");
            }
            
        }
        private void quaylai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

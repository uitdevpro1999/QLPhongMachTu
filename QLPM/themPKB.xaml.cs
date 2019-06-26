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
    /// Interaction logic for themPKB.xaml
    /// </summary>
    public partial class themPKB : Window
    {

        BenhNhanBUS bnBus;
        BenhBUS beBus;
        public themPKB()
        {

            InitializeComponent();
            load_combobox_mabn();
            load_combobox_benh();
            ngay.Content = DateTime.Now.ToString();
        }
        public void load_combobox_mabn()
        {
            bnBus = new BenhNhanBUS();
            List<BenhNhanDTO> listBenhNhan = bnBus.select();
            this.loadData_Vao_comboboxbn(listBenhNhan);

        }
        private void loadData_Vao_comboboxbn(List<BenhNhanDTO> listBenhNhan)
        {

            if (listBenhNhan == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }
            foreach (BenhNhanDTO bn in listBenhNhan)
            {
                mabenhnhan.Items.Add(bn.MaBN.ToString());
            }

        }
        private void load_ten(List<BenhNhanDTO> listBenhNhan,string mabn)
        {

            if (listBenhNhan == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }
            foreach (BenhNhanDTO bn in listBenhNhan)
            {
                if(bn.MaBN.ToString()==mabn)
                {
                    hoten.Content = bn.TenBN;
                    mapkb.Text = bn.MaPKB;
                }
            }

        }
        public void load_combobox_benh()
        {
            beBus = new BenhBUS();
            List<BenhDTO> listBenh = beBus.select();
            this.loadData_Vao_comboboxbe(listBenh);

        }
        private void loadData_Vao_comboboxbe(List<BenhDTO> listBenh)
        {

            if (listBenh == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }           
            foreach (BenhDTO be in listBenh)
            {
                benh.Items.Add(be.TenBenh.ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bnBus = new BenhNhanBUS();
            List<BenhNhanDTO> listBenhNhan = bnBus.select();
            load_ten(listBenhNhan, mabenhnhan.Text);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PhieukhambenhDTO pkb = new PhieukhambenhDTO();
            ChandoanDTO cd = new ChandoanDTO();
            List<BenhDTO> listBenh = beBus.select();
            cd.MaPkb = mapkb.Text;
            foreach (BenhDTO be in listBenh)
            {
                if(benh.Text==be.TenBenh)
                {
                    cd.MaBenh = be.MaBenh;
                }
            }
            pkb.MaPkb = mapkb.Text;
            pkb.NgayKham = DateTime.UtcNow.Date;
            pkb.TrieuChung = trieuchung.Text;
            PhieukhambenhBUS pkbBus = new PhieukhambenhBUS();
            ChandoanBUS cdBus = new ChandoanBUS();
            bool kq1 = cdBus.them(cd);
            bool kq2 = pkbBus.sua(pkb);
            if (kq2==true && kq1==true)
            {
                MessageBox.Show("Lập phiếu thành công");
            }
            else MessageBox.Show("Lập phiếu thất bại");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Ketoa toa = new Ketoa();
            toa.mapkb.Text = mapkb.Text;
            toa.Show();
        }
    }
}

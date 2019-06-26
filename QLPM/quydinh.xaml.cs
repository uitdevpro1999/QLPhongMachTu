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
    /// Interaction logic for quydinh.xaml
    /// </summary>
    public partial class quydinh : Window
    {
        public quydinh()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            ThuocBUS thBus = new ThuocBUS();
            List<Cachdung> listcd = thBus.getcachdung();
            List<Donvi> listdv = thBus.getdonvi();
            this.load_combobox(listdv,listcd);
        }
        private void load_combobox(List<Donvi> listdv, List<Cachdung> listcd)
        {
            if (listdv == null || listcd ==null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB");
                return;
            }

            DataTable table = new DataTable();
            DataTable table1 = new DataTable();

            table.Columns.Add("donVi", typeof(string));
            table1.Columns.Add("cachDung", typeof(string));
            foreach (Donvi dv in listdv)
            {
                DataRow row = table.NewRow();
                row["donVi"] = dv.DonVi;
                table.Rows.Add(row);
            }
            foreach (Cachdung cd in listcd)
            {
                DataRow row = table1.NewRow();
                row["cachDung"] = cd.CachDung;
                table1.Rows.Add(row);
            }
            cbb_donvi.ItemsSource = table.DefaultView;
            cbb_donvi.DisplayMemberPath = "donVi";
            cbb_cachdung.ItemsSource = table1.DefaultView;
            cbb_cachdung.DisplayMemberPath = "cachDung";
        }
        private void tienkham_Click(object sender, RoutedEventArgs e)
        {
            thuoc_hidden();
            tk.Visibility = Visibility.Visible;
            tk1.Visibility = Visibility.Visible;
            thaydoitk.Visibility = Visibility.Visible;   
        }
        private void thuoc_hidden()
        {
            cachdung.Visibility = Visibility.Hidden;
            donvi.Visibility = Visibility.Hidden;
            thaydoidv.Visibility = Visibility.Hidden;
            thaydoicd.Visibility = Visibility.Hidden;
            panelcd.Visibility = Visibility.Hidden;
            paneldv.Visibility = Visibility.Hidden;
            cbb_cachdung.Visibility = Visibility.Hidden;
            cbb_donvi.Visibility = Visibility.Hidden;
            to2.Visibility = Visibility.Hidden;
            cd2.Visibility = Visibility.Hidden;
            suacd.Visibility = Visibility.Hidden;
            xoacd.Visibility = Visibility.Hidden;
            to1.Visibility = Visibility.Hidden;
            dv2.Visibility = Visibility.Hidden;
            suadv.Visibility = Visibility.Hidden;
            xoadv.Visibility = Visibility.Hidden;
        }
        private void tienkham_hidden()
        {
            tk.Visibility = Visibility.Hidden;
            tk1.Visibility = Visibility.Hidden;
            thaydoitk.Visibility = Visibility.Hidden;
        }
        private void thaydoitk_Click(object sender, RoutedEventArgs e)
        {
            
            PhieukhambenhBUS pkbBus = new PhieukhambenhBUS();
            pkbBus.tk();
            float tkmoi = float.Parse(tk.Text.ToString());
            float tkcu = PhieukhambenhDTO.TienKham;
            bool kq=pkbBus.thaydoiTK(tkmoi, tkcu);
            if (kq == false)
            {
                MessageBox.Show("thay đổi thất bại");
            }
            else MessageBox.Show("thay đổi thành công");
        }

        private void thuoc_Click(object sender, RoutedEventArgs e)
        {
            tienkham_hidden();
            cachdung.Visibility = Visibility.Visible;
            donvi.Visibility = Visibility.Visible;
            thaydoidv.Visibility = Visibility.Visible;
            thaydoicd.Visibility = Visibility.Visible;
            panelcd.Visibility = Visibility.Visible;
            paneldv.Visibility = Visibility.Visible;
            cbb_cachdung.Visibility = Visibility.Visible;
            cbb_donvi.Visibility = Visibility.Visible;
            if (sua.IsChecked == true)
            {
                to2.Visibility = Visibility.Visible;
                cd2.Visibility = Visibility.Visible;
                suacd.Visibility = Visibility.Visible;
            }
            else
            {
                xoacd.Visibility = Visibility.Visible;
            }
            if (sua1.IsChecked == true)
            {
                to1.Visibility = Visibility.Visible;
                dv2.Visibility = Visibility.Visible;
                suadv.Visibility = Visibility.Visible;
            }
            else
            {
                xoadv.Visibility = Visibility.Visible;
            }
        }

        private void thaydoidv_Click(object sender, RoutedEventArgs e)
        {
            ThuocBUS thBus = new ThuocBUS();
            bool kq=thBus.themdv(donvi.Text.ToString());
            if(kq==false)
            {
                MessageBox.Show("Thêm đơn vị thất bại");
            }else
            {
                MessageBox.Show("Thêm đơn vị thành công");
            }
            load();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            xoacd.Visibility = Visibility.Hidden;
            to2.Visibility = Visibility.Visible;
            cd2.Visibility = Visibility.Visible;
            suacd.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            to2.Visibility = Visibility.Hidden;
            cd2.Visibility = Visibility.Hidden;
            suacd.Visibility = Visibility.Hidden;
            xoacd.Visibility = Visibility.Visible;
        }

        private void sua1_Click(object sender, RoutedEventArgs e)
        {
            xoadv.Visibility = Visibility.Hidden;
            to1.Visibility = Visibility.Visible;
            dv2.Visibility = Visibility.Visible;
            suadv.Visibility = Visibility.Visible;
        }

        private void xoa1_Click(object sender, RoutedEventArgs e)
        {
            to1.Visibility = Visibility.Hidden;
            dv2.Visibility = Visibility.Hidden;
            suadv.Visibility = Visibility.Hidden;
            xoadv.Visibility = Visibility.Visible;
        }

        private void suadv_Click(object sender, RoutedEventArgs e)
        {
            ThuocBUS thBus = new ThuocBUS();
            bool kq=thBus.thaydoiDV(dv2.Text, cbb_donvi.Text);
            if (kq == false)
            {
                MessageBox.Show("Sửa đơn vị thất bại");
            }
            else
            {
                MessageBox.Show("Sửa đơn vị thành công");
            }
            load();
        }

        private void suacd_Click(object sender, RoutedEventArgs e)
        {
            ThuocBUS thBus = new ThuocBUS();
            bool kq = thBus.thaydoiCD(cd2.Text, cbb_cachdung.Text);
            if (kq == false)
            {
                MessageBox.Show("Sửa cách dùng thất bại");
            }
            else
            {
                MessageBox.Show("Sửa cách dùng thành công");
            }
            load();
        }

        private void xoadv_Click(object sender, RoutedEventArgs e)
        {
            ThuocBUS thBus = new ThuocBUS();
            bool kq = thBus.xoaDV(cbb_donvi.Text);
            if (kq == false)
            {
                MessageBox.Show("Xóa đơn vị thất bại");
            }
            else
            {
                MessageBox.Show("Xóa đơn vị thành công");
            }
            load();
        }

        private void xoacd_Click(object sender, RoutedEventArgs e)
        {
            ThuocBUS thBus = new ThuocBUS();
            bool kq = thBus.xoaCD(cbb_cachdung.Text);
            if (kq == false)
            {
                MessageBox.Show("Xóa cách dùng thất bại");
            }
            else
            {
                MessageBox.Show("Xóa cách dùng thành công");
            }
            load();
        }

        private void thaydoicd_Click(object sender, RoutedEventArgs e)
        {
            ThuocBUS thBus = new ThuocBUS();
            bool kq = thBus.themcd(cachdung.Text.ToString());
            if (kq == false)
            {
                MessageBox.Show("Thêm cách dùng thất bại");
            }
            else
            {
                MessageBox.Show("Thêm cách dùng thành công");
            }
            load();
        }
    }
}

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
using System.Windows.Media.Animation;
using QLPMDTO;

namespace QLPM
{
    /// <summary>
    /// Interaction logic for QLPMMainWindow.xaml
    /// </summary>
    public partial class QLPMMainWindow : Window
    {
        

        public QLPMMainWindow()
        {
            InitializeComponent();
        }


        private void ShowHideMenu(string storyboardhide, Button myButton, Button myButton2, StackPanel pnl)
        {
            Storyboard sb = Resources[storyboardhide] as Storyboard;
            sb.Begin(pnl);

            if (storyboardhide.Contains("Show"))
            {
                myButton.Visibility = System.Windows.Visibility.Visible;
                myButton2.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (storyboardhide.Contains("Hide"))
            {
                myButton.Visibility = System.Windows.Visibility.Hidden;
                myButton2.Visibility = System.Windows.Visibility.Visible;
            }


        }





        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            spLeft.Visibility = Visibility.Hidden;
            sphethong.Visibility = Visibility.Visible;
        }

        private void sphethong_MouseLeave(object sender, MouseEventArgs e)
        {
            sphethong.Visibility = Visibility.Hidden;
            spLeft.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tracuuBN tc = new tracuuBN();
            tc.Show();
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            spLeft.Visibility = Visibility.Hidden;
            sptracuu.Visibility = Visibility.Visible;
        }

        private void sptracuu_MouseLeave(object sender, MouseEventArgs e)
        {
            sptracuu.Visibility = Visibility.Hidden;
            spLeft.Visibility = Visibility.Visible;
        }

        private void spdanhmuc_MouseLeave(object sender, MouseEventArgs e)
        {
            spdanhmuc.Visibility = Visibility.Hidden;
            spLeft.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            spLeft.Visibility = Visibility.Hidden;
            spdanhmuc.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            MainWindow them = new MainWindow();
            them.Show();
        }

        private void DockPanel_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            themPKB pkb = new themPKB();
            pkb.Show();
        }

        private void DockPanel_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
        }

        private void spdanhsach_MouseLeave(object sender, MouseEventArgs e)
        {
            spdanhsach.Visibility = Visibility.Hidden;
            spLeft.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            Danhsachkhambenh dskb = new Danhsachkhambenh();
            dskb.Show();
        }

        private void Label_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            spLeft.Visibility = Visibility.Hidden;
            spdanhsach.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseLeftButtonUp_6(object sender, MouseButtonEventArgs e)
        {
            danhsachthuoc dsth = new danhsachthuoc();
            dsth.Show();
        }

        private void DockPanel_MouseLeftButtonUp_7(object sender, MouseButtonEventArgs e)
        {
            danhsachbenh dsbe = new danhsachbenh();
            dsbe.Show();
        }

        private void spbaocao_MouseLeave(object sender, MouseEventArgs e)
        {
            spbaocao.Visibility = Visibility.Hidden;
            spLeft.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseLeftButtonUp_8(object sender, MouseButtonEventArgs e)
        {
            baocaodoanhthu bcdt = new baocaodoanhthu();
            bcdt.Show();
        }

        private void DockPanel_MouseLeftButtonUp_9(object sender, MouseButtonEventArgs e)
        {
            baocaosdthuoc bcsdt = new baocaosdthuoc();
            bcsdt.Show();
        }

        private void Label_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            spLeft.Visibility = Visibility.Hidden;
            spbaocao.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            quydinh qd = new quydinh();
            qd.Show();
        }

        private void DockPanel_MouseLeftButtonUp_10(object sender, MouseButtonEventArgs e)
        {
            danhsachbenhnhan dsbn = new danhsachbenhnhan();
            dsbn.Show();
        }

        private void Label_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}

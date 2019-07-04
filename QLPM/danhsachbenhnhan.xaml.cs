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
    /// Interaction logic for danhsachbenhnhan.xaml
    /// </summary>
    public partial class danhsachbenhnhan : Window
    {
        BenhNhanBUS bnBus;
        PhieukhambenhBUS pkbBus;
        BenhBUS beBus;
        ChandoanBUS cdBus;
        public int stt;
        public danhsachbenhnhan()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            stt = 1;
            bnBus = new BenhNhanBUS();
            beBus = new BenhBUS();
            pkbBus = new PhieukhambenhBUS();
            cdBus = new ChandoanBUS();
            List<BenhNhanDTO> listBenhNhan = bnBus.select();
            List<BenhDTO> listBenh = beBus.select();
            List<PhieukhambenhDTO> listpkb = pkbBus.select();
            List<ChandoanDTO> listcd = cdBus.select();
            this.loadData_Vao_GridView(listBenhNhan, listBenh,listpkb,listcd);

        }
        private void loadData_Vao_GridView(List<BenhNhanDTO> listBenhNhan, List<BenhDTO> listBenh, List<PhieukhambenhDTO> listpkb,List<ChandoanDTO> listcd)
        {

            if (listBenhNhan == null || listpkb==null || listBenh==null || listcd == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin từ DB", "Result", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("sTT", typeof(int));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("NgayKham", typeof(string));
            table.Columns.Add("TrieuChung", typeof(string));
            table.Columns.Add("tenBenh", typeof(string));
            foreach (BenhNhanDTO bn in listBenhNhan)
            {
                foreach (PhieukhambenhDTO pkb in listpkb)
                {
                    if (bn.MaPKB == pkb.MaPkb)
                    {
                        foreach (ChandoanDTO cd in listcd)
                        {
                            if (pkb.MaPkb == cd.MaPkb)
                            {
                                foreach (BenhDTO be in listBenh)
                                {
                                    if (cd.MaBenh == be.MaBenh)
                                    {
                                        DataRow row = table.NewRow();
                                        row["sTT"] = stt;
                                        row["tenBN"] = bn.TenBN;
                                        row["NgayKham"] = pkb.NgayKham;
                                        row["TrieuChung"] = pkb.TrieuChung;
                                        row["tenBenh"] = be.TenBenh;
                                        table.Rows.Add(row);
                                        stt += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            grid.ItemsSource = table.DefaultView;
        }
    }
}

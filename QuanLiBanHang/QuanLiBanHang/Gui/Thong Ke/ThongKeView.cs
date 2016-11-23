using QuanLiBanHang.Data;
using System;
using System.Data;

namespace QuanLiBanHang.Gui.Thong_Ke
{
    public partial class ThongKeView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private KetNoiCSDL con = new KetNoiCSDL();

        private string start;
        private string end;
        private string dateState = "tuan";
        private string cmdTime;

        private string maSP = "SP00000001";
        public ThongKeView()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            DataTable thongKeHH = con.GetDataTable("select * from SanPham as a join NhaCungCap as b on a.NhaCC=b.TenNCC");
            gcSanPham.DataSource = thongKeHH;
        }
        private void initChar(string name)
        {
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            chartTitle1.Text = name;
            this.ccThongKe.Titles.Clear();
            this.ccThongKe.Titles.Add(chartTitle1);
            this.ccThongKe.SeriesDataMember.Remove(0);
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxDate.SelectedIndex == 0)
            {
                dateState = "tuan";
                btnNow.Text = "Tuần Này";
                btnYester.Text = "Tuần Trước";

                btnNow_Click(sender, e);
            }
            if (comboxDate.SelectedIndex == 1)
            {
                dateState = "thang";
                btnNow.Text = "Tháng Này";
                btnYester.Text = "Tháng Trước";

                btnNow_Click(sender, e);
            }
            if (comboxDate.SelectedIndex == 2)
            {
                dateState = "quy";
                btnNow.Text = "Quý Này";
                btnYester.Text = "Quý Trước";

                btnNow_Click(sender, e);
            }
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now.Date;


            if (dateState == "tuan")
            {
                while (tempTime.DayOfWeek != DayOfWeek.Monday) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(6));

            }
            if (dateState == "thang")
            {
                while (tempTime.Day > 1) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(DateTime.DaysInMonth(tempTime.Year, tempTime.Month) - 1));

            }

            if (dateState == "quy")
            {
                if (tempTime.Month < 4)
                {
                    start = tempTime.Year + "/1/1";
                    end = tempTime.Year + "/3/31";
                }
                if (tempTime.Month >= 4 && tempTime.Month < 7)
                {
                    start = tempTime.Year + "/4/1";
                    end = tempTime.Year + "/6/30";
                }
                if (tempTime.Month >= 7 && tempTime.Month < 10)
                {
                    start = tempTime.Year + "/7/1";
                    end = tempTime.Year + "/9/30";
                }
                if (tempTime.Month >= 10 && tempTime.Month < 13)
                {
                    start = tempTime.Year + "/10/1";
                    end = tempTime.Year + "/12/31";
                }
            }
            cmdTime = @"select a.TenSP, b.SoLuong, c.NgayBan from SanPham as a join CHITIETHOADONBAN as b
                on a.MaSP=b.MaSP join HOADONBAN as c on c.MaHDB=b.MaHD where c.NgayBan>= '" + start + "' and c.NgayBan<= '" + end + "' " +
                " and a.MaSP=N'" + maSP + "'";
            
            ccThongKe.DataSource = con.GetDataTable(cmdTime);
        }

        private void btnYester_Click(object sender, EventArgs e)
        {
            //thu 2 tuan truoc
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now.Date;
            tempTime = tempTime.AddDays(-7);

            if (dateState == "tuan")
            {
                while (tempTime.DayOfWeek != DayOfWeek.Monday) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(6));

            }
            if (dateState == "thang")
            {
                tempTime = tempTime.AddMonths(-1);
                while (tempTime.Day > 1) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(DateTime.DaysInMonth(tempTime.Year, tempTime.Month) - 1));

            }

            if (dateState == "quy")
            {
                tempTime = tempTime.AddMonths(-3);
                if (tempTime.Month < 4)
                {
                    start = tempTime.Year + "/1/1";
                    end = tempTime.Year + "/3/31";
                }
                if (tempTime.Month >= 4 && tempTime.Month < 7)
                {
                    start = tempTime.Year + "/4/1";
                    end = tempTime.Year + "/6/30";
                }
                if (tempTime.Month >= 7 && tempTime.Month < 10)
                {
                    start = tempTime.Year + "/7/1";
                    end = tempTime.Year + "/9/30";
                }
                if (tempTime.Month >= 10 && tempTime.Month < 13)
                {
                    start = tempTime.Year + "/10/1";
                    end = tempTime.Year + "/12/31";
                }
            }
            cmdTime = @"select a.TenSP, b.SoLuong, c.NgayBan from SanPham as a join CHITIETHOADONBAN as b
                on a.MaSP=b.MaSP join HOADONBAN as c on c.MaHDB=b.MaHD where c.NgayBan>= '" + start + "' and c.NgayBan<= '" + end + "' " +
                " and a.MaSP=N'" + maSP + "'";
            
            ccThongKe.DataSource = con.GetDataTable(cmdTime);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = Convert.ToDateTime(end);

            if (dateState == "tuan")
            {
                temp = temp.AddDays(7);
            }
            if (dateState == "thang")
            {
                temp = temp.AddMonths(1);

            }

            if (dateState == "quy")
            {
                temp = temp.AddMonths(3);
            }

            end = string.Format("{0:yyyy/MM/dd}", temp);
            cmdTime = @"select a.TenSP, b.SoLuong, c.NgayBan from SanPham as a join CHITIETHOADONBAN as b
                on a.MaSP=b.MaSP join HOADONBAN as c on c.MaHDB=b.MaHD where c.NgayBan>= '" + start + "' and c.NgayBan<= '" + end + "' " +
                " and a.MaSP=N'" + maSP + "'";
            ccThongKe.DataSource = con.GetDataTable(cmdTime);
            //MessageBox.Show(start+end);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            DateTime temp = Convert.ToDateTime(start);

            if (dateState == "tuan")
            {
                temp = temp.AddDays(-7);
            }
            if (dateState == "thang")
            {
                temp = temp.AddMonths(-1);

            }

            if (dateState == "quy")
            {
                temp = temp.AddMonths(-3);
            }

            start = string.Format("{0:yyyy/MM/dd}", temp);
            cmdTime = @"select a.TenSP, b.SoLuong, c.NgayBan from SanPham as a join CHITIETHOADONBAN as b
                on a.MaSP=b.MaSP join HOADONBAN as c on c.MaHDB=b.MaHD where c.NgayBan>= '" + start + "' and c.NgayBan<= '" + end + "' " +
                " and a.MaSP=N'" + maSP + "'";
            ccThongKe.DataSource = con.GetDataTable(cmdTime);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                maSP = gridView1.GetRowCellDisplayText(e.RowHandle, "MaSP").ToString();
                initChar(con.GetValue("select TenSP from SanPham where MaSP='" + maSP + "'"));
                btnNow_Click(sender, e);
            }
        }
    }
}
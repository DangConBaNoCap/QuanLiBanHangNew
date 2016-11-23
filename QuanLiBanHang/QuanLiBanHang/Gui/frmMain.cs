using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiBanHang.Data;

namespace QuanLiBanHang.Gui
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void menuNhanvien_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.ShowDialog();

        }

        private void QuanLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanHang bh = new frmBanHang();
            bh.ShowDialog();
        }

        private void toolDoiMK_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau MkNew = new FrmDoiMatKhau();
            MkNew.ShowDialog();
        }

        private void toolDangxuat_Click(object sender, EventArgs e)
        {
            frmDangNhap dn = new frmDangNhap();
            this.Dispose();
            dn.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            HoaDonBanBus bus=new HoaDonBanBus();
            string ngay = DateTime.Now.ToShortDateString();
            dgvDS.DataSource = bus.DanhSachSPMoi("");
        }

        private void toolNhapHang_Click(object sender, EventArgs e)
        {
            FrmNhapHang nh = new FrmNhapHang();
            nh.ShowDialog();
        }

        private void toolKH_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLiBanHang.Gui.Thong_Ke.ThongKeView temp = new Thong_Ke.ThongKeView();
            temp.ShowDialog();
        }
    }
}

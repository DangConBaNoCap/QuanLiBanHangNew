using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLiBanHang.Data;
using QuanLiBanHang.Entity;
namespace QuanLiBanHang.Gui
{
    public partial class FrmNhapHang : Form
    {
        public FrmNhapHang()
        {
            InitializeComponent();
        }
        LoaiHangBus lh = new LoaiHangBus();
        NhaCCBus ncc = new NhaCCBus();
        public void LoadDuLieu()
        {
            cboLoaiHang.DataSource=lh.HienThiSanPham("");
            cboLoaiHang.DisplayMember = "TenLH";
            cboLoaiHang.ValueMember = "MaLH";
            cboNhaCC.DataSource = ncc.HienThiKhachHang("");
            cboNhaCC.DisplayMember = "TenNCC";
            cboNhaCC.ValueMember = "TenNCC";

        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SanPhamBus bussp = new SanPhamBus();
            SanPhamEntity sp = new SanPhamEntity();
            KetNoiCSDL con = new KetNoiCSDL();
            try
            {
                sp.MaSP = con.SinhMa("SANPHAM", "SP");
                sp.TenSP = txtTenSP.Text;
                sp.SoLuong = int.Parse(txtSoLuong.Text);
                sp.GiaBan = int.Parse(txtGiaBan.Text);
                sp.GiaNhap = int.Parse(txtGiaNhap.Text);
                sp.MaLH = cboLoaiHang.SelectedValue.ToString();
                sp.NhaCC = cboNhaCC.SelectedValue.ToString();
                sp.NSX = dtNgaySX.Value.ToString();
                sp.MoTa = rtbMoTa.Text;
                sp.HinhAnh = null;
                bussp.ThemSanPham(sp);
                MessageBox.Show("Nhập hàng thành công", "Thông báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
using QuanLiBanHang.Entity;

namespace QuanLiBanHang.Gui
{
    public partial class FrmDoiMatKhau : Form
    {
       
        public FrmDoiMatKhau()
        {
            InitializeComponent();
            txtTenTK.Text = frmDangNhap.TenDangNhap;
        }
        DangNhap dn = new DangNhap();
        NhanVienEntity nv = new NhanVienEntity();
        public void ReLoad()
        {
          
            txtMKcu.Text = "";
            txtMKmoi.Text = "";
            txtMKlai.Text = "";
        }
        private void btnDongy_Click(object sender, EventArgs e)
        {
            if (txtMKcu.Text == "" || txtMKmoi.Text == "" || txtMKlai.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập đủ thông tin");
                ReLoad();
                return;
            }
            if (txtMKcu.Text != frmDangNhap.MatKhau)
            {
                // MessageBox.Show("Mật khẩu cũ không đúng");
               MessageBox.Show("Mật khẩu cũ không đúng");
                ReLoad();
                return;
            }
            if (txtMKmoi.Text != txtMKlai.Text)
            {
                // MessageBox.Show("Nhập lại mật khẩu không khớp");
                MessageBox.Show("Nhập lại mật khẩu không khớp");
                ReLoad();
                return;
            }
           // SqlConnection con = DataProvider.KetNoi();
            nv.MaNV = dn.LayMa(frmDangNhap.TenDangNhap, frmDangNhap.MatKhau);
            nv.MatKhau = txtMKmoi.Text.ToString();
            nv.TenDangNhap = txtTenTK.Text.ToString();
            dn.Sua(nv);
            MessageBox.Show("Đổi mật khẩu thành công ! Khởi động lại chương trình");
            this.Close();
            Application.Restart();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHangBus khbus = new KhachHangBus();
        KhachHangEntity khenti = new KhachHangEntity();
        KetNoiCSDL con = new KetNoiCSDL();
        void khoadk()
        {
            txtMakh.Enabled = false;
            txtTenkh.Enabled = false;
            cboGT.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
            txtLoaikh.Enabled = false;
            txtGhichu.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void modk()
        {
            txtMakh.Enabled = false;
            txtTenkh.Enabled = true;
            cboGT.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            txtLoaikh.Enabled = true;
            txtGhichu.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        void gannull()
        {
            txtMakh.Text = "";
            txtTenkh.Text = "";
            cboGT.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            txtGhichu.Text = "";
            txtLoaikh.Text = "";
        }

        bool them;
        private void frmKhach_Load(object sender, EventArgs e)
        {
            dgvKhachhang.DataSource = khbus.HienThiKhachHang("");
            khoadk();
        }
       

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            modk();
            gannull();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            them = false;
            modk();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            khenti.TenKH = txtTenkh.Text;
            khenti.GT= cboGT.Text;
            khenti.DiaChi = txtDiachi.Text;
            khenti.SDT = txtSDT.Text;
            khenti.LoaiKH = txtLoaikh.Text;
            khenti.GhiChu = txtGhichu.Text;
           
            if (them == true)
            {
             
                    try
                    {
                        khenti.MaKH= con.SinhMa("KHACHHANG", "KH");
                        khbus.ThemKhachHang(khenti);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
            else
            {
                try
                {
                    khenti.MaKH = txtMakh.Text.ToString();
                    khbus.SuaKhachHang(khenti);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            khoadk();
            dgvKhachhang.DataSource = khbus.HienThiKhachHang("");
            gannull();
        }

        private void dgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMakh.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtTenkh.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            cboGT.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            txtDiachi.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            txtSDT.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            txtLoaikh.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            txtGhichu.Text = dgvKhachhang.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                khenti.MaKH = txtMakh.Text.ToString();
                khbus.XoaKhachHang(khenti);
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex.Message);
            }
            gannull();
            khoadk();
            dgvKhachhang.DataSource = khbus.HienThiKhachHang("");
        }

    }
}

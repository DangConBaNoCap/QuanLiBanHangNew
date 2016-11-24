using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLiBanHang.Entity;

namespace QuanLiBanHang.Data
{
    class DangNhap
    {
       
        KetNoiCSDL con = new KetNoiCSDL();
        
        public bool Login(string _name,string _pass)
        {
           string sql= @"select * from NHANVIEN WHERE TenDangNhap = '" + _name + "' AND MatKhau = '" + _pass + "'";
           DataTable dn = con.GetDataTable(sql);
           if (dn.Rows.Count > 0) return true;
           else return false;
        }
        public void Sua(NhanVienEntity nv)
        {
             KetNoiCSDL.MoKetNoi();
            string sql = "UPDATE NHANVIEN SET MatKhau =@MatKhau,TenDangNhap =@TenDn Where MaNV=@MaNV";
           
            SqlCommand cmd = new SqlCommand(sql, KetNoiCSDL.connect);
         
            cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
            cmd.Parameters.AddWithValue("@TenDn", nv.TenDangNhap);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.ExecuteNonQuery();

            KetNoiCSDL.DongKetNoi();
        }
        public string LayMa(string tk,string mk)
        {
            return con.GetValue("select MaNV from NHANVIEN WHERE TenDangNhap = N'" + tk + "' AND MatKhau = N'" + mk + "'");
        }
    }
}

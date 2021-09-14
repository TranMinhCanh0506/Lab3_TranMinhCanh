using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 

namespace LAB3_TRANMINHCANH_1914899
{
    public partial class frmTuyChon : Form
    {
         QuanLySinhVien qlsv;
         ListView lv;
        
        public frmTuyChon()
        {
            InitializeComponent();

        }

        public frmTuyChon(QuanLySinhVien qlsv,ListView lv , bool loai)
        {
            InitializeComponent();

            this.qlsv = qlsv;
            this.lv = lv;

            if (loai)
                btnSapXep.Enabled = false;
            else
            {
                lbTim.Enabled = false;
                txtSearch.Enabled = false;
                btnSearch.Enabled = false;
            }
        }
       
        public enum Kieu
        {
            TheoTen,
            TheoMa,
            TheoNgaySinh
        }

        private void rdbMaSV_CheckedChanged(object sender, EventArgs e)
        {
            lbTim.Text = "nhập Mã SV :";
            txtSearch.Text = "";
        }

        private void rdbHoTen_CheckedChanged(object sender, EventArgs e)
        {
            lbTim.Text = "nhập Họ tên :";
            txtSearch.Text = "";
        }

        private void rdbNgaySinh_CheckedChanged(object sender, EventArgs e)
        {
            lbTim.Text = "nhập ngày sinh :";
            txtSearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SinhVien sv = null;
            Kieu kieu=Kieu.TheoMa;
            if(rdbMaSV.Checked)
            { kieu = Kieu.TheoMa; }
            if(rdbHoTen.Checked)
            { kieu = Kieu.TheoTen; }
            if(rdbNgaySinh.Checked)
            { kieu = Kieu.TheoNgaySinh; }
            switch(kieu)
            {
                case Kieu.TheoMa:
                    sv = qlsv.DanhSach.Find(x => x.MaSo == txtSearch.Text);
                    break;
                case Kieu.TheoTen:
                    sv = qlsv.DanhSach.Find(x => x.HoTen == txtSearch.Text);
                    break;
                case Kieu.TheoNgaySinh:
                    sv = qlsv.DanhSach.Find(x => x.NgaySinh.Day == int.Parse(txtSearch.Text));
                    break;
                default:
                    break;
            }
            if (sv is null)
                MessageBox.Show("Không có sinh viên này ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
                item.SubItems.Add(sv.Hinh);

                lv.Items.Clear();
                lv.Items.Add(item);
                MessageBox.Show("Số sinh viên tìm thấy : 1", "Thông báo", MessageBoxButtons.OK);
            }
            
        }       

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            Kieu kieu = Kieu.TheoMa;
            if (rdbMaSV.Checked)
            { kieu = Kieu.TheoMa; }
            if (rdbHoTen.Checked)
            { kieu = Kieu.TheoTen; }
            if (rdbNgaySinh.Checked)
            { kieu = Kieu.TheoNgaySinh; }
            switch (kieu)
            {
                case Kieu.TheoMa:
                    qlsv.DanhSach.Sort((x, y) => x.MaSo.CompareTo(y.MaSo));
                    break;
                case Kieu.TheoTen:
                    qlsv.DanhSach.Sort((x, y) => x.HoTen.CompareTo(y.HoTen));
                    break;
                case Kieu.TheoNgaySinh:
                    qlsv.DanhSach.Sort((x, y) => x.NgaySinh.CompareTo(y.NgaySinh));
                    break;
                default:
                    break;
            }
            lv.Items.Clear();
            foreach (var sv in qlsv.DanhSach)
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
                item.SubItems.Add(sv.Hinh);

                lv.Items.Add(item);
            }
            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
    }
}

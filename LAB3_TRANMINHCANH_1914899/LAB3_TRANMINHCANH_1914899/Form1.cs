using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LAB3_TRANMINHCANH_1914899
{

     
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien qlsv;
        public frmSinhVien()
        {
            InitializeComponent();
        }
        //Lấy thông tin từ controls thông tin SV
     private SinhVien GetSinhVien()
     {
        SinhVien sv = new SinhVien();
        bool gt = true;
        List<string> cn = new List<string>();
        sv.MaSo = this.mtxtMaSo.Text;
        sv.HoTen = this.txtHoTen.Text;
        sv.NgaySinh = this.dtpNgaySinh.Value;
        sv.DiaChi = this.txtDiaChi.Text;
        sv.Lop = this.cbbLop.Text;
        sv.Hinh = this.txtHinh.Text;
        if (rbNu.Checked)
        gt = false;
        sv.GioiTinh = gt;
        for (int i = 0; i< this.clbChuyenNganh.Items.Count; i++)
        if (clbChuyenNganh.GetItemChecked(i))
        cn.Add(clbChuyenNganh.Items[i].ToString());
        sv.ChuyenNganh = cn;
     return sv;
     }
     //Lấy thông tin sinh viên từ dòng item của ListView
     private SinhVien GetSinhVienLV(ListViewItem lvitem)
     {
     SinhVien sv = new SinhVien();
                 sv.MaSo = lvitem.SubItems[0].Text;
                 sv.HoTen = lvitem.SubItems[1].Text;
                 sv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
                 sv.DiaChi = lvitem.SubItems[3].Text;
                 sv.Lop = lvitem.SubItems[4].Text;
                 sv.GioiTinh = false;
                 if (lvitem.SubItems[5].Text == "Nam")
                 sv.GioiTinh = true;
                 List<string> cn = new List<string>();
                 string[] s = lvitem.SubItems[6].Text.Split(',');
                 foreach (string t in s)
                     cn.Add(t);
                 sv.ChuyenNganh = cn;
                 sv.Hinh = lvitem.SubItems[7].Text;
                 return sv;
      }
        //Thiết lập các thông tin lên controls sinh viên



        private void ThietLapThongTin(SinhVien sv)
     {
         this.mtxtMaSo.Text = sv.MaSo;
         this.txtHoTen.Text = sv.HoTen;
         this.dtpNgaySinh.Value = sv.NgaySinh;
         this.txtDiaChi.Text = sv.DiaChi;
         this.cbbLop.Text = sv.Lop;
         this.txtHinh.Text = sv.Hinh;
         this.pbHinh.ImageLocation = sv.Hinh;
         if (sv.GioiTinh)
             this.rbNam.Checked = true;
        else
            this.rbNu.Checked = true;
    
        for (int i = 0; i< this.clbChuyenNganh.Items.Count; i++)
            this.clbChuyenNganh.SetItemChecked(i, false);
    
        foreach (string s in sv.ChuyenNganh)
        {
            for (int i = 0; i< this.clbChuyenNganh.Items.Count; i++)
                if (s.CompareTo(this.clbChuyenNganh.Items[i]) == 0)
                        this.clbChuyenNganh.SetItemChecked(i, true);
        }
     }
        //Thêm sinh viên vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
             lvitem.SubItems.Add(sv.HoTen);
             lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
             lvitem.SubItems.Add(sv.DiaChi);
             lvitem.SubItems.Add(sv.Lop);
             string gt = "Nữ";
            if (sv.GioiTinh)
                 gt = "Nam";
             lvitem.SubItems.Add(gt);
             string cn = "";
             foreach (string s in sv.ChuyenNganh)
                 cn += s + ",";
             cn = cn.Substring(0, cn.Length - 1);
             lvitem.SubItems.Add(cn);
             lvitem.SubItems.Add(sv.Hinh);
             this.lvSinhVien.Items.Add(lvitem);
        }
        //Hiển thị các sinh viên trong qlsv lên ListView
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.DanhSach)
            {
                ThemSV(sv);
            }
        }//sự kiện Load form
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView();
        }
        //Chức năng thêm sinh viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MaSo, delegate (object obj1, object obj2) {
                return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữliệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.qlsv.Them(sv);
                this.LoadListView();
            }
        }
        //Khi chọn dòng sinh viên bên ListView
        //thực hiện gán thông tin lên các control
        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
             if (count > 0)
                 {
                 ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                 SinhVien sv = GetSinhVienLV(lvitem);
                 ThietLapThongTin(sv);
                 }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Để các control ở giá trị mặc định
        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cbbLop.Text = this.cbbLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rbNam.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count - 1; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
        }
        //Sửa thông tin sinh viên được chọn
        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kquaSua;
            kquaSua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kquaSua)
            {
                this.LoadListView();
            }
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Open File Image";
            file.Filter = "Image Files (BMP, JPEG, PNG)|"
                + "*.bmp;*.jpg;*.jpeg;*.png|"
                + "BMP files (*.bmp)|*.bmp|"
                + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                + "PNG files (*.png)|*.png|"
                + "All files (*.*)|*.*";
            file.InitialDirectory = Environment.CurrentDirectory;
            if (file.ShowDialog() == DialogResult.OK)
            {
                var fileName = file.FileName;
                txtHinh.Text = fileName;
                pbHinh.Load(fileName);
            }
        }

        private void lvSinhVien_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var count = lvSinhVien.CheckedItems.Count;
            tsslCheck.Text = $" Tổng Sinh viên : {count}";
        }

        private void mởFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBrowse.PerformClick();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThoat.PerformClick();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThem.PerformClick();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa.PerformClick();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua.PerformClick();
        }
       

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult D = fontDialog1.ShowDialog();
            if(D==DialogResult.OK)
            {
                lvSinhVien.Font = fontDialog1.Font;
            }
        }

        private void màuChữToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if(D==DialogResult.OK)
            {
                lvSinhVien.ForeColor = colorDialog1.Color;
            }
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon f = new frmTuyChon(qlsv, lvSinhVien, true);
            f.ShowDialog();
            LoadListView();

        }

        private void sắpXếpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon f = new frmTuyChon(qlsv, lvSinhVien, false);
            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for ( i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
        }
    }
}

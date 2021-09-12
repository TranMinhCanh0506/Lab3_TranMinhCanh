
namespace LAB3_TRANMINHCANH_1914899
{
    partial class frmTuyChon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbTim = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.rdbMaSV = new System.Windows.Forms.RadioButton();
            this.rdbHoTen = new System.Windows.Forms.RadioButton();
            this.rdbNgaySinh = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(433, 82);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbTim
            // 
            this.lbTim.AutoSize = true;
            this.lbTim.Location = new System.Drawing.Point(50, 98);
            this.lbTim.Name = "lbTim";
            this.lbTim.Size = new System.Drawing.Size(122, 20);
            this.lbTim.TabIndex = 4;
            this.lbTim.Text = "Nhập Thông Tin :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(196, 91);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 27);
            this.txtSearch.TabIndex = 5;
            // 
            // btnSapXep
            // 
            this.btnSapXep.Location = new System.Drawing.Point(78, 151);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(94, 38);
            this.btnSapXep.TabIndex = 6;
            this.btnSapXep.Text = "Sắp xếp";
            this.btnSapXep.UseVisualStyleBackColor = true;
            this.btnSapXep.Click += new System.EventHandler(this.btnSapXep_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(319, 151);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 38);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // rdbMaSV
            // 
            this.rdbMaSV.AutoSize = true;
            this.rdbMaSV.Location = new System.Drawing.Point(50, 29);
            this.rdbMaSV.Name = "rdbMaSV";
            this.rdbMaSV.Size = new System.Drawing.Size(72, 24);
            this.rdbMaSV.TabIndex = 8;
            this.rdbMaSV.TabStop = true;
            this.rdbMaSV.Text = "Mã SV";
            this.rdbMaSV.UseVisualStyleBackColor = true;
            this.rdbMaSV.CheckedChanged += new System.EventHandler(this.rdbMaSV_CheckedChanged);
            // 
            // rdbHoTen
            // 
            this.rdbHoTen.AutoSize = true;
            this.rdbHoTen.Location = new System.Drawing.Point(196, 29);
            this.rdbHoTen.Name = "rdbHoTen";
            this.rdbHoTen.Size = new System.Drawing.Size(77, 24);
            this.rdbHoTen.TabIndex = 9;
            this.rdbHoTen.TabStop = true;
            this.rdbHoTen.Text = "Họ Tên";
            this.rdbHoTen.UseVisualStyleBackColor = true;
            this.rdbHoTen.CheckedChanged += new System.EventHandler(this.rdbHoTen_CheckedChanged);
            // 
            // rdbNgaySinh
            // 
            this.rdbNgaySinh.AutoSize = true;
            this.rdbNgaySinh.Location = new System.Drawing.Point(316, 29);
            this.rdbNgaySinh.Name = "rdbNgaySinh";
            this.rdbNgaySinh.Size = new System.Drawing.Size(97, 24);
            this.rdbNgaySinh.TabIndex = 10;
            this.rdbNgaySinh.TabStop = true;
            this.rdbNgaySinh.Text = "Ngày Sinh";
            this.rdbNgaySinh.UseVisualStyleBackColor = true;
            this.rdbNgaySinh.CheckedChanged += new System.EventHandler(this.rdbNgaySinh_CheckedChanged);
            // 
            // frmTuyChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 204);
            this.Controls.Add(this.rdbNgaySinh);
            this.Controls.Add(this.rdbHoTen);
            this.Controls.Add(this.rdbMaSV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSapXep);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbTim);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmTuyChon";
            this.Text = "Tùy Chọn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbTim;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton rdbMaSV;
        private System.Windows.Forms.RadioButton rdbHoTen;
        private System.Windows.Forms.RadioButton rdbNgaySinh;
    }
}
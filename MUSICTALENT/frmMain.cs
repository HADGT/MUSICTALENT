using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MUSICTALENT.Models;

namespace MUSICTALENT
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            CenterToScreen(); // Hiển thị form ở giữa màn hình khi form được khởi tạo
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }

        private void nhạcCụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhaccu NC = new Nhaccu();
            NC.Show();
            this.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSNhanVien NV = new DSNhanVien();
            NV.Show();
            this.Hide();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSKhachHang KH = new DSKhachHang();
            KH.Show();
            this.Hide();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSNCC NCC = new DSNCC();
            NCC.Show();
            this.Hide();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Dangnhap Login = new Dangnhap();
            Login.Show();
            this.Hide();
        }
    }
}

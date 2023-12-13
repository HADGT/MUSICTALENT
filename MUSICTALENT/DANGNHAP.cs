using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MUSICTALENT.Models;

namespace MUSICTALENT
{
    public partial class Dangnhap : Form
    {
        Conection kn = new Conection();
        public Dangnhap()
        {
            InitializeComponent();
            CenterToScreen(); // Hiển thị form ở giữa màn hình khi form được khởi tạo
            KeyPreview = true; // Cho phép form nhận sự kiện từ bàn phím
                               // Gắn sự kiện KeyDown cho form
            this.KeyDown += new KeyEventHandler(Dangnhap_KeyDown);
        }


        private void btndangnhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem TextBox tài khoản và mật khẩu có trống hay không
            if (string.IsNullOrWhiteSpace(txttaikhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.");
                return; // Dừng lại tại đây để không tiếp tục thực hiện các thao tác khác
            }
            if (string.IsNullOrWhiteSpace(txtmatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                return; // Dừng lại tại đây để không tiếp tục thực hiện các thao tác khác
            }
            string conStr = @"Data Source=DUONGHA\DUONGHA;Initial Catalog=MUSICTALENT;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string query = String.Format(
                "select count (*) from DANGNHAP where ACCOUNT = N'{0}' and PASSWORK = N'{1}'",
                txttaikhoan.Text,
                txtmatkhau.Text
                );
            SqlCommand cmd = new SqlCommand(query, conn);
            int SL = (int)cmd.ExecuteScalar();
            conn.Close();
            if (SL == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMain frmAdmin = new frmMain();
                frmAdmin.Show(); 
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void Dangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Xử lý sự kiện khi người dùng ấn Enter ở form
                e.Handled = true; // Ngăn không cho sự kiện KeyDown tiếp tục lan truyền

                // Thực hiện công việc mà bạn muốn khi người dùng ấn Enter ở form
                // Ví dụ:
                btndangnhap.PerformClick(); // Thực hiện sự kiện Click của nút đăng nhập
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

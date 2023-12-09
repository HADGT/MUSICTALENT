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
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
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
                //khởi tạo đối tượng của frmdangnhap
                frmMain frm = new frmMain();
                //Hiển thị đối tượng lên màn hình
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

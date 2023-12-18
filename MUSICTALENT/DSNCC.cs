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
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MUSICTALENT
{
    public partial class DSNCC : Form
    {
        Conection kn = new Conection();
        public DSNCC()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Mở rộng form để lấp đầy toàn bộ màn hình khi form được khởi tạo
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANCC.TextChanged += new EventHandler(txtMANCC_TextChanged);
            txtTENNCC.TextChanged += new EventHandler(txtTENNCC_TextChanged);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            txtGHICHU.TextChanged += new EventHandler(txtGHICHU_TextChanged);
        }

        private void DSNCC_Load(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANCC.TextChanged += new EventHandler(txtMANCC_TextChanged);
            txtTENNCC.TextChanged += new EventHandler(txtTENNCC_TextChanged);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            txtGHICHU.TextChanged += new EventHandler(txtGHICHU_TextChanged);
        }
        public void cleartext()
        {
            txtMANCC.Text = "";
            txtTENNCC.Text = "";
            txtDIACHI.Text = "";
            txtSDT.Text = "";
            txtGHICHU.Text = "";
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btntimkiem.Enabled = true;
            btnthoat.Enabled = true;
        }

        public void getlist()
        {
            string query = "SELECT MANCC, TENNCC, DCHI, SDT, GHICHU FROM NHACUNGCAP";
            DataSet ds = kn.Laydulieu(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                dataGridView1.Columns[0].HeaderText = "Mã NCC";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt tiêu đề của cột ở giữa
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].HeaderText = "Tên NCC";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt nội dung của cột "Họ tên" sang trái
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].HeaderText = "SĐT";
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].HeaderText = "Ghi chú";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.MouseWheel += DataGridView1_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
            }
        }

        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Cuộn lên khi lăn lên trên chuột
                dataGridView1.FirstDisplayedScrollingRowIndex = Math.Max(0, dataGridView1.FirstDisplayedScrollingRowIndex - 3);
            }
            else if (e.Delta < 0)
            {
                // Cuộn xuống khi lăn xuống dưới chuột
                dataGridView1.FirstDisplayedScrollingRowIndex = Math.Min(dataGridView1.Rows.Count - 1, dataGridView1.FirstDisplayedScrollingRowIndex + 3);
            }
        }

        private void CheckTextboxes()
        {
            if (string.IsNullOrWhiteSpace(txtMANCC.Text) && string.IsNullOrWhiteSpace(txtTENNCC.Text) && string.IsNullOrWhiteSpace(txtSDT.Text) && string.IsNullOrWhiteSpace(txtDIACHI.Text) && string.IsNullOrWhiteSpace(txtGHICHU.Text))
            {
                btnlammoi.Enabled = false;
            }
            else
            {
                btnlammoi.Enabled = true;
            }
        }

        private void txtMANCC_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtTENNCC_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtDIACHI_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtGHICHU_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMANCC.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHACUNGCAP WHERE MANCC like '{0}'", txtMANCC.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        MessageBox.Show("Mã đã tồn tại. Vui lòng nhập mã khác!");
                    }
                    else
                    {
                        // Kiểm tra cú pháp cho trường "Số lượng"
                        if (int.TryParse(txtSDT.Text, out int sdt))
                        {
                            string query = string.Format("INSERT INTO NHACUNGCAP VALUES ('{0}', N'{1}', N'{2}', {3}, N'{4}')",
                                txtMANCC.Text,
                                txtTENNCC.Text,
                                txtDIACHI.Text,
                                sdt,
                                txtGHICHU.Text);
                            kn.Thucthi(query);
                            getlist();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'Số điện thoại'");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn thêm!");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMANCC.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHACUNGCAP WHERE MANCC like '{0}'", txtMANCC.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (int.TryParse(txtSDT.Text, out int sdt))
                        {
                            string query = string.Format("UPDATE NHACUNGCAP SET TENNCC=N'{0}',DCHI=N'{1}', SDT='{2}', GHICHU=N'{3}' where MANCC='{4}'",
                            txtTENNCC.Text,
                            txtDIACHI.Text,
                            sdt,
                            txtGHICHU.Text,
                            txtMANCC.Text);
                            kn.Thucthi(query);
                            getlist();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'Số điện thoại'");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã không tồn tại. Vui lòng nhập mã khác!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn sửa!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtMANCC.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHACUNGCAP WHERE MANCC like '{0}'", txtMANCC.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = string.Format("DELETE FROM NHACUNGCAP WHERE MANCC like '{0}'", txtMANCC.Text);
                            bool kq = kn.Thucthi(query);
                            if (kq)
                            {
                                MessageBox.Show("Xóa thành công");
                                getlist();
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã không tồn tại. Vui lòng nhập mã khác!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn xóa!");
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANCC.TextChanged += new EventHandler(txtMANCC_TextChanged);
            txtTENNCC.TextChanged += new EventHandler(txtTENNCC_TextChanged);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            txtGHICHU.TextChanged += new EventHandler(txtGHICHU_TextChanged);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtMANCC.Text != "" || txtTENNCC.Text != "" || txtDIACHI.Text != "" || txtSDT.Text != "" || txtGHICHU.Text != "")
            {
                string query = string.Format("SELECT MANCC, TENNCC, DCHI, SDT, GHICHU FROM NHACUNGCAP WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(txtMANCC.Text))
                {
                    query += $"AND MANCC LIKE '{txtMANCC.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtTENNCC.Text))
                {
                    query += $"AND TENNCC LIKE N'%{txtTENNCC.Text}%' ";
                }
                if (!string.IsNullOrWhiteSpace(txtDIACHI.Text))
                {
                    query += $"AND DCHI LIKE N'%{txtDIACHI.Text}%' ";
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    query += $"AND SDT = '{txtSDT.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtGHICHU.Text))
                {
                    query += $"AND GHICHU = '%{txtGHICHU.Text}%' ";
                }
                DataSet ds = kn.Laydulieu(query);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                    dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                    // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                    dataGridView1.Columns[0].HeaderText = "Mã NCC";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt tiêu đề của cột ở giữa
                    dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[1].HeaderText = "Tên NCC";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt nội dung của cột "Họ tên" sang trái
                    dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                    dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "SĐT";
                    dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].HeaderText = "Ghi chú";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.MouseWheel += DataGridView1_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn tìm kiếm!");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dangnhap Login = new Dangnhap();
            Login.Show();
            this.Hide();
        }
    }
}

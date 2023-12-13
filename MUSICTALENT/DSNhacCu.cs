using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MUSICTALENT.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MUSICTALENT
{
    public partial class Nhaccu : Form
    {
        Conection kn = new Conection();
        public Nhaccu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Mở rộng form để lấp đầy toàn bộ màn hình khi form được khởi tạo
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANC.TextChanged += new EventHandler(txtMANC_TextChanged);
            txtTENNC.TextChanged += new EventHandler(txtTENNC_TextChanged);
            txtSOLUONG.TextChanged += new EventHandler(txtSOLUONG_TextChanged);
            txtGHICHU.TextChanged += new EventHandler(txtGHICHU_TextChanged);
            txtGIA.TextChanged += new EventHandler(txtGIA_TextChanged);
        }

        private void Nhaccu_Load(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANC.TextChanged += new EventHandler(txtMANC_TextChanged);
            txtTENNC.TextChanged += new EventHandler(txtTENNC_TextChanged);
            txtSOLUONG.TextChanged += new EventHandler(txtSOLUONG_TextChanged);
            txtGHICHU.TextChanged += new EventHandler(txtGHICHU_TextChanged);
            txtGIA.TextChanged += new EventHandler(txtGIA_TextChanged);
        }

        public void cleartext()
        {
            txtMANC.Text = "";
            txtTENNC.Text = "";
            txtSOLUONG.Text = "";
            cbbMADVT.Text = "";
            txtGHICHU.Text = "";
            txtGIA.Text = "";
            btnThem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnthoat.Enabled = true;
            btntimkiem.Enabled = true;
        }

        public void getlist()
        {
            string query = "select MANC, TENNC, SOLUONG, TENDVT, GHICHU, GIA from NHACCU, DONVITINH where NHACCU.MADVT = DONVITINH.MADVT";
            DataSet ds = kn.Laydulieu(query);
            string query1 = "select * from DONVITINH";
            DataSet ds1 = kn.Laydulieu(query1);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                dataGridView1.Columns[0].HeaderText = "Mã nhạc cụ";
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].HeaderText = "Tên nhạc cụ";
                // Đặt nội dung của cột "Họ tên" sang trái
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].HeaderText = "Số lượng";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Tên mã đơn vị tính";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ghi chú";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Giá";
                dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridView1.MouseWheel += DataGridView1_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    cbbMADVT.DataSource = ds1.Tables[0];
                    cbbMADVT.ValueMember = "MADVT";
                }
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
            if (string.IsNullOrWhiteSpace(txtMANC.Text) && string.IsNullOrWhiteSpace(txtTENNC.Text) && string.IsNullOrWhiteSpace(txtSOLUONG.Text) && string.IsNullOrWhiteSpace(txtGHICHU.Text) && string.IsNullOrWhiteSpace(txtGIA.Text))
            {
                btnlammoi.Enabled = false;
            }
            else
            {
                btnlammoi.Enabled = true;
            }
        }

        private void txtMANC_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtTENNC_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtSOLUONG_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtGHICHU_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtGIA_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r > 0)
            {
                btnThem.Enabled = true;
                btnlammoi.Enabled = false;
                btnxoa.Enabled = true;
                btnsua.Enabled = true;
                btnthoat.Enabled = true;
                btntimkiem.Enabled = true;
                txtMANC.Text = dataGridView1.Rows[r].Cells["MANC"].Value.ToString();
                txtTENNC.Text = dataGridView1.Rows[r].Cells["TENNC"].Value.ToString();
                txtSOLUONG.Text = dataGridView1.Rows[r].Cells["SOLUONG"].Value.ToString();
                txtGHICHU.Text = dataGridView1.Rows[r].Cells["GHICHU"].Value.ToString();
                txtGIA.Text = dataGridView1.Rows[r].Cells["GIA"].Value.ToString();
            }
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMANC.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHACCU WHERE MANC like '{0}'", txtMANC.Text);
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
                        if (int.TryParse(txtSOLUONG.Text, out int soLuong))
                        {
                            // Kiểm tra cú pháp cho trường "Giá"
                            if (int.TryParse(txtGIA.Text, out int gia))
                            {
                                // Nếu cả "Số lượng" và "Giá" đều là số, tiếp tục thực hiện lệnh INSERT
                                string query = string.Format("INSERT INTO NHACCU VALUES ('{0}', N'{1}', {2}, '{3}', N'{4}', {5})",
                                    txtMANC.Text,
                                    txtTENNC.Text,
                                    soLuong,
                                    cbbMADVT.SelectedValue,
                                    txtGHICHU.Text,
                                    gia);

                                kn.Thucthi(query);
                                getlist();
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập số vào trường 'Giá'");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'Số lượng'");
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
            if (txtMANC.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHACCU WHERE MANC like '{0}'", txtMANC.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        string query = string.Format("UPDATE NHACCU SET TENNC=N'{0}',SOLUONG='{1}', MADVT='{2}', GHICHU=N'{3}', GIA='{4}' where MANC='{5}'",
                            txtTENNC.Text,
                            txtSOLUONG.Text,
                            cbbMADVT.SelectedValue,
                            txtGHICHU.Text,
                            txtGIA.Text,
                            txtMANC.Text);
                        kn.Thucthi(query);
                        getlist();
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
            if (txtMANC.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHACCU WHERE MANC like '{0}'", txtMANC.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = string.Format("DELETE FROM NHACCU WHERE MANC='{0}'",
                            txtMANC.Text);
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
            txtMANC.TextChanged += new EventHandler(txtMANC_TextChanged);
            txtTENNC.TextChanged += new EventHandler(txtTENNC_TextChanged);
            txtSOLUONG.TextChanged += new EventHandler(txtSOLUONG_TextChanged);
            txtGHICHU.TextChanged += new EventHandler(txtGHICHU_TextChanged);
            txtGIA.TextChanged += new EventHandler(txtGIA_TextChanged);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtMANC.Text != "" || txtTENNC.Text != "" || txtSOLUONG.Text != "" || txtGHICHU.Text != "" || txtGIA.Text != "")
            {
                string query = string.Format("SELECT COUNT(*) FROM NHACCU, DONVITINH WHERE NHACCU.MADVT = DONVITINH.MADVT AND (MANC like '{0}' or TENNC LIKE N'{1}' or SOLUONG = '{2}' or GHICHU LIKE N'{3}' or GIA = '{4}')",
                    txtMANC.Text,
                    txtTENNC.Text,
                    txtSOLUONG.Text,
                    txtGHICHU.Text,
                    txtGIA.Text);

                int count = Convert.ToInt32(kn.Laydulieu(query).Tables[0].Rows[0][0]);

                if (count > 0)
                {
                    query = string.Format("SELECT MANC, TENNC, SOLUONG, TENDVT, GHICHU, GIA FROM NHACCU, DONVITINH WHERE NHACCU.MADVT = DONVITINH.MADVT AND (MANC like '{0}' or TENNC LIKE N'{1}' or SOLUONG = '{2}' or GHICHU LIKE N'{3}' or GIA = '{4}')",
                        txtMANC.Text,
                        txtTENNC.Text,
                        txtSOLUONG.Text,
                        txtGHICHU.Text,
                        txtGIA.Text);

                    DataSet ds = kn.Laydulieu(query);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                        // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                        dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                        // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                        dataGridView1.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                        dataGridView1.Columns[0].HeaderText = "Mã nhạc cụ";
                        dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].HeaderText = "Tên nhạc cụ";
                        // Đặt nội dung của cột "Họ tên" sang trái
                        dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].HeaderText = "Số lượng";
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[3].HeaderText = "Tên mã đơn vị tính";
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[4].HeaderText = "Ghi chú";
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[5].HeaderText = "Giá";
                        dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dataGridView1.MouseWheel += DataGridView1_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
                    }
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

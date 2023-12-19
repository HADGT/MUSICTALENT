using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MUSICTALENT.Models;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MUSICTALENT
{
    public partial class DSChucVuvaDVT : Form
    {
        Conection kn = new Conection();
        public DSChucVuvaDVT()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Mở rộng form để lấp đầy toàn bộ màn hình khi form được khởi tạo
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMACV.TextChanged += new EventHandler(txtMACV_TextChanged);
            txtTENCV.TextChanged += new EventHandler(txtTENCV_TextChanged);
            txtLUONG.TextChanged += new EventHandler(txtLUONG_TextChanged);
            txtMADVT.TextChanged += new EventHandler(txtMADVT_TextChanged);
            txtTENDVT.TextChanged += new EventHandler(txtTENDVT_TextChanged);
        }

        private void dataGridViewCV_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Cuộn lên khi lăn lên trên chuột
                dataGridViewCV.FirstDisplayedScrollingRowIndex = Math.Max(0, dataGridViewCV.FirstDisplayedScrollingRowIndex - 3);
            }
            else if (e.Delta < 0)
            {
                // Cuộn xuống khi lăn xuống dưới chuột
                dataGridViewCV.FirstDisplayedScrollingRowIndex = Math.Min(dataGridViewCV.Rows.Count - 1, dataGridViewCV.FirstDisplayedScrollingRowIndex + 3);
            }
        }

        private void dataGridViewDVT_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Cuộn lên khi lăn lên trên chuột
                dataGridViewDVT.FirstDisplayedScrollingRowIndex = Math.Max(0, dataGridViewDVT.FirstDisplayedScrollingRowIndex - 3);
            }
            else if (e.Delta < 0)
            {
                // Cuộn xuống khi lăn xuống dưới chuột
                dataGridViewDVT.FirstDisplayedScrollingRowIndex = Math.Min(dataGridViewDVT.Rows.Count - 1, dataGridViewDVT.FirstDisplayedScrollingRowIndex + 3);
            }
        }

        private void CheckTextboxes()
        {
            if (string.IsNullOrWhiteSpace(txtMACV.Text) && string.IsNullOrWhiteSpace(txtTENCV.Text) && string.IsNullOrWhiteSpace(txtLUONG.Text))
            {
                btnlammoiCV.Enabled = false;
            }
            else
            {
                btnlammoiCV.Enabled = true;
            }
            if (string.IsNullOrWhiteSpace(txtMADVT.Text) && string.IsNullOrWhiteSpace(txtTENDVT.Text))
            {
                btnlammoiDVT.Enabled = false;
            }
            else
            {
                btnlammoiDVT.Enabled = true;
            }
        }

        private void txtMACV_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtTENCV_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtLUONG_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtMADVT_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtTENDVT_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void DSChucVuvaDVT_Load(object sender, EventArgs e)
        {
            getlistCV();
            getlistDVT();
            cleartextCV();
            cleartextDVT();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMACV.TextChanged += new EventHandler(txtMACV_TextChanged);
            txtTENCV.TextChanged += new EventHandler(txtTENCV_TextChanged);
            txtLUONG.TextChanged += new EventHandler(txtLUONG_TextChanged);
            txtMADVT.TextChanged += new EventHandler(txtMADVT_TextChanged);
            txtTENDVT.TextChanged += new EventHandler(txtTENDVT_TextChanged);
        }

        public void cleartextCV()
        {
            txtMACV.Text = "";
            txtTENCV.Text = "";
            txtLUONG.Text = "";
            btnthemCV.Enabled = true;
            btnsuaCV.Enabled = true;
            btnxoaCV.Enabled = true;
            btntimkiemCV.Enabled = true;
            btnthoat.Enabled = true;
        }

        public void cleartextDVT()
        {
            txtMADVT.Text = "";
            txtTENDVT.Text = "";
            btnthemDVT.Enabled = true;
            btnsuaDVT.Enabled = true;
            btnxoaDVT.Enabled = true;
            btntimkiemDVT.Enabled = true;
            btnthoat.Enabled = true;
        }

        public void getlistCV()
        {
            string query = "SELECT * FROM CHUCVU";
            DataSet ds = kn.Laydulieu(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                // Đặt định dạng ngày tháng năm cho cột Ngày sinh (index 2) và Ngày đăng ký (index 5)
                dataGridViewCV.DataSource = ds.Tables[0];
                // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                dataGridViewCV.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                dataGridViewCV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridViewCV.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                dataGridViewCV.Columns[0].HeaderText = "Mã chức vụ";
                dataGridViewCV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt tiêu đề của cột ở giữa
                dataGridViewCV.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCV.Columns[1].HeaderText = "Tên chức vụ";
                dataGridViewCV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt nội dung của cột "Họ tên" sang trái
                dataGridViewCV.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCV.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCV.Columns[2].HeaderText = "Lương";
                dataGridViewCV.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewCV.MouseWheel += dataGridViewCV_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
            }
        }

        public void getlistDVT()
        {
            string query = "SELECT * FROM DONVITINH";
            DataSet ds = kn.Laydulieu(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                // Đặt định dạng ngày tháng năm cho cột Ngày sinh (index 2) và Ngày đăng ký (index 5)
                dataGridViewDVT.DataSource = ds.Tables[0];
                // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                dataGridViewDVT.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                dataGridViewDVT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridViewDVT.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                dataGridViewDVT.Columns[0].HeaderText = "Mã đơn vị tính";
                dataGridViewDVT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt tiêu đề của cột ở giữa
                dataGridViewDVT.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewDVT.Columns[1].HeaderText = "Tên đơn vị tính";
                dataGridViewDVT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt nội dung của cột "Họ tên" sang trái
                dataGridViewDVT.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewDVT.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewDVT.MouseWheel += dataGridViewDVT_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
            }
        }

        private void btnlammoiCV_Click(object sender, EventArgs e)
        {
            getlistCV();
            cleartextCV();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMACV.TextChanged += new EventHandler(txtMACV_TextChanged);
            txtTENCV.TextChanged += new EventHandler(txtTENCV_TextChanged);
            txtLUONG.TextChanged += new EventHandler(txtLUONG_TextChanged);
        }

        private void btnlammoiDVT_Click(object sender, EventArgs e)
        {
            getlistDVT();
            cleartextDVT();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMADVT.TextChanged += new EventHandler(txtMADVT_TextChanged);
            txtTENDVT.TextChanged += new EventHandler(txtTENDVT_TextChanged);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnthemCV_Click(object sender, EventArgs e)
        {
            if (txtMACV.Text != "")
            {
                // Kiểm tra xem ngày hiện tại là ngày bắt đầu của ngày tháng năm hay chỉ ngày trong dữ liệu
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM CHUCVU WHERE MACV like '{0}'", txtMACV.Text);
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
                        if (int.TryParse(txtLUONG.Text, out int luong))
                        {
                            string query = string.Format("INSERT INTO CHUCVU VALUES ('{0}', N'{1}', {2})",
                            txtMACV.Text,
                            txtTENCV.Text,
                            luong
                            );
                            kn.Thucthi(query);
                            getlistCV();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'Lương'");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn thêm!");
            }
        }

        private void btnthemDVT_Click(object sender, EventArgs e)
        {
            if (txtMADVT.Text != "")
            {
                // Kiểm tra xem ngày hiện tại là ngày bắt đầu của ngày tháng năm hay chỉ ngày trong dữ liệu
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM DONVITINH WHERE MADVT like '{0}'", txtMADVT.Text);
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
                        string query = string.Format("INSERT INTO DONVITINH VALUES ('{0}', N'{1}')",
                        txtMADVT.Text,
                        txtTENDVT.Text
                        );
                        kn.Thucthi(query);
                        getlistDVT();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn thêm!");
            }
        }

        private void btnsuaDVT_Click(object sender, EventArgs e)
        {
            if (txtMADVT.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM DONVITINH WHERE MADVT like '{0}'", txtMADVT.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        string query = string.Format("UPDATE DONVITINH SET TENDVT=N'{0}' where MADVT='{1}'",
                        txtTENDVT.Text,
                        txtMADVT.Text
                        );
                        kn.Thucthi(query);
                        getlistDVT();
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

        private void btnsuaCV_Click(object sender, EventArgs e)
        {
            if (txtMACV.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM CHUCVU WHERE MACV like '{0}'", txtMACV.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (int.TryParse(txtLUONG.Text, out int luong))
                        {
                            string query = string.Format("UPDATE CHUCVU SET TENCV=N'{0}',LUONGCB=N'{1}' where MACV='{2}'",
                            txtTENCV.Text,
                            luong,
                            txtMACV.Text);
                            kn.Thucthi(query);
                            getlistCV();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'Lương'");
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

        private void btnxoaDVT_Click(object sender, EventArgs e)
        {
            if (txtMADVT.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM DONVITINH WHERE MADVT like '{0}'", txtMADVT.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = string.Format("DELETE FROM DONVITINH WHERE MADVT like '{0}'", txtMADVT.Text);
                            bool kq = kn.Thucthi(query);
                            if (kq)
                            {
                                MessageBox.Show("Xóa thành công");
                                getlistDVT();
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
                MessageBox.Show("Vui lòng điền thông tin muốn sửa!");
            }
        }

        private void btnxoaCV_Click(object sender, EventArgs e)
        {
            if (txtMACV.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM CHUCVU WHERE MACV like '{0}'", txtMACV.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = string.Format("DELETE FROM CHUCVU WHERE MACV like '{0}'", txtMACV.Text);
                            bool kq = kn.Thucthi(query);
                            if (kq)
                            {
                                MessageBox.Show("Xóa thành công");
                                getlistCV();
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
                MessageBox.Show("Vui lòng điền thông tin muốn sửa!");
            }
        }

        private void btntimkiemDVT_Click(object sender, EventArgs e)
        {
            if (txtMADVT.Text != "" || txtTENDVT.Text != "")
            {
                string query = string.Format("SELECT * FROM DONVITINH WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(txtMADVT.Text))
                {
                    query += $"AND MADVT LIKE '{txtMADVT.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtTENDVT.Text))
                {
                    query += $"AND TENDVT LIKE N'%{txtTENDVT.Text}%' ";
                }
                DataSet ds = kn.Laydulieu(query);
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Đặt định dạng ngày tháng năm cho cột Ngày sinh (index 2) và Ngày đăng ký (index 5)
                    dataGridViewDVT.DataSource = ds.Tables[0];
                    // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                    dataGridViewDVT.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                    // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                    dataGridViewDVT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridViewDVT.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                    dataGridViewDVT.Columns[0].HeaderText = "Mã đơn vị tính";
                    dataGridViewDVT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt tiêu đề của cột ở giữa
                    dataGridViewDVT.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridViewDVT.Columns[1].HeaderText = "Tên đơn vị tính";
                    dataGridViewDVT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt nội dung của cột "Họ tên" sang trái
                    dataGridViewDVT.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridViewDVT.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridViewDVT.MouseWheel += dataGridViewDVT_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
                }
            }
        }

        private void btntimkiemCV_Click(object sender, EventArgs e)
        {
            if (txtMACV.Text != "" || txtTENCV.Text != "" || txtLUONG.Text != "")
            {
                string query = string.Format("SELECT * FROM CHUCVU WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(txtMACV.Text))
                {
                    query += $"AND MACV LIKE '{txtMACV.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtTENCV.Text))
                {
                    query += $"AND TENCV LIKE N'%{txtTENCV.Text}%' ";
                }
                if (!string.IsNullOrWhiteSpace(txtLUONG.Text))
                {
                    query += $"AND LUONGCB = '{txtLUONG.Text}' ";
                }
                DataSet ds = kn.Laydulieu(query);
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Đặt định dạng ngày tháng năm cho cột Ngày sinh (index 2) và Ngày đăng ký (index 5)
                    dataGridViewCV.DataSource = ds.Tables[0];
                    // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                    dataGridViewCV.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                    // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                    dataGridViewCV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridViewCV.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                    dataGridViewCV.Columns[0].HeaderText = "Mã chức vụ";
                    dataGridViewCV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt tiêu đề của cột ở giữa
                    dataGridViewCV.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridViewCV.Columns[1].HeaderText = "Tên chức vụ";
                    dataGridViewCV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt nội dung của cột "Họ tên" sang trái
                    dataGridViewCV.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridViewCV.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridViewCV.Columns[2].HeaderText = "Lương";
                    dataGridViewCV.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridViewCV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewCV.MouseWheel += dataGridViewCV_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
                }
            }
        }
    }
}

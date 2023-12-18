using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MUSICTALENT.Models;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MUSICTALENT
{
    public partial class DSNhanVien : Form
    {
        Conection kn = new Conection();
        public DSNhanVien()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Mở rộng form để lấp đầy toàn bộ màn hình khi form được khởi tạo
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANV.TextChanged += new EventHandler(txtMANV_TextChanged);
            txtHOTEN.TextChanged += new EventHandler(txtHOTEN_TextChanged);
            txtNGSINH.TextChanged += new EventHandler(txtNGSINH_TextChanged_1);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            cbbMACV.SelectedIndexChanged += new EventHandler(cbbMACV_SelectedIndexChanged);
            txtTENCHUCVU.TextChanged += new EventHandler(txtTENCHUCVU_TextChanged);
            txtNGVL.TextChanged += new EventHandler(txtNGVL_TextChanged);
            txtNGHIPHEP.TextChanged += new EventHandler(txtNGHIPHEP_TextChanged);
            txtNGHIKHONGPHEP.TextChanged += new EventHandler(txtNGHIKHONGPHEP_TextChanged);
            txtLUONG.TextChanged += new EventHandler(txtLUONG_TextChanged);
        }

        private void DSNhanVien_Load(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANV.TextChanged += new EventHandler(txtMANV_TextChanged);
            txtHOTEN.TextChanged += new EventHandler(txtHOTEN_TextChanged);
            txtNGSINH.TextChanged += new EventHandler(txtNGSINH_TextChanged_1);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            cbbMACV.SelectedIndexChanged += new EventHandler(cbbMACV_SelectedIndexChanged);
            txtTENCHUCVU.TextChanged += new EventHandler(txtTENCHUCVU_TextChanged);
            txtNGVL.TextChanged += new EventHandler(txtNGVL_TextChanged);
            txtNGHIPHEP.TextChanged += new EventHandler(txtNGHIPHEP_TextChanged);
            txtNGHIKHONGPHEP.TextChanged += new EventHandler(txtNGHIKHONGPHEP_TextChanged);
            txtLUONG.TextChanged += new EventHandler(txtLUONG_TextChanged);
        }

        public void cleartext()
        {
            txtMANV.Text = "";
            txtNGSINH.Text = "";
            txtHOTEN.Text = "";
            txtDIACHI.Text = "";
            txtSDT.Text = "";
            cbbMACV.Text = "";
            txtTENCHUCVU.Text = "";
            txtNGVL.Text = "";
            txtNGHIPHEP.Text = "";
            txtNGHIKHONGPHEP.Text = "";
            txtLUONG.Text = "";
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btntimkiem.Enabled = true;
            btnthoat.Enabled = true;
        }

        public void getlist()
        {
            string query = "SELECT MANV, HOTEN, NGSINH, DCHI, SDT, TENCV, NGVL, NGNGHIPHEP, NGNGHIKHONGPHEP, LUONGCB FROM NHANVIEN, CHUCVU WHERE NHANVIEN.MACV = CHUCVU.MACV";
            DataSet ds = kn.Laydulieu(query);
            string query1 = "SELECT * FROM CHUCVU";
            DataSet ds1 = kn.Laydulieu(query1);
            if (ds != null && ds.Tables.Count > 0)
            {
                // Đặt định dạng ngày tháng năm cho cột Ngày sinh (index 2) và Ngày đăng ký (index 5)
                dataGridView1.DataSource = ds.Tables[0];
                // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt tiêu đề của cột ở giữa
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].HeaderText = "Họ tên";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Đặt nội dung của cột "Họ tên" sang trái
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[2].HeaderText = "Ngày sinh";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].HeaderText = "SĐT";
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].HeaderText = "Tên chức vụ";
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[6].HeaderText = "Ngày vô làm";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].HeaderText = "Nghỉ phép";
                dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[8].HeaderText = "Nghỉ không phép";
                dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[9].HeaderText = "Lương";
                dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.MouseWheel += DataGridView1_MouseWheel; // Gán sự kiện MouseWheel cho DataGridView
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    cbbMACV.DataSource = ds1.Tables[0];
                    cbbMACV.ValueMember = "MACV";
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
            if (string.IsNullOrWhiteSpace(txtMANV.Text) && string.IsNullOrWhiteSpace(txtHOTEN.Text) && string.IsNullOrWhiteSpace(txtNGSINH.Text) && string.IsNullOrWhiteSpace(cbbMACV.Text) && string.IsNullOrWhiteSpace(txtSDT.Text) && string.IsNullOrWhiteSpace(txtDIACHI.Text) && string.IsNullOrWhiteSpace(txtLUONG.Text) && string.IsNullOrWhiteSpace(txtNGHIKHONGPHEP.Text) && string.IsNullOrWhiteSpace(txtNGHIPHEP.Text) && string.IsNullOrWhiteSpace(txtNGVL.Text) && string.IsNullOrWhiteSpace(txtTENCHUCVU.Text))
            {
                btnlammoi.Enabled = false;
            }
            else
            {
                btnlammoi.Enabled = true;
            }
        }

        private void txtMANV_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtHOTEN_TextChanged(object sender, EventArgs e)
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

        private void txtNGVL_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGHIPHEP_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void cbbMACV_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
            if (cbbMACV.SelectedIndex >= 0)
            {
                string selectedMACV = cbbMACV.SelectedValue.ToString();

                string query = "SELECT TENCV, LUONGCB FROM CHUCVU WHERE MACV = '" + selectedMACV + "'";
                DataSet ds = kn.Laydulieu(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtTENCHUCVU.Text = ds.Tables[0].Rows[0]["TENCV"].ToString();
                    txtLUONG.Text = ds.Tables[0].Rows[0]["LUONGCB"].ToString();
                }
            }
        }


        private void txtTENCHUCVU_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGHIKHONGPHEP_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtLUONG_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGSINH_TextChanged_1(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMANV.TextChanged += new EventHandler(txtMANV_TextChanged);
            txtHOTEN.TextChanged += new EventHandler(txtHOTEN_TextChanged);
            txtNGSINH.TextChanged += new EventHandler(txtNGSINH_TextChanged_1);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            cbbMACV.SelectedIndexChanged += new EventHandler(cbbMACV_SelectedIndexChanged);
            txtTENCHUCVU.TextChanged += new EventHandler(txtTENCHUCVU_TextChanged);
            txtNGVL.TextChanged += new EventHandler(txtNGVL_TextChanged);
            txtNGHIPHEP.TextChanged += new EventHandler(txtNGHIPHEP_TextChanged);
            txtNGHIKHONGPHEP.TextChanged += new EventHandler(txtNGHIKHONGPHEP_TextChanged);
            txtLUONG.TextChanged += new EventHandler(txtLUONG_TextChanged);
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text != "")
            {
                // Kiểm tra xem ngày hiện tại là ngày bắt đầu của ngày tháng năm hay chỉ ngày trong dữ liệu
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHANVIEN WHERE MANV like '{0}'", txtMANV.Text);
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
                        if (int.TryParse(txtSDT.Text, out int sdt))
                        {
                            if (int.TryParse(txtNGHIPHEP.Text, out int np))
                            {
                                if (int.TryParse(txtNGHIKHONGPHEP.Text, out int kp))
                                {
                                    if (DateTime.TryParseExact(txtNGSINH.Text, new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngsinh))
                                    {
                                        if (DateTime.TryParseExact(txtNGVL.Text, new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngvl))
                                        {
                                            if (cbbMACV.Text != "")
                                            {
                                                // Kiểm tra ngày sinh nhỏ hơn ngày hiện tại
                                                if (ngsinh < currentDate && ngvl < currentDate && ngsinh < ngvl)
                                                {
                                                    string query = string.Format("INSERT INTO NHANVIEN VALUES ('{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', {6}, {7}, '{8}')",
                                                        txtMANV.Text,
                                                        txtHOTEN.Text,
                                                        txtDIACHI.Text,
                                                        sdt,
                                                        ngsinh.ToString("yyyy-MM-dd"), // Định dạng ngày tháng theo chuẩn để lưu vào SQL Server
                                                        ngvl.ToString("yyyy-MM-dd"),
                                                        np,
                                                        kp,
                                                        cbbMACV.SelectedItem.ToString()
                                                        );
                                                    kn.Thucthi(query);
                                                    getlist();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Ngày sinh và ngày vô làm phải nhỏ hơn ngày hiện tại và ngày sinh nhỏ hơn ngày vô làm!");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Vui lòng chọn trường 'Mã chức vụ'!");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày vô làm'");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày sinh'");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vui lòng nhập số vào trường 'Ngày không phép'");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập số vào trường 'Ngày nghỉ phép'");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'SĐT'");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn thêm!");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text != "")
            {
                // Kiểm tra xem ngày hiện tại là ngày bắt đầu của ngày tháng năm hay chỉ ngày trong dữ liệu
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHANVIEN WHERE MANV LIKE '{0}'", txtMANV.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (int.TryParse(txtSDT.Text, out int sdt))
                        {
                            if (int.TryParse(txtNGHIPHEP.Text, out int np))
                            {
                                if (int.TryParse(txtNGHIKHONGPHEP.Text, out int kp))
                                {
                                    if (DateTime.TryParseExact(txtNGSINH.Text, new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngsinh))
                                    {
                                        if (DateTime.TryParseExact(txtNGVL.Text, new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngvl))
                                        {
                                            if (cbbMACV.Text != "")
                                            {
                                                // Kiểm tra ngày sinh nhỏ hơn ngày hiện tại
                                                if (ngsinh < currentDate && ngvl < currentDate && ngsinh < ngvl)
                                                {
                                                    string query = string.Format("UPDATE NHANVIEN SET HOTEN=N'{0}', DCHI=N'{1}', SDT='{2}', NGSINH=N'{3}', NGVL='{4}', NGNGHIPHEP={5}, NGNGHIKHONGPHEP={6}, MACV='{7}' WHERE MANV='{8}'",
                                                        txtHOTEN.Text,
                                                        txtDIACHI.Text,
                                                        sdt,
                                                        ngsinh.ToString("yyyy-MM-dd"), // Định dạng ngày tháng theo chuẩn để lưu vào SQL Server
                                                        ngvl.ToString("yyyy-MM-dd"),
                                                        np,
                                                        kp,
                                                        cbbMACV.SelectedValue,
                                                        txtMANV.Text);
                                                    kn.Thucthi(query);
                                                    getlist();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Ngày sinh và ngày vô làm phải nhỏ hơn ngày hiện tại và ngày sinh nhỏ hơn ngày vô làm!");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Vui lòng chọn trường 'Mã chức vụ'!");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày vô làm'");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày sinh'");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vui lòng nhập số vào trường 'Ngày không phép'");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập số vào trường 'Ngày nghỉ phép'");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'SĐT'");
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
                MessageBox.Show("Vui lòng điền thông tin muốn thêm!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text != "")
            {
                // Kiểm tra xem ngày hiện tại là ngày bắt đầu của ngày tháng năm hay chỉ ngày trong dữ liệu
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM NHANVIEN WHERE MANV LIKE '{0}'", txtMANV.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = string.Format("DELETE FROM NHANVIEN WHERE MANV='{0}'",
                            txtMANV.Text);
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

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text != "" || txtHOTEN.Text != "" || txtNGSINH.Text != "" || txtDIACHI.Text != "" || txtSDT.Text != "" || txtNGVL.Text != "" || cbbMACV.Text != "" || txtTENCHUCVU.Text != "" || txtNGHIPHEP.Text != "" || txtNGHIKHONGPHEP.Text != "" || txtLUONG.Text != "")
            {
                string query = string.Format("SELECT MANV, HOTEN, NGSINH, DCHI, SDT, TENCV, NGVL, NGNGHIPHEP, NGNGHIKHONGPHEP, LUONGCB FROM NHANVIEN, CHUCVU WHERE NHANVIEN.MACV = CHUCVU.MACV AND 1=1");

                if (!string.IsNullOrWhiteSpace(txtMANV.Text))
                {
                    query += $"AND MANV LIKE '{txtMANV.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtHOTEN.Text))
                {
                    query += $"AND HOTEN LIKE N'%{txtHOTEN.Text}%' ";
                }
                if (!string.IsNullOrWhiteSpace(txtNGSINH.Text))
                {
                    query += $"AND NGSINH = '{txtNGSINH.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtDIACHI.Text))
                {
                    query += $"AND DCHI LIKE N'%{txtDIACHI.Text}%' ";
                }
                if (!string.IsNullOrWhiteSpace(txtTENCHUCVU.Text) && !string.IsNullOrWhiteSpace(txtLUONG.Text))
                {
                    query += $"AND TENCV LIKE N'%{txtTENCHUCVU.Text}%' AND LUONGCB = '{txtLUONG.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    query += $"AND SDT = '{txtSDT.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtNGVL.Text))
                {
                    query += $"AND NGVL = '{txtNGVL.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtNGHIPHEP.Text))
                {
                    query += $"AND NGNGHIPHEP = '{txtNGHIPHEP.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtNGHIKHONGPHEP.Text))
                {
                    query += $"AND NGNGHIKHONGPHEP = '{txtNGHIKHONGPHEP.Text}' ";
                }
                DataSet ds = kn.Laydulieu(query);
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Đặt định dạng ngày tháng năm cho cột Ngày sinh (index 2) và Ngày đăng ký (index 5)
                    dataGridView1.DataSource = ds.Tables[0];
                    // Đặt WrapMode của tiêu đề cột trong DataGridView để nó không wrap (không xuống dòng)
                    dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                    // Đặt ColumnHeadersHeightSizeMode của DataGridView để tiêu đề cột hiển thị trên cùng một hàng
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 35; // Thiết lập chiều cao cho tiêu đề cột

                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt tiêu đề của cột ở giữa
                    dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[1].HeaderText = "Họ tên";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    // Đặt nội dung của cột "Họ tên" sang trái
                    dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[2].HeaderText = "Ngày sinh";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                    dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].HeaderText = "SĐT";
                    dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].HeaderText = "Tên chức vụ";
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.Columns[6].HeaderText = "Ngày vô làm";
                    dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[7].HeaderText = "Nghỉ phép";
                    dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[8].HeaderText = "Nghỉ không phép";
                    dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[9].HeaderText = "Lương";
                    dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
    }
}

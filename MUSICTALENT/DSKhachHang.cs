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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MUSICTALENT
{
    public partial class DSKhachHang : Form
    {
        Conection kn = new Conection();
        public DSKhachHang()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Mở rộng form để lấp đầy toàn bộ màn hình khi form được khởi tạo
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMAKH.TextChanged += new EventHandler(txtMAKH_TextChanged);
            txtHOTEN.TextChanged += new EventHandler(txtHOTEN_TextChanged);
            txtNGSINH_DAY.TextChanged += new EventHandler(txtNGSINH_DAY_TextChanged);
            txtNGSINH_MONTH.TextChanged += new EventHandler(txtNGSINH_MONTH_TextChanged);
            txtNGSINH_YEAR.TextChanged += new EventHandler(txtNGSINH_YEAR_TextChanged);
            txtNGDK_DAY.TextChanged += new EventHandler(txtNGDK_DAY_TextChanged);
            txtNGDK_MONTH.TextChanged += new EventHandler(txtNGDK_MONTH_TextChanged);
            txtNGDK_YEAR.TextChanged += new EventHandler(txtNGDK_YEAR_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtDOANHSO.TextChanged += new EventHandler(txtDOANHSO_TextChanged);
        }

        private void DSKhachHang_Load(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMAKH.TextChanged += new EventHandler(txtMAKH_TextChanged);
            txtHOTEN.TextChanged += new EventHandler(txtHOTEN_TextChanged);
            txtNGSINH_DAY.TextChanged += new EventHandler(txtNGSINH_DAY_TextChanged);
            txtNGSINH_MONTH.TextChanged += new EventHandler(txtNGSINH_MONTH_TextChanged);
            txtNGSINH_YEAR.TextChanged += new EventHandler(txtNGSINH_YEAR_TextChanged);
            txtNGDK_DAY.TextChanged += new EventHandler(txtNGDK_DAY_TextChanged);
            txtNGDK_MONTH.TextChanged += new EventHandler(txtNGDK_MONTH_TextChanged);
            txtNGDK_YEAR.TextChanged += new EventHandler(txtNGDK_YEAR_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtDOANHSO.TextChanged += new EventHandler(txtDOANHSO_TextChanged);
        }

        public void cleartext()
        {
            txtMAKH.Text = "";
            txtNGSINH_DAY.Text = "";
            txtNGSINH_MONTH.Text = "";
            txtNGSINH_YEAR.Text = "";
            txtHOTEN.Text = "";
            txtDIACHI.Text = "";
            txtSDT.Text = "";
            txtNGDK_DAY.Text = "";
            txtNGDK_MONTH.Text = "";
            txtNGDK_YEAR.Text = "";
            txtDOANHSO.Text = "";
            btnThem.Enabled = true;
            btnsua.Enabled = true;
            btnXoa.Enabled = true;
            btnTimkiem.Enabled = true;
            btnThoat.Enabled = true;
        }

        public void getlist()
        {
            string query = "SELECT MAKH, HOTEN, NGSINH, DCHI, SDT, NGDKY, DOANHSO FROM KHACHHANG";
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

                dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
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
                dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy"; // Ngày sinh
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].HeaderText = "SĐT";
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].HeaderText = "Ngày đăng ký";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy"; // Ngày đăng ký
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Doanh số";
                dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            if (string.IsNullOrWhiteSpace(txtMAKH.Text) && string.IsNullOrWhiteSpace(txtHOTEN.Text) && string.IsNullOrWhiteSpace(txtNGSINH_DAY.Text) && string.IsNullOrWhiteSpace(txtNGSINH_MONTH.Text) && string.IsNullOrWhiteSpace(txtNGSINH_YEAR.Text) && string.IsNullOrWhiteSpace(txtSDT.Text) && string.IsNullOrWhiteSpace(txtDIACHI.Text) && string.IsNullOrWhiteSpace(txtNGDK_DAY.Text) && string.IsNullOrWhiteSpace(txtNGDK_MONTH.Text) && string.IsNullOrWhiteSpace(txtNGDK_YEAR.Text) && string.IsNullOrWhiteSpace(txtDOANHSO.Text))
            {
                btnLammoi.Enabled = false;
            }
            else
            {
                btnLammoi.Enabled = true;
            }
        }

        private void txtMAKH_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGSINH_DAY_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGSINH_MONTH_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGSINH_YEAR_TextChanged(object sender, EventArgs e)
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

        private void txtNGDK_DAY_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGDK_MONTH_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtNGDK_YEAR_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void txtDOANHSO_TextChanged(object sender, EventArgs e)
        {
            CheckTextboxes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r > 0)
            {
                btnThem.Enabled = true;
                btnLammoi.Enabled = false;
                btnXoa.Enabled = true;
                btnsua.Enabled = true;
                btnThoat.Enabled = true;
                btnTimkiem.Enabled = true;
                txtMAKH.Text = dataGridView1.Rows[r].Cells["MAKH"].Value.ToString();
                txtHOTEN.Text = dataGridView1.Rows[r].Cells["HOTEN"].Value.ToString();
                if (dataGridView1.CurrentRow != null)
                {
                    int selectedRow = dataGridView1.CurrentRow.Index;

                    if (dataGridView1.Rows[selectedRow].Cells["NGSINH"].Value != null)
                    {
                        DateTime dateValue = (DateTime)dataGridView1.Rows[selectedRow].Cells["NGSINH"].Value;

                        // Lấy ngày, tháng và năm từ giá trị DateTime
                        int day = dateValue.Day;
                        int month = dateValue.Month;
                        int year = dateValue.Year;

                        // Gán giá trị vào các TextBox tương ứng
                        txtNGSINH_DAY.Text = day.ToString();
                        txtNGSINH_MONTH.Text = month.ToString();
                        txtNGSINH_YEAR.Text = year.ToString();
                    }
                }
                txtDIACHI.Text = dataGridView1.Rows[r].Cells["DCHI"].Value.ToString();
                txtSDT.Text = dataGridView1.Rows[r].Cells["SDT"].Value.ToString();
                if (dataGridView1.CurrentRow != null)
                {
                    int selectedRow = dataGridView1.CurrentRow.Index;

                    if (dataGridView1.Rows[selectedRow].Cells["NGDKY"].Value != null)
                    {
                        DateTime dateValue = (DateTime)dataGridView1.Rows[selectedRow].Cells["NGDKY"].Value;

                        // Lấy ngày, tháng và năm từ giá trị DateTime
                        int day = dateValue.Day;
                        int month = dateValue.Month;
                        int year = dateValue.Year;

                        // Gán giá trị vào các TextBox tương ứng
                        txtNGDK_DAY.Text = day.ToString();
                        txtNGDK_MONTH.Text = month.ToString();
                        txtNGDK_YEAR.Text = year.ToString();
                    }
                }
                txtDOANHSO.Text = dataGridView1.Rows[r].Cells["DOANHSO"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMAKH.Text != "")
            {
                btnLammoi.Enabled = true;
                // Kiểm tra xem ngày hiện tại là ngày bắt đầu của ngày tháng năm hay chỉ ngày trong dữ liệu
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM KHACHHANG WHERE MAKH like '{0}'", txtMAKH.Text);
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
                            if (DateTime.TryParseExact($"{txtNGSINH_DAY.Text}/{txtNGSINH_MONTH.Text}/{txtNGSINH_YEAR.Text}", new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngsinh))
                            {
                                if (DateTime.TryParseExact($"{txtNGDK_DAY.Text}/{txtNGDK_MONTH.Text}/{txtNGDK_YEAR.Text}", new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngdky))
                                {
                                    if (int.TryParse(txtDOANHSO.Text, out int doanhso))
                                    {
                                        // Kiểm tra ngày sinh nhỏ hơn ngày hiện tại
                                        if (ngsinh < currentDate && ngdky < currentDate && ngsinh < ngdky)
                                        {
                                            string query = string.Format("INSERT INTO KHACHHANG VALUES ('{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', {6})",
                                                txtMAKH.Text,
                                                txtHOTEN.Text,
                                                txtDIACHI.Text,
                                                sdt,
                                                ngsinh.ToString("yyyy-MM-dd"), // Định dạng ngày tháng theo chuẩn để lưu vào SQL Server
                                                ngdky.ToString("yyyy-MM-dd"),
                                                doanhso);
                                            kn.Thucthi(query);
                                            getlist();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ngày sinh và ngày đăng ký phải nhỏ hơn ngày hiện tại và ngày sinh nhỏ hơn ngày đăng ký!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vui lòng nhập số vào trường 'Doanh số'");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày đăng ký'");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày sinh'");
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



        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMAKH.Text != "")
            {
                btnLammoi.Enabled = true;
                DateTime currentDate = DateTime.Now.Date;
                string checkQuery = string.Format("SELECT COUNT(*) FROM KHACHHANG WHERE MAKH like '{0}'", txtMAKH.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (int.TryParse(txtSDT.Text, out int sdt))
                        {
                            if (DateTime.TryParseExact($"{txtNGSINH_DAY.Text}/{txtNGSINH_MONTH.Text}/{txtNGSINH_YEAR.Text}", new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngsinh))
                            {
                                if (DateTime.TryParseExact($"{txtNGDK_DAY.Text}/{txtNGDK_MONTH.Text}/{txtNGDK_YEAR.Text}", new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngdky))
                                {
                                    if (ngsinh < currentDate && ngdky < currentDate && ngsinh < ngdky)
                                    {
                                        if (int.TryParse(txtDOANHSO.Text, out int doanhso))
                                        {
                                            string query = string.Format("UPDATE KHACHHANG SET HOTEN=N'{0}', DCHI=N'{1}', SDT='{2}', NGSINH=N'{3}', NGDKY='{4}', DOANHSO={5} WHERE MAKH='{6}'",
                                                txtHOTEN.Text,
                                                txtDIACHI.Text,
                                                sdt,
                                                ngsinh.ToString("yyyy-MM-dd"), // Định dạng ngày tháng theo chuẩn để lưu vào SQL Server
                                                ngdky.ToString("yyyy-MM-dd"),
                                                doanhso,
                                                txtMAKH.Text);
                                            kn.Thucthi(query);
                                            getlist();

                                        }
                                        else
                                        {
                                            MessageBox.Show("Vui lòng nhập số vào trường 'Doanh số'");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ngày sinh và ngày đăng ký phải nhỏ hơn ngày hiện tại và ngày sinh nhỏ hơn ngày đăng ký!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày đăng ký'");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập ngày vào trường 'Ngày sinh'");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số vào trường 'SĐT'");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã không tồn tại. Vui lòng nhập mã khác!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin muốn sửa!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMAKH.Text != "")
            {
                string checkQuery = string.Format("SELECT COUNT(*) FROM KHACHHANG WHERE MAKH like '{0}'", txtMAKH.Text);
                DataSet ds = kn.Laydulieu(checkQuery);
                if (ds != null && ds.Tables.Count > 0)
                {
                    int check = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    if (check > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = string.Format("DELETE FROM KHACHHANG WHERE MAKH='{0}'",
                            txtMAKH.Text);
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

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            getlist();
            cleartext();
            CheckTextboxes(); // Kiểm tra ngay khi form được khởi tạo
            txtMAKH.TextChanged += new EventHandler(txtMAKH_TextChanged);
            txtHOTEN.TextChanged += new EventHandler(txtHOTEN_TextChanged);
            txtNGSINH_DAY.TextChanged += new EventHandler(txtNGSINH_DAY_TextChanged);
            txtNGSINH_MONTH.TextChanged += new EventHandler(txtNGSINH_MONTH_TextChanged);
            txtNGSINH_YEAR.TextChanged += new EventHandler(txtNGSINH_YEAR_TextChanged);
            txtNGDK_DAY.TextChanged += new EventHandler(txtNGDK_DAY_TextChanged);
            txtNGDK_MONTH.TextChanged += new EventHandler(txtNGDK_MONTH_TextChanged);
            txtNGDK_YEAR.TextChanged += new EventHandler(txtNGDK_YEAR_TextChanged);
            txtSDT.TextChanged += new EventHandler(txtSDT_TextChanged);
            txtDIACHI.TextChanged += new EventHandler(txtDIACHI_TextChanged);
            txtDOANHSO.TextChanged += new EventHandler(txtDOANHSO_TextChanged);
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txtMAKH.Text != "" || txtHOTEN.Text != "" || txtNGSINH_DAY.Text != "" || txtNGSINH_MONTH.Text != "" || txtNGSINH_YEAR.Text != "" || txtDIACHI.Text != "" || txtSDT.Text != "" || txtNGDK_DAY.Text != "" || txtNGDK_MONTH.Text != "" || txtNGDK_YEAR.Text != "" || txtDOANHSO.Text != "")
            {
                btnLammoi.Enabled = true;

                string query = string.Format("SELECT MAKH, HOTEN, NGSINH, DIACHI, SDT, NGDKY, DOANHSO FROM KHACHHANG WHERE 1=1");

                if (!string.IsNullOrWhiteSpace(txtMAKH.Text))
                {
                    query += $"AND MAKH LIKE '{txtMAKH.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtHOTEN.Text))
                {
                    query += $"AND HOTEN LIKE N'{txtHOTEN.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtNGSINH_DAY.Text) && !string.IsNullOrWhiteSpace(txtNGSINH_MONTH.Text) && !string.IsNullOrWhiteSpace(txtNGSINH_YEAR.Text))
                {
                    if (DateTime.TryParseExact($"{txtNGSINH_DAY.Text}/{txtNGSINH_MONTH.Text}/{txtNGSINH_YEAR.Text}", new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngsinh))
                    {
                        query += $"AND YEAR(NGSINH) = {ngsinh.Year} OR MONTH(NGSINH) = {ngsinh.Month} OR DAY(NGSINH) = {ngsinh.Day} ";
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtDIACHI.Text))
                {
                    query += $"AND DIACHI LIKE N'{txtDIACHI.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    query += $"AND SDT = '{txtSDT.Text}' ";
                }
                if (!string.IsNullOrWhiteSpace(txtNGDK_DAY.Text) && !string.IsNullOrWhiteSpace(txtNGDK_MONTH.Text) && !string.IsNullOrWhiteSpace(txtNGDK_YEAR.Text))
                {
                    if (DateTime.TryParseExact($"{txtNGDK_DAY.Text}/{txtNGDK_MONTH.Text}/{txtNGDK_YEAR.Text}", new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngdky))
                    {
                        query += $"AND YEAR(NGDKY) = {ngdky.Year} OR MONTH(NGDKY) = {ngdky.Month} OR DAY(NGDKY) = {ngdky.Day} ";
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtDOANHSO.Text))
                {
                    query += $"AND DOANHSO = '{txtDOANHSO.Text}' ";
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

                    dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
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
                    dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy"; // Ngày sinh
                    dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                    dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].HeaderText = "SĐT";
                    dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].HeaderText = "Ngày đăng ký";
                    dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy"; // Ngày đăng ký
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[6].HeaderText = "Doanh số";
                    dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

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
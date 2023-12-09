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
    public partial class Nhaccu : Form
    {
        Conection kn = new Conection();
        public Nhaccu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void cleartext()
        {
            txtMANC.Enabled = true;
            txtTENNC.Text = "";
            UDSOLUONG.Text = "";
            cbbMADVT.Text = "";
            txtGHICHU.Text = "";
            txtTENDVT.Text = "";
            txtGIA.Text = "";
            btnThem.Enabled = true;
            btnlammoi.Enabled = false;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnthoat.Enabled = true;
            btntimkiem.Enabled = true;
        }

        public void getlist()
        {
            string query = "select MANC, TENNC, SOLUONG, GHICHU, GIA, TENDVT from NHACCU, DONVITINH where NHACCU.MADVT = DONVITINH.MADVT";
            DataSet ds = kn.Laydulieu(query);
            string query1 = "select * from DONVITINH";
            DataSet ds1 = kn.Laydulieu(query1);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                if (ds1 != null && ds1.Tables.Count > 0) {
                    cbbMADVT.DataSource = ds1.Tables[0];
                    cbbMADVT.ValueMember = "MADVT";
                }  
            }
        }

        private void Nhaccu_Load(object sender, EventArgs e)
        {
            getlist();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r > 0)
            {
                btnThem.Enabled = true;
                btnlammoi.Enabled = true;
                btnxoa.Enabled = true;
                btnsua.Enabled = true;
                btnthoat.Enabled = true;
                btntimkiem.Enabled = true;
                txtMANC.Text = dataGridView1.Rows[r].Cells["MANC"].Value.ToString();
                txtTENNC.Text = dataGridView1.Rows[r].Cells["TENNC"].Value.ToString();
                UDSOLUONG.Text = dataGridView1.Rows[r].Cells["SOLUONG"].Value.ToString();
                cbbMADVT.SelectedValue = dataGridView1.Rows[r].Cells["MADVT"].Value.ToString();
                txtTENDVT.Text = dataGridView1.Rows[r].Cells["TENDVT"].Value.ToString();
                txtGHICHU.Text = dataGridView1.Rows[r].Cells["GHICHU"].Value.ToString();
                txtGIA.Text = dataGridView1.Rows[r].Cells["GIA"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into NHACCU values(" + txtMANC.Text + ", N'" + txtTENNC.Text + "', " + UDSOLUONG.Text + ", " + cbbMADVT.SelectedIndex + ", N'" + txtGHICHU.Text + "', " + txtGIA.Text + "");
            kn.Thucthi(query);
            getlist();
            cleartext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = string.Format("update NHACCU set TENNC=N'" + txtTENNC.Text + "',SOLUONG=" + UDSOLUONG.Text + ", MADVT=" + cbbMADVT.SelectedIndex + ", GHICHU=N'" + txtGHICHU.Text + "', GIA=" + txtGIA.Text + " where MANC=" + txtMANC.Text + ";");
            DataSet ds = kn.Laydulieu(query);
            kn.Thucthi(query);
            getlist();
            cleartext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Format("delete from NHACCU where MANC=" + txtMANC.Text + ";");
            DataSet ds = kn.Laydulieu(query);
            kn.Thucthi(query);
            getlist();
            cleartext();
        }

        private void nhạcCụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhaccu NC = new Nhaccu();
            NC.Show();
            this.Hide();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

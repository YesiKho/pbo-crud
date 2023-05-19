using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _222410103007
{
    public partial class Form1 : Form
    {
        DatabaseHelpers db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new DatabaseHelpers();
            readBuku();
        }

        private void readBuku()
        {
            string sql = "SELECT * FROM tbbuku";
            dataGridView1.DataSource = db.getData(sql);
            dataGridView1.Columns["id_buku"].HeaderText = "ID Buku";
            dataGridView1.Columns["kode_buku"].HeaderText = "Kode Buku";
            dataGridView1.Columns["judul_buku"].HeaderText = "Judul Buku";
            dataGridView1.Columns["penulis_buku"].HeaderText = "Penulis Buku";
            dataGridView1.Columns["tahun_terbit"].HeaderText = "Tahun Terbit";
            dataGridView1.Columns["edit"].DisplayIndex = 6;
            dataGridView1.Columns["delete"].DisplayIndex = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO tbbuku(id_buku, kode_buku, judul_buku, penulis_buku, tahun_terbit) VALUES ({textBox1.Text},'{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')";

            DialogResult dialogResult = MessageBox.Show("APAKAH ANDA YAKIN?", "INSERT BUKU", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Berhasil!");
                db.exc(sql);
                readBuku();
                button3.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Gagal!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "edit")
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id_buku"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["kode_buku"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["judul_buku"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["penulis_buku"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["tahun_terbit"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {
                var id_buku = dataGridView1.Rows[e.RowIndex].Cells["id_buku"].Value.ToString();
                string sql = $"delete from tbbuku where id_buku = {id_buku}";

                DialogResult dialogResult = MessageBox.Show("APAKAH ANDA YAKIN?", "DELETE BUKU", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("Berhasil!");
                    db.exc(sql);
                    readBuku();
                    button3.PerformClick();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Gagal!");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"update tbbuku set kode_buku = '{textBox2.Text}', judul_buku = '{textBox3.Text}', penulis_buku = '{textBox4.Text}', tahun_terbit = '{textBox5.Text}' where id_buku = {textBox1.Text}";

            DialogResult dialogResult = MessageBox.Show("APAKAH ANDA YAKIN?", "UPDATE BUKU", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Berhasil!");
                db.exc(sql);
                readBuku();
                button3.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Gagal!");
            }
        }
    }
}

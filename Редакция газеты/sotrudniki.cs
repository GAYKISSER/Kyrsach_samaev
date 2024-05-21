using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Редакция_ежедневной_газеты
{
    public partial class sotrudniki : Form
    {
        BD bd = new BD();
        public sotrudniki()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void grid1()
        {
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT * FROM gasetu WHERE tip_g ='на расмотрении'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "gasetu");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public int id;
        private void grid2()
        {
            id = avtorization.id_polzov;
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand($"SELECT * FROM gasetu WHERE tip_g ='на расмотрении' and redactor ='{id}'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "gasetu");
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            predlozenie_gazet add = new predlozenie_gazet();
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grid1();
            grid2();
        }

        private void sotrudniki_Load(object sender, EventArgs e)
        {
            id = avtorization.id_polzov;
            grid1();
            grid2();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы можете предложить газету для рассмотрения, а также изменять данные в своих газетах", "Система");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[a];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var a = $"delete gasetu where id_g='{textBox1.Text}'";
            bd.queryEx(a);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = $"update gasetu set tema_g='{textBox2.Text}', cena='{textBox6.Text}' WHERE redactor = '{avtorization.id_polzov}'";
            bd.queryEx(a);
        }
        Point lastpoint;
        private void sotrudniki_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void sotrudniki_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            avtorization avt = new avtorization();
            this.Close();
            avt.Show();
        }
    }
}

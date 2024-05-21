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
    public partial class polzovatel : Form
    {
        BD bd = new BD();
        
        
        public polzovatel()
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
            SqlCommand com = new SqlCommand(@"SELECT * FROM gasetu WHERE tip_g !='на расмотрении'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "gasetu");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public int test;
        private void grid2()
        {
            //avtorization avt = new avtorization();
            //test = Convert.ToString(avt.id_polzov);
            test = avtorization.id_polzov;
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand($"SELECT id_z,tema_c,tip_c,redactor_c,izdatel_c,cena_c,kol_vo" +
                $" FROM carzina WHERE id_pc = '{test}'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "carzina");
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
        //////////////////////////////////////////////////////////
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[a];

                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = $"delete carzina where id_z = '{textBox8.Text}'";
            bd.queryEx(a);
            clear();
        }

        private void polzovatel_Load(object sender, EventArgs e)
        {
            grid1();
            grid2();           
            balance();
            sum();
        }
        private void sum()
        {
            try
            {
                SqlConnection con = new SqlConnection(bd.sqlCon);
                con.Open();
                SqlCommand com = new SqlCommand($"select sum (cena_c * kol_vo) from carzina where id_pc = {test}", con);
                summ = ((int)com.ExecuteScalar());
                label3.Text = $"Итого: {summ} руб.";
                con.Close();
            }
            catch
            {
                label3.Text = $"Итого: 0 руб.";
            }

;        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[a];

                textBox8.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = $"insert into carzina (id_pc,tema_c,tip_c,redactor_c,izdatel_c,cena_c,kol_vo)\r" +
                $"\nSelect '{test}',tema_g,tip_g,redactor,izdatel,cena,'1' from gasetu where id_g={textBox1.Text}";
            bd.queryEx(a);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grid1();
            grid2();
            sum();
            balance();
        }
        public int many;
        public int summ;
        public void balance()
        {
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand($"select balance from sotrydniki_and_p where id_sp = {test}", con);
            many = ((int)com.ExecuteScalar());
            label6.Text = $"Ваш баланс: {many} руб.";
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var a = $"update carzina set kol_vo = '{textBox7.Text}' where id_z='{textBox8.Text}'";
            bd.queryEx(a);

        }


        private void zakaz_Click(object sender, EventArgs e)
        {
            if (many >= summ)
            {
                var a = $"delete carzina where id_pc='{test}'";
                bd.queryEx(a);
                var b = $"update sotrydniki_and_p set balance = '{many - summ}' where id_sp= {test}";
                bd.queryEx(b);
                clear();
            }
            else
            {
                MessageBox.Show("Недостаточно средств", "Система");
            }
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox6.Text);
                int y = Convert.ToInt32(textBox7.Text);
                int sum = x * y;
                if (many >= sum)
                {
                    var a = $"delete carzina where id_z='{textBox8.Text}'";
                    bd.queryEx(a);
                    var b = $"update sotrydniki_and_p set balance = '{many - sum}' where id_sp= {test}";
                    bd.queryEx(b);
                    clear();
                }
                else
                {
                    MessageBox.Show("Недостаточно средств", "Система");
                }
            }
            catch
            {
                MessageBox.Show("Штото пошло не так", "Система");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            balance popol = new balance();
            popol.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы можете добавить в свою карзину несколько газет и они " +
                $"\nостанутся в ней (а ещё только в нашем приложении вы можете " +
                $"\nкупить газету, если она есть в наличии но её нет в списке доступных" +
                $"\nгазет)Также после каждого действия не забудьте обновить таблицу." ,"Система");
        }
        private void clear()
        {
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }
        Point lastpoint;
        private void polzovatel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void polzovatel_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            avtorization avt = new avtorization();
            this.Close();
            avt.Show();
        }
    }
}

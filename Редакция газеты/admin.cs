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

    public partial class admin : Form
    {
        BD bd = new BD();
        public admin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //добавление сотрудника
        private void button10_Click(object sender, EventArgs e)
        {
            
            dobavlenie_sotrydnikov sot = new dobavlenie_sotrydnikov();
            sot.Show();
        }
        // одобрение газеты
        private void button12_Click(object sender, EventArgs e)
        {
            
            dobavlenie_gaset gaseta = new dobavlenie_gaset();
            gaseta.Show();
        }
        // добавление издателей
        private void button7_Click(object sender, EventArgs e)
        {
            
            dobavlenie_izdateley izdately = new dobavlenie_izdateley();
            izdately.Show();
        }

        // таблицы 
        private void grid1()
        {
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT id_g as 'id газеты',tema_g as 'тема газеты',tip_g as 'тип газеты',
redactor as 'редактор',izdatel as 'издатель',cena as 'цена' FROM gasetu WHERE tip_g !='на расмотрении'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "gasetu");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void grid2()
        {
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT id_sp as 'id пользователя',dolgnost as 'должность', VIO as 'ФИО' ,email as 'E-mail',
pasvord as 'пароль',balance as 'баланс',n_pasport as '№ паспорта', id_r as '№ организации' FROM sotrydniki_and_p WHERE dolgnost !='-'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "sotrydniki_and_p");
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        private void grid3()
        {
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT id_iz as 'id издательства',name_izdatel as 'название издательства', adres_iz as 'адрес издательства' FROM izdateli", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "izdateli");
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
        }

        private void grid4()
        {
            SqlConnection con = new SqlConnection(bd.sqlCon);
            con.Open();
            SqlCommand com = new SqlCommand(@"SELECT id_sp as 'id пользователя',dolgnost as 'статус пользователя', VIO as 'ФИО' ,email as 'E-mail',
pasvord as 'пароль',balance as 'баланс',n_pasport as '№ паспорта' FROM sotrydniki_and_p WHERE dolgnost ='-' OR dolgnost= 'Забанен'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "sotrydniki_and_p");
            dataGridView4.DataSource = ds.Tables[0];
            con.Close();
        }



        private void admin_Load(object sender, EventArgs e)
        {
            grid1();
            grid2();
            grid3();
            grid4();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /////////////
            var a = $"update gasetu set tema_g='{textBox13.Text}',tip_g='{textBox14.Text}',redactor='{textBox12.Text}',izdatel='{textBox10.Text}',cena='{textBox11.Text}' WHERE id_g='{textBox15.Text}'";
            bd.queryEx(a);
            /////////////////////////
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = $"update izdateli set name_izdatel='{textBox3.Text}',adres_iz='{textBox2.Text}' WHERE id_iz='{textBox1.Text}'";
            bd.queryEx(a);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var a = $"update sotrydniki_and_p set dolgnost = '{textBox6.Text}',VIO = '{textBox5.Text}',email = '{textBox4.Text}',pasvord = '{textBox7.Text}',id_r= '{textBox17.Text}' WHERE id_sp='{textBox6.Text}'";
            bd.queryEx(a);
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[a];
                //////////////////
                textBox15.Text = row.Cells[0].Value.ToString();
                textBox13.Text = row.Cells[1].Value.ToString();
                textBox14.Text = row.Cells[2].Value.ToString();
                textBox12.Text = row.Cells[3].Value.ToString();
                textBox10.Text = row.Cells[4].Value.ToString();
                textBox11.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[a];
                //////////////////
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[1].Value.ToString();
                textBox5.Text = row.Cells[2].Value.ToString();
                textBox9.Text = row.Cells[3].Value.ToString();
                textBox7.Text = row.Cells[4].Value.ToString();
                textBox8.Text = row.Cells[5].Value.ToString();
                textBox16.Text = row.Cells[6].Value.ToString();
                textBox17.Text = row.Cells[7].Value.ToString();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[a];
                //////////////////
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            grid1();
            grid2();
            grid3();
            grid4();
        }


        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int a = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[a];
                //////////////////
                textBox25.Text = row.Cells[0].Value.ToString();
                textBox23.Text = row.Cells[1].Value.ToString();
                textBox24.Text = row.Cells[2].Value.ToString();
                textBox22.Text = row.Cells[3].Value.ToString();
                textBox20.Text = row.Cells[4].Value.ToString();
                textBox21.Text = row.Cells[5].Value.ToString();
                textBox19.Text = row.Cells[6].Value.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox25.Text == "")
            {
                MessageBox.Show("ввыберите данные");
                return;
            }
            else
            {
                var a = $"update sotrydniki_and_p set dolgnost = 'Забанен' WHERE id_sp='{textBox25.Text}'";
                bd.queryEx(a);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var a = $"update sotrydniki_and_p set dolgnost = '-' WHERE id_sp='{textBox25.Text}'";
            bd.queryEx(a);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var a = $"update sotrydniki_and_p set VIO = '{textBox24.Text}',email = '{textBox22.Text}'" +
                $",pasvord = '{textBox20.Text}' WHERE id_sp='{textBox25.Text}'";
            bd.queryEx(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("ввыберите данные");
                return;
            }
            else
            {
                var a = $"delete gasetu WHERE id_g='{textBox15.Text}'";
                bd.queryEx(a);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("ввыберите данные");
                return;
            }
            else
            {
                var a = $"delete sotrydniki_and_p WHERE id_sp='{textBox6.Text}'";
                bd.queryEx(a);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("ввыберите данные");
                return;
            }
            else
            {
                var a = $"delete izdateli WHERE id_iz='{textBox1.Text}'";
                bd.queryEx(a);
            }
        }
        Point lastpoint;
        private void admin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void admin_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            avtorization avt = new avtorization();
            this.Close();
            avt.Show();
        }

       
    }
}

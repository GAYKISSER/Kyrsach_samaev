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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point lastpoint;


        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            avtorization avt = new avtorization();
            avt.Show();
        }

        private void registration_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void registration_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("введите данные");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("введите данные");
                return;
            }
            else if (Check())
            {
                return;
            }
                BD bd = new BD();
                SqlConnection con = new SqlConnection(bd.sqlCon);
                con.Open();
                var loginUs = textBox1.Text;
                var paswordUs = textBox2.Text;
                int nul = 0;
                string a = ($"insert into sotrydniki_and_p (dolgnost,email, pasvord, balance) values('-','{loginUs}', '{paswordUs}', '{nul}')");
                SqlCommand command = new SqlCommand(a, con);


                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("вы успешно зарегистрировались", "Система");
                    this.Close();
                    avtorization Log = new avtorization();
                    Log.Show();
                }
                else
                {
                    MessageBox.Show("неверные данные, аккаунт не созданн", "Ошибка");
                }
                con.Close();
        }
        private Boolean Check()
        {
            BD bd = new BD();
            SqlConnection con = new SqlConnection(bd.sqlCon);
            var log = textBox1.Text;
            SqlDataAdapter ad = new SqlDataAdapter();
            DataTable tab = new DataTable();
            string a = $"select * from sotrydniki_and_p where email = '{log}'";
            SqlCommand command = new SqlCommand(a, con);
            ad.SelectCommand = command;
            ad.Fill(tab);
            if (tab.Rows.Count > 0)
            {
                MessageBox.Show("такой пользователь уже есть", "Ошибка");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

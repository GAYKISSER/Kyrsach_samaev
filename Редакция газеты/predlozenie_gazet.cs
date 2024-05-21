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
    public partial class predlozenie_gazet : Form
    {
        BD bd = new BD();
        public predlozenie_gazet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вам нужно заполнить только 2 поля, остальные данные (такие как издатель и редактор газеты) заполнятся автоматически.", "система");
        }
        //public int id = avtorization.id_polzov;
        //public int id;
        public int izdatel;
        private void button2_Click(object sender, EventArgs e)
        {
            //id = avtorization.id_z;
            //MessageBox.Show($"{izdatel}");
            try
            {
                SqlConnection con = new SqlConnection(bd.sqlCon);
                con.Open();
                SqlCommand com = new SqlCommand($"select id_r from sotrydniki_and_p where id_sp = '{avtorization.id_polzov}'", con);
                izdatel = ((int)com.ExecuteScalar());
                con.Close();


                var a = $"insert into gasetu(tema_g,tip_g,redactor,izdatel,cena) values ('{textBox1.Text}','на расмотрении','{avtorization.id_polzov}','{izdatel}','{textBox2.Text}')";
                bd.queryEx(a);
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Система");
            }
        }

        private void predlozenie_gazet_Load(object sender, EventArgs e)
        {
            //MessageBox.Show($"{id}");
            //id = avtorization.id_z;
        }
    }
}

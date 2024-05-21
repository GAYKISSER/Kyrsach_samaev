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
using static System.Net.Mime.MediaTypeNames;

namespace Редакция_ежедневной_газеты
{
    public partial class balance : Form
    {
        BD bd=new BD();
        public balance()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная функция полностью не реализована по понятным причинам", "Система");
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);


            if (x > 0)
            {
                SqlConnection con = new SqlConnection(bd.sqlCon);
                con.Open();
                SqlCommand com = new SqlCommand($"select balance from sotrydniki_and_p where id_sp = {avtorization.id_polzov}", con);
                int many = ((int)com.ExecuteScalar());

                var a = $"update sotrydniki_and_p set balance = '{many + x}' where id_sp= {avtorization.id_polzov}";
                bd.queryEx(a);
            }
            else
            {
                MessageBox.Show("Сумма должна быть положительна", "Система");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

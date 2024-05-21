using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Редакция_ежедневной_газеты
{
    public partial class dobavlenie_sotrydnikov : Form
    {
        BD bd = new BD();
        public dobavlenie_sotrydnikov()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox6.Text ==""||textBox5.Text==""|| textBox4.Text == ""|| textBox3.Text == ""|| textBox2.Text == ""|| textBox1.Text == "")
            {
                MessageBox.Show("введите данные");
            }
            else if (textBox5.Text != "администратор" || textBox5.Text != "редактор" || textBox5.Text != "-")
            {
                textBox5.Text = "-";
                var a = $"INSERT INTO sotrydniki_and_p(VIO,dolgnost,email,pasvord,n_pasport,id_r,balance) values" +
                    $" ('{textBox6.Text}','{textBox5.Text}','{textBox4.Text}','{textBox3.Text}','{textBox2.Text}','{textBox1.Text}','0')";
                bd.queryEx(a);
            }
            else
            {
                var a = $"INSERT INTO sotrydniki_and_p(VIO,dolgnost,email,pasvord,n_pasport,id_r,balance) values" +
                    $" ('{textBox6.Text}','{textBox5.Text}','{textBox4.Text}','{textBox3.Text}','{textBox2.Text}','{textBox1.Text}','0')";
                bd.queryEx(a);
                
            }
        }
    }
}

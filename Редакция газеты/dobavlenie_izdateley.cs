﻿using System;
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
    public partial class dobavlenie_izdateley : Form
    {
        BD bd = new BD();
        public dobavlenie_izdateley()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("введите данные");
            }
            else
            {
                var a = $" INSERT INTO izdateli(name_izdatel,adres_iz) values ('{textBox1.Text}','{textBox2.Text}')";
                bd.queryEx(a);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Редакция_ежедневной_газеты
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new avtorization());
        }
    }
    
    class BD
    {
        public string sqlCon = @"server=DESKTOP-P8DQL3B;Initial Catalog=gaseta;Integrated Security=true";

        public string StrCon()
        {
            return sqlCon;
        }
        public SqlDataAdapter queryEx(string query)
    {
        try
        {
            SqlConnection myCon = new SqlConnection(StrCon());
            myCon.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(query, myCon);
            SDA.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("действие выполнено", "система");
            return SDA;
        }
        catch
        {
            MessageBox.Show("ошибка", "ошибка");
            return null;
        }
    }
}
}






    

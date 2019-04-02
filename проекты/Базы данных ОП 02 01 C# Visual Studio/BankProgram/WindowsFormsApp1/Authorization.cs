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

namespace WindowsFormsApp1
{
    public partial class Authorization : Form
    {
        public string NameWorker;
        public string LoginWorker;
        public string PasswordWorker;
        public int IDWorker;
        int Series, Number;
        public Authorization()
        {
            InitializeComponent();
            Text = "Авторизация";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=BankLast;Integrated Security=True");
            con.Open();
            SqlDataAdapter Client = new SqlDataAdapter("Select Name from [Client] where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            SqlDataAdapter Worker = new SqlDataAdapter("Select Name from [Auto] where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataSet ds = new DataSet();
            Client.Fill(ds, "[Client]");
            Worker.Fill(ds, "[Auto]");
            if (Client.SelectCommand.ExecuteScalar() != null)
            {
                SqlDataAdapter Series_p = new SqlDataAdapter("Select Series_p from [Client] where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                SqlDataAdapter Number_p = new SqlDataAdapter("Select Number_p from [Client] where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                SqlDataAdapter ID_Client = new SqlDataAdapter("Select ID_Client from [Client] where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                Series = Convert.ToInt32(Series_p.SelectCommand.ExecuteScalar());
                Number = Convert.ToInt32(Number_p.SelectCommand.ExecuteScalar());
                int ID = Convert.ToInt32(ID_Client.SelectCommand.ExecuteScalar());
                Client cl = new Client(Series, Number, ID);
                ActiveForm.Hide();
                cl.Show();
            }
            else
            {
                if (Worker.SelectCommand.ExecuteScalar() != null)
                {
                    if (Convert.ToString(Worker.SelectCommand.ExecuteScalar()) == "Админ")
                    {
                        Admin adm = new Admin();
                        ActiveForm.Hide();
                        adm.Show();
                        NameWorker = "Админ";
                    }
                    else
                    if (Convert.ToString(Worker.SelectCommand.ExecuteScalar()) == "Кассир" || Convert.ToString(Worker.SelectCommand.ExecuteScalar()) == "Консультант" || Convert.ToString(Worker.SelectCommand.ExecuteScalar()) == "Банкир" || Convert.ToString(Worker.SelectCommand.ExecuteScalar()) == "Бухгалтер")
                    {
                        NameWorker = Convert.ToString(Worker.SelectCommand.ExecuteScalar());
                        LoginWorker = textBox1.Text;
                        PasswordWorker = textBox2.Text;
                        SqlDataAdapter ID_Worker = new SqlDataAdapter("Select ID_Worker from [Worker] where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                        Worker wor = new Worker(IDWorker, NameWorker);
                        ActiveForm.Hide();
                        IDWorker = Convert.ToInt32(ID_Worker.SelectCommand.ExecuteScalar());
                        wor.Show();
                    }
                    else
                    MessageBox.Show($"Вы являетесь работником нашего банка, но у вас нету прав входа");
                } else
                {
                    label3.Visible = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            this.Hide();
            reg.Show();
        }
    }
}

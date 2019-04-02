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

namespace WindowsFormsApp1
{
    public partial class Reg : Form
    {
        string connectString = "Data Source=localhost;Initial Catalog=BankLast;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        public Reg()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length;
            maskedTextBox2.SelectionStart = maskedTextBox2.Text.Length;
            maskedTextBox3.SelectionStart = maskedTextBox3.Text.Length;
            maskedTextBox4.SelectionStart = maskedTextBox4.Text.Length;
            maskedTextBox5.SelectionStart = maskedTextBox5.Text.Length;
            maskedTextBox7.SelectionStart = maskedTextBox7.Text.Length;
            maskedTextBox8.SelectionStart = maskedTextBox8.Text.Length;
            maskedTextBox9.SelectionStart = maskedTextBox9.Text.Length;
            maskedTextBox10.SelectionStart = maskedTextBox10.Text.Length;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label19.Visible = false;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.Text = maskedTextBox1.Text.Trim();
            maskedTextBox2.Text = maskedTextBox2.Text.Trim();
            maskedTextBox3.Text = maskedTextBox3.Text.Trim();
            maskedTextBox4.Text = maskedTextBox4.Text.Trim();
            maskedTextBox5.Text = maskedTextBox5.Text.Trim();
            maskedTextBox7.Text = maskedTextBox7.Text.Trim();
            maskedTextBox8.Text = maskedTextBox8.Text.Trim();
            maskedTextBox9.Text = maskedTextBox9.Text.Trim();
            maskedTextBox10.Text = maskedTextBox10.Text.Trim();
            if (maskedTextBox4.MaskCompleted == false)
            {
                maskedTextBox4.Text = "";
            }
            if (maskedTextBox5.MaskCompleted == false)
            {
                maskedTextBox5.Text = "";
            }
            if (maskedTextBox8.MaskCompleted == false)
            {
                maskedTextBox8.Text = "";
            }
        }

        private void maskedTextBox4_Leave(object sender, EventArgs e)
        {
            maskedTextBox5.Text = maskedTextBox5.Text.Trim();
            if (maskedTextBox4.Text != "" && maskedTextBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(connectString);
                con.Open();
                SqlDataAdapter Client = new SqlDataAdapter("Select Series_p from [Client] where Series_p='" + maskedTextBox4.Text + "' and Number_p='" + maskedTextBox5.Text + "'", con);
                SqlDataAdapter Worker = new SqlDataAdapter("Select Series_p from [Worker] where Series_p='" + maskedTextBox4.Text + "' and Number_p='" + maskedTextBox5.Text + "'", con);
                DataSet ds = new DataSet();
                Client.Fill(ds, "[Client]");
                Worker.Fill(ds, "[Worker]");
                if (Client.SelectCommand.ExecuteScalar() != null)
                {
                    label13.Visible = true;
                    maskedTextBox5.Text = "";
                    label12.Visible = true;
                    maskedTextBox4.Text = "";
                }
                if (Worker.SelectCommand.ExecuteScalar() != null)
                {
                    label13.Visible = true;
                    maskedTextBox5.Text = "";
                    label12.Visible = true;
                    maskedTextBox4.Text = "";
                }
                con.Close();
            }
        }

        private void maskedTextBox5_Leave(object sender, EventArgs e)
        {
            maskedTextBox5.Text = maskedTextBox5.Text.Trim();
            if (maskedTextBox4.Text != "" && maskedTextBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(connectString);
                con.Open();
                SqlDataAdapter Client = new SqlDataAdapter("Select Series_p from [Client] where Series_p='" + maskedTextBox4.Text + "' and Number_p='" + maskedTextBox5.Text + "'", con);
                SqlDataAdapter Worker = new SqlDataAdapter("Select Series_p from [Worker] where Series_p='" + maskedTextBox4.Text + "' and Number_p='" + maskedTextBox5.Text + "'", con);
                DataSet ds = new DataSet();
                Client.Fill(ds, "[Client]");
                Worker.Fill(ds, "[Worker]");
                if (Client.SelectCommand.ExecuteScalar() != null)
                {
                    label13.Visible = true;
                    maskedTextBox5.Text = "";
                    label12.Visible = true;
                    maskedTextBox4.Text = "";
                }
                if (Worker.SelectCommand.ExecuteScalar() != null)
                {
                    label13.Visible = true;
                    maskedTextBox5.Text = "";
                    label12.Visible = true;
                    maskedTextBox4.Text = "";
                }
                con.Close();
            }
        }

        private void maskedTextBox9_Leave(object sender, EventArgs e)
        {
            maskedTextBox9.Text = maskedTextBox9.Text.Trim();
            SqlConnection con = new SqlConnection(connectString);
            con.Open();
            SqlDataAdapter Client = new SqlDataAdapter("Select Login from [Client] where Login='" + maskedTextBox9.Text + "'", con);
            SqlDataAdapter Worker = new SqlDataAdapter("Select Login from [Worker] where Login='" + maskedTextBox9.Text + "'", con);
            DataSet ds = new DataSet();
            Client.Fill(ds, "[Client]");
            Worker.Fill(ds, "[Worker]");
            if (Client.SelectCommand.ExecuteScalar() != null)
            {
                label11.Visible = true;
                maskedTextBox9.Text = "";
            }
            if (Worker.SelectCommand.ExecuteScalar() != null)
            {
                label11.Visible = true;
                maskedTextBox9.Text = "";
            }
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (maskedTextBox9.Text.Length > 3 && maskedTextBox10.Text.Length > 3)
            {
                try
                {
                    string quertyTable = $"insert into Client (Surename, Name, Lastname, Series_p, Number_p, Birthday, " +
                            $"Registration, Phone_Number, Login, Password) " +
                            $"Values (N'{maskedTextBox1.Text.ToString()}', N'{maskedTextBox2.Text.ToString()}', N'{maskedTextBox3.Text.ToString()}' " +
                            $", N'{maskedTextBox4.Text.ToString()}', N'{maskedTextBox5.Text.ToString()}', N'{Convert.ToDateTime(maskedTextBox6.Text)}'" +
                            $", N'{maskedTextBox7.Text.ToString()}', N'{maskedTextBox8.Text.ToString()}', N'{maskedTextBox9.Text.ToString()}'" +
                            $", N'{maskedTextBox10.Text.ToString()}')";
                    using (SqlConnection connection = new SqlConnection(connectString))
                    {
                        connection.Open();
                        SqlCommand cp = new SqlCommand(quertyTable, connection);
                        cp.ExecuteNonQuery();
                    }
                    Authorization auto = new Authorization();
                    ActiveForm.Hide();
                    auto.Show();
                }
                catch
                {
                    MessageBox.Show("Некорректно заполнены поля");
                }
            }
            else MessageBox.Show("Некорректно заполнены поля");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void Reg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void maskedTextBox6_Leave(object sender, EventArgs e)
        {
            DateTime time;
            if (!DateTime.TryParse((sender as MaskedTextBox).Text, out time))
            {
                maskedTextBox6.Text = "";
                label19.Visible = true;
            }
        }
    }
}

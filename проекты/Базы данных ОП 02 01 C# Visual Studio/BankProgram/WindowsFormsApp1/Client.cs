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
    public partial class Client : Form
    {
        int ImageCheck;
        int OpenAdd = 0;
        byte[] Content;
        int ser, num , ID_Client20;
        string connectString = "Data Source=localhost;Initial Catalog=BankLast;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        public Client(int Series, int Number, int Index_Client)
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ser = Series;
            num = Number;
            ID_Client20 = Index_Client;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * from [Contract_View] where [Серия паспорта клиента] = '{ser}' and [Номер паспорта клиента] = '{num}'";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            OpenAdd = 0;
            panel2.Visible = false;
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (OpenAdd == 1)
            {
                SqlConnection sql = new SqlConnection(connectString);
                ds = new DataSet();
                sql.Open();
                SqlCommand com = new SqlCommand($"delete from Purpose_Client where ID_Purpose_Client= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                com.ExecuteScalar();
                sql.Close();
                button1.PerformClick();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                ImageCheck = 0;
                panel2.Visible = true;
                SqlConnection sql = new SqlConnection(connectString);
                sql.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * From Purpose", sql);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID_Purpose";
                sql.Close();
            }
            else
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                //MessageBox.Show(Convert.ToString(Convert.ToDateTime(dateTimePicker1.Text)));
                //try
                //{
                    string quertyTable = ".!.";
                    if (ImageCheck == 1)
                    {
                        quertyTable = $"insert into Purpose_Client (Client_ID, Purpose_ID, Sum, Date_Start, Date_End, Temporaty_Sum, Photo)" +
                                $"Values (N'{ID_Client20}', N'{Convert.ToInt32(comboBox1.SelectedValue)}', N'{maskedTextBox1.Text.ToString()}'" +
                                $", N'{sqlFormattedDate}', N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', N'{maskedTextBox2.Text.ToString()}' , @Image)";
                    }
                    if (ImageCheck == 0)
                    {
                        quertyTable = $"insert into Purpose_Client (Client_ID, Purpose_ID, Sum, Date_Start, Date_End, Temporaty_Sum)" +
                                $"Values (N'{ID_Client20}', N'{Convert.ToInt32(comboBox1.SelectedValue)}', N'{maskedTextBox1.Text.ToString()}'" +
                                $", N'{sqlFormattedDate}', N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', N'{maskedTextBox2.Text.ToString()}')";
                    }
                    using (SqlConnection connection = new SqlConnection(connectString))
                    {
                        connection.Open();
                        SqlCommand cp = new SqlCommand(quertyTable, connection);
                    if (ImageCheck == 1)
                        cp.Parameters.Add("@Image", SqlDbType.Image).Value = Content;
                        cp.ExecuteNonQuery();
                    }
                    button1.PerformClick();
                    panel2.Visible = false;
                    ImageCheck = 0;
                //}
                //catch
                //{
                //    MessageBox.Show("Некорректно заполнены поля");
                //}
            }
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.Text = maskedTextBox1.Text.Trim();
            maskedTextBox2.Text = maskedTextBox2.Text.Trim();
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
            {
                if (Convert.ToInt32(maskedTextBox2.Text) > Convert.ToInt32(maskedTextBox1.Text))
                {
                    maskedTextBox2.Text = "";
                    MessageBox.Show("Внесенная сумма не может быть больше полной суммы");
                }
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                Content = new byte[fs.Length];
                fs.Read(Content, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                ImageCheck = 1;
            }
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length;
            maskedTextBox2.SelectionStart = maskedTextBox2.Text.Length;
        }


        private void Client_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * from [Purpose_Client_View] where [Серия паспорта клиента] = '{ser}' and [Номер паспорта клиента] = '{num}'";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            OpenAdd = 1;
            panel2.Visible = false;
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }
    }
}

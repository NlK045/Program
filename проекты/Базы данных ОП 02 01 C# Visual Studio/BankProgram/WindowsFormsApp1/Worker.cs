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
    public partial class Worker : Form
    {
        int OpenAdd = 0;
        int IDWorker;
        string connectString = "Data Source=localhost;Initial Catalog=BankLast;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        int value;
        public bool Prov(int Position, int Worker)
        {
            bool proverka;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                SqlCommand com = new SqlCommand("select * from Proverka where ID_Worker = @ID_Worker and ID_Position=@ID_Position", con);
                com.Parameters.AddWithValue("@ID_Worker", Worker);
                com.Parameters.AddWithValue("@ID_Position", Position);
                con.Open();
                using (SqlDataReader dataReader = com.ExecuteReader())
                {
                    proverka = dataReader.Read();
                }
            }
            return proverka;
        }
        public void BlockedBox(int index)
        {
            if (index == 0)
            {
                label1.Visible = false;
                label2.Visible = false;
                comboBox1.Enabled = false;
                label3.Visible = false;
                maskedTextBox1.Visible = false;
                label4.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox2.Text = "";
                button9.Visible = false;
            }
            if (index == 1)
            {
                label15.Text = "Наименование*";
                label1.Text = "Номер запроса:";
                comboBox1.Enabled = true;
                label15.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                maskedTextBox1.Visible = false;
                label4.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox2.Text = "";
                button9.Visible = false;
            }
            if (index == 2)
            {
                label15.Text = "№ запроса*";
                label1.Text = "Номер договора:";
                label3.Visible = true;
                maskedTextBox1.Visible = true;
                comboBox1.Enabled = true;
                label15.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                maskedTextBox2.Visible = true;
                maskedTextBox1.Text = "5";
                button9.Visible = false;
            }
            if (index == 3)
            {
                label15.Text = "Наименование*";
                label1.Text = "Номер запроса:";
                comboBox1.Enabled = true;
                label15.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                maskedTextBox1.Visible = false;
                label4.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox2.Text = "";
                button9.Visible = false;
            }
            if (index == 4)
            {
                label1.Visible = false;
                label2.Visible = false;
                comboBox1.Enabled = false;
                label3.Visible = false;
                maskedTextBox1.Visible = false;
                label4.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox2.Text = "";
                button9.Visible = true;
            }

        }
        public Worker(int Index, string NameWorker)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            IDWorker = Index;
            //MessageBox.Show(NameWorker);
            if (NameWorker == "Кассир" || NameWorker == "Консультант")
            {
                button1.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }
            if (NameWorker == "Банкир")
            {
                button1.Enabled = true;
                button3.Enabled = false;
                button2.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = false;
            }
            if (NameWorker == "Бухгалтер")
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Contract_View ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            BlockedBox(0);
            OpenAdd = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Request_View  ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            BlockedBox(0);
            OpenAdd = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void Worker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            value = rnd.Next(100000, 999999);
            label2.Text = value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(connectString);
            sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * From Type_Request", sql);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Type_Request";
            sql.Close();
            OpenAdd = 1;
            BlockedBox(1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Position_Worker_View  ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            BlockedBox(4);
            OpenAdd = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenAdd = 2;
            BlockedBox(2);
            SqlConnection sql = new SqlConnection(connectString);
            sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * From Request", sql);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Number";
            comboBox1.ValueMember = "ID_Request";
            sql.Close();
            string query = "SELECT * from Client_View ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (OpenAdd == 1)
            {
                try
                {
                    string quertyTable = $"insert into Request (Type_Request_ID, Number, Date) Values (N'{Convert.ToInt32(comboBox1.SelectedValue)}', N'{Convert.ToInt32(label2.Text)}', N'{sqlFormattedDate}')";
                  
                    using (SqlConnection connection = new SqlConnection(connectString))
                    {
                        connection.Open();
                        SqlCommand cp = new SqlCommand(quertyTable, connection);
                        cp.ExecuteNonQuery();
                        connection.Close();
                    }
                    button1.PerformClick();
                }
                catch
                {
                    MessageBox.Show("Некорректно заполнены поля");
                }
            }
            if (OpenAdd == 2)
            {
                if (Convert.ToInt32(maskedTextBox2.Text) > 100000)
                {
                    try
                    {
                        string quertyTable = $"insert into Contract (Request_ID, Number, Client_ID, Worker_ID, Sum, Percent_c) Values (N'{Convert.ToInt32(comboBox1.SelectedValue)}', N'{Convert.ToInt32(label2.Text)}', N'{Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}', N'{IDWorker}', N'{maskedTextBox2.Text.ToString()}', N'{maskedTextBox1.Text.ToString()}')";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                            connection.Close();
                        }
                        button2.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
                else MessageBox.Show("Минимальная сумма контракта 100000");
            }
            if (OpenAdd == 3)
            {
                if (Prov(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)) != true)
                {
                    try
                    {
                        string quertyTable = $"insert into Position_Worker (Position_ID, Worker_ID) Values (N'{Convert.ToInt32(comboBox1.SelectedValue)}', N'{Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)}')";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                            connection.Close();
                        }
                        button7.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
                else MessageBox.Show("Данный работник уже нанят на данную должность");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenAdd = 3;
            BlockedBox(3);
            SqlConnection sql = new SqlConnection(connectString);
            sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * From Position", sql);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Position";
            sql.Close();
            string query = "SELECT * from Worker_View ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length;
            maskedTextBox2.SelectionStart = maskedTextBox2.Text.Length;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.Text = maskedTextBox1.Text.Trim();
            maskedTextBox2.Text = maskedTextBox2.Text.Trim();
            if (Convert.ToInt32(maskedTextBox1.Text) < 5)
            {
                maskedTextBox1.Text = "5";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connectString);
                ds = new DataSet();
                sql.Open();
                SqlCommand command = new SqlCommand($"delete from Position_Worker where ID_Position_Worker= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                command.ExecuteScalar();
                sql.Close();
                button7.PerformClick();
            }
            catch
            {
                MessageBox.Show("Удаление данного компанента невозможно");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[1, i].FormattedValue.ToString().Contains(textBox1.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[0, i];
                    if (i < dataGridView1.RowCount - 1)
                        i++;
                    else
                        i = 0;
                    return;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

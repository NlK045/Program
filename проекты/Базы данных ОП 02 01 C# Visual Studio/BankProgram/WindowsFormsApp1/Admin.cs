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
    public partial class Admin : Form
    {
        int OpenAdd = 0;
        string connectString = "Data Source=localhost;Initial Catalog=BankLast;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        public Admin()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
        }

        public void DeleteMaskedText()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            maskedTextBox6.Text = "";
            maskedTextBox7.Text = "";
            maskedTextBox8.Text = "";
            maskedTextBox9.Text = "";
            maskedTextBox10.Text = "";
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            maskedTextBox11.Text = "";
            maskedTextBox11.Visible = false;
            maskedTextBox12.Visible = false;
            button12.Enabled = true;
            button13.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            Pclient.Visible = false;
            OpenAdd = 1;
            DeleteMaskedText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            Pclient.Visible = false;
            OpenAdd = 2;
            DeleteMaskedText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Position_View ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            Pclient.Visible = false;
            OpenAdd = 3;
            DeleteMaskedText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Purpose_View  ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            Pclient.Visible = false;
            OpenAdd = 4;
            DeleteMaskedText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Type_Request_View  ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            Pclient.Visible = false;
            OpenAdd = 5;
            DeleteMaskedText();
        }

        private void button6_Click(object sender, EventArgs e)
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
            Pclient.Visible = false;
            OpenAdd = 6;
            DeleteMaskedText();
        }

        private void button11_Click(object sender, EventArgs e)
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
            Pclient.Visible = false;
            OpenAdd = 7;
            DeleteMaskedText();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Purpose_Client_View ORDER BY Код";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код"].ReadOnly = true;
            }
            Pclient.Visible = false;
            OpenAdd = 8;
            DeleteMaskedText();
        }

        private void button9_Click(object sender, EventArgs e)
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
            Pclient.Visible = false;
            OpenAdd = 9;
            DeleteMaskedText();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            switch (OpenAdd) {
                case 1:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Client where ID_Client= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button1.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Worker where ID_Worker= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button2.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 4:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Purpose where ID_Purpose= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button4.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 5:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Type_Request where ID_Type_Request= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button5.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Position where ID_Position= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button3.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 6:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Contract where ID_Contract= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button6.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 7:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Position_Worker where ID_Position_Worker= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button11.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 8:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Purpose_Client where ID_Purpose_Client= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button10.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
                case 9:
                    {
                        try
                        {
                            SqlConnection sql = new SqlConnection(connectString);
                            ds = new DataSet();
                            sql.Open();
                            SqlCommand command = new SqlCommand($"delete from Request where ID_Request= {dataGridView1.CurrentRow.Cells[0].Value}", sql);
                            command.ExecuteScalar();
                            sql.Close();
                            button9.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Удаление данного компанента невозможно");
                        }
                        break;
                    }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (OpenAdd == 1 && Pclient.Visible == false)
            {
                Pclient.Visible = true;
                button12.Enabled = false;
            }
            else
            {
                if (Pclient.Visible == true && OpenAdd != 2)
                {
                    //MessageBox.Show(Convert.ToString(Convert.ToDateTime(maskedTextBox6.Text)));
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
                            button1.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Некорректно заполнены поля");
                        }
                    }
                    else MessageBox.Show("Некорректно заполнены поля");
                }
            }
            if (OpenAdd == 2 && Pclient.Visible == false)
            {
                Pclient.Visible = true;
                button12.Enabled = false;
            }
            else
            {
                if (Pclient.Visible == true && OpenAdd != 1)
                {
                    if (maskedTextBox9.Text.Length > 3 && maskedTextBox10.Text.Length > 3)
                    {
                        try
                        {
                            string quertyTable = $"insert into Worker (Surename, Name, Lastname, Series_p, Number_p, Birthday, " +
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
                            button2.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Некорректно заполнены поля");
                        }
                    }
                    else MessageBox.Show("Некорректно заполнены поля");
                }
            }
            if (OpenAdd == 4 && maskedTextBox11.Visible == false)
            {
                label15.Visible = true;
                maskedTextBox11.Visible = true;
                button12.Enabled = false;
            }
            else
            {
                if (OpenAdd == 4 && maskedTextBox11.Visible == true && maskedTextBox11.Text.Length > 3)
                { 
                    try
                    {
                        string quertyTable = $"insert into Purpose (Name) Values (N'{maskedTextBox11.Text.ToString()}')";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                        }
                        button4.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
            }
            if (OpenAdd == 5 && maskedTextBox11.Visible == false)
            {
                label15.Visible = true;
                maskedTextBox11.Visible = true;
                button12.Enabled = false;
            }
            else
            {
                if (OpenAdd == 5 && maskedTextBox11.Visible == true && maskedTextBox11.Text.Length > 3)
                {
                    try
                    {
                        string quertyTable = $"insert into Type_Request (Name) Values (N'{maskedTextBox11.Text.ToString()}')";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                        }
                        button5.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
            }
            if (OpenAdd == 3 && maskedTextBox11.Visible == false)
            {
                label15.Visible = true;
                maskedTextBox11.Visible = true;
                label17.Visible = true;
                maskedTextBox12.Visible = true;
                button12.Enabled = false;
            }
            else
            {
                if (OpenAdd == 3 && maskedTextBox11.Visible == true && maskedTextBox11.Text.Length > 3 && Convert.ToDouble(maskedTextBox12.Text) > 20000)
                {
                    try
                    {
                        string quertyTable = $"insert into Position (Name, Salary) Values (N'{maskedTextBox11.Text.ToString()}', N'{maskedTextBox12.Text.ToString()}')";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                        }
                        button3.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                } else
                {
                    if (maskedTextBox12.Text.Length > 0)
                    if (Convert.ToDouble(maskedTextBox12.Text) < 20000)
                    {
                        label18.Visible = true;
                    }
                }
            }
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
            maskedTextBox11.SelectionStart = maskedTextBox11.Text.Length;
            maskedTextBox12.SelectionStart = maskedTextBox12.Text.Length;
            label11.Visible = false;
            label14.Visible = false;
            label18.Visible = false;
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

        private void maskedTextBox6_Validating(object sender, CancelEventArgs e)
        {
            DateTime time;
            if (!DateTime.TryParse((sender as MaskedTextBox).Text, out time))
            {
                maskedTextBox6.Text = "";
                label19.Visible = true;
            }
        }

        private void maskedTextBox9_Leave(object sender, EventArgs e)
        {
            if (button13.Enabled == true)
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
            if (button12.Enabled == true)
            {
                if (maskedTextBox9.Text != dataGridView1["Логин", dataGridView1.CurrentRow.Index].Value.ToString())
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
            }
        }

        private void maskedTextBox5_Click(object sender, EventArgs e)
        {
            maskedTextBox4.SelectionStart = maskedTextBox4.Text.Length;
            maskedTextBox5.SelectionStart = maskedTextBox5.Text.Length;
            label12.Visible = false;
            label13.Visible = false;
        }

        private void maskedTextBox4_Leave(object sender, EventArgs e)
        {
            maskedTextBox4.Text = maskedTextBox4.Text.Trim();
            if (button13.Enabled == true)
            {
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
                        label12.Visible = true;
                        maskedTextBox4.Text = "";
                        label13.Visible = true;
                        maskedTextBox5.Text = "";
                    }
                    if (Worker.SelectCommand.ExecuteScalar() != null)
                    {
                        label12.Visible = true;
                        maskedTextBox4.Text = "";
                        label13.Visible = true;
                        maskedTextBox5.Text = "";
                    }
                    con.Close();
                }
            }
            if (button12.Enabled == true)
            {
                if (maskedTextBox4.Text != "" && maskedTextBox5.Text != "")
                {
                    if (maskedTextBox4.Text != dataGridView1["Серия паспорта", dataGridView1.CurrentRow.Index].Value.ToString() && maskedTextBox5.Text != dataGridView1["Номер паспорта", dataGridView1.CurrentRow.Index].Value.ToString())
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
                            label12.Visible = true;
                            maskedTextBox4.Text = "";
                            label13.Visible = true;
                            maskedTextBox5.Text = "";
                        }
                        if (Worker.SelectCommand.ExecuteScalar() != null)
                        {
                            label12.Visible = true;
                            maskedTextBox4.Text = "";
                            label13.Visible = true;
                            maskedTextBox5.Text = "";
                        }
                        con.Close();
                    }
                }
            }
        }

        private void maskedTextBox11_Leave(object sender, EventArgs e)
        {
            if (maskedTextBox11.Text.Length > 4)
            {
                maskedTextBox11.Text = maskedTextBox11.Text.Trim();
                if (OpenAdd == 3)
                {
                    SqlConnection con = new SqlConnection(connectString);
                    con.Open();
                    SqlDataAdapter Purpose = new SqlDataAdapter("Select Name from [Position] where Name='" + maskedTextBox11.Text + "'", con);
                    DataSet ds = new DataSet();
                    Purpose.Fill(ds, "[Position]");
                    if (Purpose.SelectCommand.ExecuteScalar() != null)
                    {
                        label14.Visible = true;
                        maskedTextBox11.Text = "";
                    }
                    con.Close();
                }
                if (OpenAdd == 4)
                {
                    SqlConnection con = new SqlConnection(connectString);
                    con.Open();
                    SqlDataAdapter Purpose = new SqlDataAdapter("Select Name from [Purpose] where Name='" + maskedTextBox11.Text + "'", con);
                    DataSet ds = new DataSet();
                    Purpose.Fill(ds, "[Purpose]");
                    if (Purpose.SelectCommand.ExecuteScalar() != null)
                    {
                        label14.Visible = true;
                        maskedTextBox11.Text = "";
                    }
                    con.Close();
                }
                if (OpenAdd == 5)
                {
                    SqlConnection con = new SqlConnection(connectString);
                    con.Open();
                    SqlDataAdapter Purpose = new SqlDataAdapter("Select Name from [Type_Request] where Name='" + maskedTextBox11.Text + "'", con);
                    DataSet ds = new DataSet();
                    Purpose.Fill(ds, "[Type_Request]");
                    if (Purpose.SelectCommand.ExecuteScalar() != null)
                    {
                        label14.Visible = true;
                        maskedTextBox11.Text = "";
                    }
                    con.Close();
                }
            }
            else MessageBox.Show("Наименование должно содержать минимум 4 символа");
        }

        private void maskedTextBox12_Leave(object sender, EventArgs e)
        {
            if (maskedTextBox12.Text.Length > 0)
            {
                if (Convert.ToDouble(maskedTextBox12.Text) < 20000)
                {
                    maskedTextBox12.Text = "";
                    label18.Visible = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();

        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Authorization auto = new Authorization();
            ActiveForm.Hide();
            auto.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (OpenAdd == 1 && Pclient.Visible == false)
            {
                Pclient.Visible = true;
                button13.Enabled = false;
                maskedTextBox1.Text = dataGridView1["Фамилия", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox2.Text = dataGridView1["Имя", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox3.Text = dataGridView1["Отчество", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox4.Text = dataGridView1["Серия паспорта", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox5.Text = dataGridView1["Номер паспорта", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox6.Text = dataGridView1["День рождения", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox7.Text = dataGridView1["Адрес регистрации", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox8.Text = dataGridView1["Номер телефона", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox9.Text = dataGridView1["Логин", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox10.Text = dataGridView1["Пароль", dataGridView1.CurrentRow.Index].Value.ToString();
            }
            else
            {
                if (Pclient.Visible == true && OpenAdd != 2)
                {
                    //MessageBox.Show(Convert.ToString(Convert.ToDateTime(maskedTextBox6.Text)));
                    if (maskedTextBox9.Text.Length > 3 && maskedTextBox10.Text.Length > 3)
                    {
                        try
                        {
                            string quertyTable = "update Client set Surename='" + maskedTextBox1.Text.ToString() + "', Name= '" + maskedTextBox2.Text.ToString() + "', Lastname = '" + maskedTextBox3.Text.ToString() + "', Series_p = '" + maskedTextBox4.Text.ToString() + "', Number_p = '" + maskedTextBox5.Text.ToString() + "',  " +
                                    $"Registration = '" + maskedTextBox7.Text.ToString() + "', Phone_Number = '" + maskedTextBox8.Text.ToString() + "', Login = '" + maskedTextBox9.Text.ToString() + "', Password = '" + maskedTextBox10.Text.ToString() + "' where ID_Client = '"+ dataGridView1.CurrentRow.Cells[0].Value  + "'";
                            using (SqlConnection connection = new SqlConnection(connectString))
                            {
                                connection.Open();
                                SqlCommand cp = new SqlCommand(quertyTable, connection);
                                cp.ExecuteNonQuery();
                            }
                            button1.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("Некорректно заполнены поля");
                        }
                    }
                    else MessageBox.Show("Некорректно заполнены поля");
                }
            }
            if (OpenAdd == 2 && Pclient.Visible == false)
            {
                Pclient.Visible = true;
                button13.Enabled = false;
                maskedTextBox1.Text = dataGridView1["Фамилия", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox2.Text = dataGridView1["Имя", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox3.Text = dataGridView1["Отчество", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox4.Text = dataGridView1["Серия паспорта", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox5.Text = dataGridView1["Номер паспорта", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox6.Text = dataGridView1["Дата рождения", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox7.Text = dataGridView1["Адрес прописки", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox8.Text = dataGridView1["Номер телефона", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox9.Text = dataGridView1["Логин", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox10.Text = dataGridView1["Пароль", dataGridView1.CurrentRow.Index].Value.ToString();
            }
            else
            {
                if (Pclient.Visible == true && OpenAdd != 1)
                {
                    if (maskedTextBox9.Text.Length > 3 && maskedTextBox10.Text.Length > 3)
                    {
                        try
                        {
                            string quertyTable = "update Worker set Surename='" + maskedTextBox1.Text.ToString() + "', Name= '" + maskedTextBox2.Text.ToString() + "', Lastname = '" + maskedTextBox3.Text.ToString() + "', Series_p = '" + maskedTextBox4.Text.ToString() + "', Number_p = '" + maskedTextBox5.Text.ToString() + "',  " +
                                    $"Registration = '" + maskedTextBox7.Text.ToString() + "', Phone_Number = '" + maskedTextBox8.Text.ToString() + "', Login = '" + maskedTextBox9.Text.ToString() + "', Password = '" + maskedTextBox10.Text.ToString() + "' Birthday = N'"+ Convert.ToDateTime(maskedTextBox6.Text) + "' where ID_Worker = '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                            using (SqlConnection connection = new SqlConnection(connectString))
                            {
                                connection.Open();
                                SqlCommand cp = new SqlCommand(quertyTable, connection);
                                cp.ExecuteNonQuery();
                            }
                            button2.PerformClick();
                        }
                        catch
                        {
                            MessageBox.Show("некорректно заполнены поля");
                        }
                    }
                    else MessageBox.Show("Некорректно заполнены поля");
                }
            }
            if (OpenAdd == 4 && maskedTextBox11.Visible == false)
            {
                label15.Visible = true;
                maskedTextBox11.Visible = true;
                button13.Enabled = false;
                maskedTextBox11.Text = dataGridView1["Наименование", dataGridView1.CurrentRow.Index].Value.ToString();
            }
            else
            {
                if (OpenAdd == 4 && maskedTextBox11.Visible == true && maskedTextBox11.Text.Length > 3)
                {
                    try
                    {
                        string quertyTable = $"update Purpose set Name ='{maskedTextBox11.Text.ToString()}' where " +
                            $" ID_Purpose = '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                        }
                        button4.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
            }
            if (OpenAdd == 5 && maskedTextBox11.Visible == false)
            {
                label15.Visible = true;
                maskedTextBox11.Visible = true;
                button13.Enabled = false;
                maskedTextBox11.Text = dataGridView1["Наименование", dataGridView1.CurrentRow.Index].Value.ToString();
            }
            else
            {
                if (OpenAdd == 5 && maskedTextBox11.Visible == true && maskedTextBox11.Text.Length > 3)
                {
                    try
                    {
                        string quertyTable = $"update Type_Request set Name ='{maskedTextBox11.Text.ToString()}' where ID_Type_Request = '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                        }
                        button5.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
            }
            if (OpenAdd == 3 && maskedTextBox11.Visible == false)
            {
                label15.Visible = true;
                maskedTextBox11.Visible = true;
                label17.Visible = true;
                maskedTextBox12.Visible = true;
                button13.Enabled = false;
                maskedTextBox11.Text = dataGridView1["Наименование", dataGridView1.CurrentRow.Index].Value.ToString();
                maskedTextBox12.Text = dataGridView1["Оклад", dataGridView1.CurrentRow.Index].Value.ToString();
            }
            else
            {
                if (OpenAdd == 3 && maskedTextBox11.Visible == true && maskedTextBox11.Text.Length > 3 && Convert.ToDouble(maskedTextBox12.Text) > 20000)
                {
                    try
                    {
                        string quertyTable = $"update Position set Name ='{maskedTextBox11.Text.ToString()}', Salary = '{maskedTextBox12.Text.ToString()}' " +
                            $"where ID_Position = '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                        using (SqlConnection connection = new SqlConnection(connectString))
                        {
                            connection.Open();
                            SqlCommand cp = new SqlCommand(quertyTable, connection);
                            cp.ExecuteNonQuery();
                        }
                        button3.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно заполнены поля");
                    }
                }
                else
                {
                    if (maskedTextBox12.Text.Length > 0)
                        if (Convert.ToDouble(maskedTextBox12.Text) < 20000)
                        {
                            label18.Visible = true;
                        }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i =0; i < dataGridView1.RowCount; i++)
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
    }
}

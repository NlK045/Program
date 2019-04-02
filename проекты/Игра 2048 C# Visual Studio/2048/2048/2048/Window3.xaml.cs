using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        TextBox[,] txt = new TextBox[16, 16];
        int Cheting = 0;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        SolidColorBrush ColorButton(string good)
        {
            SolidColorBrush g = new SolidColorBrush(Colors.LightYellow);
            switch (good)
            {
                case "0":
                    g = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    return g;
                case "2":
                    g = new SolidColorBrush(Color.FromRgb(255, 5, 186));
                    return g;
                case "4":
                    g = new SolidColorBrush(Color.FromRgb(186, 5, 154));
                    return g;
                case "8":
                    g = new SolidColorBrush(Color.FromRgb(151, 6, 125));
                    return g;
                case "16":
                    g = new SolidColorBrush(Color.FromRgb(115, 4, 95));
                    return g;
                case "32":
                    g = new SolidColorBrush(Color.FromRgb(88, 3, 73));
                    return g;
                case "64":
                    g = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    return g;
                case "128":
                    g = new SolidColorBrush(Color.FromRgb(0, 191, 0));
                    return g;
                case "256":
                    g = new SolidColorBrush(Color.FromRgb(0, 165, 0));
                    return g;
                case "512":
                    g = new SolidColorBrush(Color.FromRgb(0, 127, 0));
                    return g;
                case "1024":
                    g = new SolidColorBrush(Color.FromRgb(206, 206, 0));
                    return g;
                case "2048":
                    g = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    return g;
            }
            return g;
        }
        int count = 0;
        public Window3(int gro)
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();
            Chet.Text = "Счет: " + Cheting;
            TimeGame.Text = "Время игры: " + y + ":0" + x;
            Dpanel.IsHitTestVisible = false;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<Nickname> user = new List<Nickname>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Nickname>));
            using (FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate))
            {
                user = (List<Nickname>)formatter.Deserialize(fs);
            }
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].Aktiv == "yep") Nickname.Text = user[i].Log;
            }
            //int[,] nums2 = new int[4, 4];
            int size = 0;
            count = gro;
            if (count == 4) size = 35;
            if (count == 6) size = 20;
            if (count == 8) size = 12;
            double w, h;
            w = 360 / count;
            h = 360 / count;
            SolidColorBrush g = new SolidColorBrush(Colors.Yellow);
            Random gg = new Random();
            int grom = gg.Next(16), gromik = 0;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    txt[i, j] = new TextBox
                    {
                        Background = new SolidColorBrush(Colors.Black),
                        BorderBrush = new SolidColorBrush(Colors.Yellow),
                        Name = "block" + i.ToString() + j.ToString(),
                        Text = "0",
                        Width = w,
                        Height = h,
                        //IsEnabled = false,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        TextAlignment = TextAlignment.Center,
                        Padding = new Thickness(0, size, 0, 0)
                    };
                    txt[i, j].IsReadOnly = true;
                    Wpanel.Children.Add(txt[i, j]);
                    if (gromik == grom)
                    {
                        txt[i, j].Text = "2";
                    }
                    gromik++;
                }
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    g = ColorButton(txt[i, j].Text.ToString());
                    txt[i, j].Background = g;
                }
            }
        }
        int x = 0, y = 0;
        private void timerTick(object sender, EventArgs e)
        {
            x++;
            if (x == 60)
            {
                y++;
                x = 0;
            }
            if (x < 10)
            {
                TimeGame.Text = "Время игры: " + y + ":0" + x;
            } else TimeGame.Text = "Время игры: " + y + ":" + x;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            string[,] Check = new string[16, 16];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Check[i, j] = txt[i, j].Text.ToString();
                }
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (Convert.ToInt32(txt[i, j].Text) != 0)
                    {
                        switch (e.Key)
                        {
                            case Key.Left:
                                {
                                    if (j == 0) continue;
                                    while (j != 0 && Convert.ToInt32(txt[i, j - 1].Text) == 0)
                                    {
                                        txt[i, j - 1].Text = txt[i, j].Text;
                                        txt[i, j].Text = "0";
                                        j--;
                                    }
                                    if (j != 0 && Convert.ToInt32(txt[i, j - 1].Text) == Convert.ToInt32(txt[i, j].Text))
                                    {
                                        txt[i, j - 1].Text = (Convert.ToInt32(txt[i, j - 1].Text) + Convert.ToInt32(txt[i, j].Text)).ToString();
                                        Cheting = Cheting + Convert.ToInt32(txt[i, j - 1].Text) + Convert.ToInt32(txt[i, j].Text);
                                        Chet.Text = "Счет: " + Cheting;
                                        txt[i, j].Text = "0";
                                    }
                                }
                                break;

                            case Key.Up:
                                {
                                    if (i == 0) continue;
                                    while (i != 0 && Convert.ToInt32(txt[i - 1, j].Text) == 0)
                                    {
                                        txt[i - 1, j].Text = txt[i, j].Text;
                                        txt[i, j].Text = "0";
                                        i--;
                                    }
                                    if (i != 0 && Convert.ToInt32(txt[i - 1, j].Text) == Convert.ToInt32(txt[i, j].Text))
                                    {
                                        txt[i - 1, j].Text = (Convert.ToInt32(txt[i - 1, j].Text) + Convert.ToInt32(txt[i, j].Text)).ToString();
                                        Cheting = Cheting + Convert.ToInt32(txt[i - 1, j].Text) + Convert.ToInt32(txt[i, j].Text);
                                        Chet.Text = "Счет: " + Cheting;
                                        txt[i, j].Text = "0";
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            for (int i = count - 1; i > -1; i--)
            {
                for (int j = count - 1; j > -1; j--)
                {
                    if (Convert.ToInt32(txt[i, j].Text) != 0)
                    {
                        switch (e.Key)
                        {
                            case Key.Right:
                                {
                                    if (j == count - 1) continue;
                                    while (j != count - 1 && Convert.ToInt32(txt[i, j + 1].Text) == 0)
                                    {
                                        txt[i, j + 1].Text = txt[i, j].Text;
                                        txt[i, j].Text = "0";
                                        j++;
                                    }
                                    if (j != count - 1 && Convert.ToInt32(txt[i, j + 1].Text) == Convert.ToInt32(txt[i, j].Text))
                                    {
                                        txt[i, j + 1].Text = (Convert.ToInt32(txt[i, j + 1].Text) + Convert.ToInt32(txt[i, j].Text)).ToString();
                                        Cheting = Cheting + Convert.ToInt32(txt[i, j + 1].Text) + Convert.ToInt32(txt[i, j].Text);
                                        Chet.Text = "Счет: " + Cheting;
                                        txt[i, j].Text = "0";
                                    }
                                }
                                break;

                            case Key.Down:
                                {
                                    if (i == count - 1) continue;
                                    while (i != count - 1 && Convert.ToInt32(txt[i + 1, j].Text) == 0)
                                    {
                                        txt[i + 1, j].Text = txt[i, j].Text;
                                        txt[i, j].Text = "0";
                                        i++;
                                    }
                                    if (i != count - 1 && Convert.ToInt32(txt[i + 1, j].Text) == Convert.ToInt32(txt[i, j].Text))
                                    {
                                        txt[i + 1, j].Text = (Convert.ToInt32(txt[i + 1, j].Text) + Convert.ToInt32(txt[i, j].Text)).ToString();
                                        Cheting = Cheting + Convert.ToInt32(txt[i + 1, j].Text) + Convert.ToInt32(txt[i, j].Text);
                                        Chet.Text = "Счет: " + Cheting;
                                        txt[i, j].Text = "0";
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            bool Change = true;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (Check[i, j] != txt[i, j].Text.ToString())
                    {
                        Change = false;
                    }
                }
            }
            if (Change == false)
            {
                int[] gg = new int[256];
                int ba = 0, ba1 = 0;
                Random baka = new Random();
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (txt[i, j].Text.ToString() == "0")
                        {
                            gg[ba] = 0;
                            ba++;
                        }
                    }
                }
                ba1 = baka.Next(ba + 1);
                for (int i = 0; i < ba; i++)
                {
                    if (i == ba1)
                    {
                        gg[i] = 2;
                    }
                }
                ba = 0;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (txt[i, j].Text.ToString() == "0")
                        {
                            txt[i, j].Text = gg[ba].ToString();
                            ba++;
                        }
                    }
                }
            }
            if (Change == true)
            {
                ChangeExit = true;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (txt[i, j].Text == "0")
                        {
                            ChangeExit = false;
                        }
                    }
                }
                if (ChangeExit == true)
                {
                    MessageBox.Show("Ваш счет: " + Cheting + "\n" + TimeGame.Text);
                    this.Close();
                }

            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (txt[i, j].Text == "2048")
                    {
                        MessageBox.Show("Поздравляем вы победили!\n" + "Ваш счет: " + Cheting + "\n" + TimeGame.Text);
                        this.Close();
                    }
                }
            }
            SolidColorBrush g = new SolidColorBrush(Colors.Yellow);
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    g = ColorButton(txt[i, j].Text.ToString());
                    txt[i, j].Background = g;
                }
            }
        }

        bool ChangeExit = true;
        private void Game_Closed(object sender, EventArgs e)
        {
            string coob = "";
            if (count == 4) coob = "4x4";
            if (count == 6) coob = "6x6";
            if (count == 8) coob = "8x8";

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (txt[i, j].Text == "2048")
                    {
                        timer.Stop();
                        Record baka = new Record();
                        List<Record> user = new List<Record>();
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));
                        using (FileStream fs = new FileStream("record.xml", FileMode.OpenOrCreate))
                        {
                            user = (List<Record>)formatter.Deserialize(fs);
                        }
                        user.Add(new Record(Nickname.Text, coob, Cheting.ToString(), TimeGame.Text));
                        using (FileStream fs = new FileStream("record.xml", FileMode.Create))
                        {
                            formatter.Serialize(fs, user);
                        }
                        count = 0;
                    }
                }
            }

            if (ChangeExit == true)
            {
                timer.Stop();
                Record baka = new Record();
                List<Record> user = new List<Record>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));
                using (FileStream fs = new FileStream("record.xml", FileMode.OpenOrCreate))
                {
                    user = (List<Record>)formatter.Deserialize(fs);
                }
                user.Add(new Record(Nickname.Text, coob, Cheting.ToString(), TimeGame.Text));
                using (FileStream fs = new FileStream("record.xml", FileMode.Create))
                {
                    formatter.Serialize(fs, user);
                }
                count = 0;
            }
            if (count == 4 || count == 6 || count == 8)
            {
                MessageBox.Show("Ваш счет: " + Cheting + "\n" + TimeGame.Text);
                timer.Stop();
                Record baka = new Record();
                List<Record> user = new List<Record>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));
                using (FileStream fs = new FileStream("record.xml", FileMode.OpenOrCreate))
                {
                    user = (List<Record>)formatter.Deserialize(fs);
                }
                user.Add(new Record(Nickname.Text, coob, Cheting.ToString(), TimeGame.Text));
                using (FileStream fs = new FileStream("record.xml", FileMode.Create))
                {
                    formatter.Serialize(fs, user);
                }
            }
            ChangeExit = false;
            count = 0;
            new MainWindow().Show();
            this.Close();
        }

        private void DockPanel_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}

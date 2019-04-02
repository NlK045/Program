using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = 400;
            MaxWidth = 360;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Nickname baka = new Nickname();
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
        }

        private void ChangeNickname_Click(object sender, RoutedEventArgs e)
        {
            new Window2().Show();
            this.Hide();
        }

        private void MainMenu_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GetRecords_Click(object sender, RoutedEventArgs e)
        {
            List<Record> user = new List<Record>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));
            using (FileStream fs = new FileStream("record.xml", FileMode.OpenOrCreate))
            {
                user = (List<Record>)formatter.Deserialize(fs);
            }
            StreamWriter file = new StreamWriter("Рекорды.txt");
            foreach (Record item in user)
            {
                file.WriteLine("Ник: " + item.Log + "  Счет: " + item.Exp + "  " + item.Time + "  Тип игры: " + item.Tip);
            }
            file.Close();
            Process.Start(@"Рекорды.txt");

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GameStart_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            this.Hide();
        }
    }
}

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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            MaxHeight = 400;
            MaxWidth = 360;
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
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();
        }

        private void DifficultyStart4x4_Click(object sender, RoutedEventArgs e)
        {
            new Window3(4).Show();
            this.Hide();
        }

        private void DifficultyStart6x6_Click(object sender, RoutedEventArgs e)
        {
            new Window3(6).Show();
            this.Hide();
        }

        private void DifficultyStart8x8_Click(object sender, RoutedEventArgs e)
        {
            new Window3(8).Show();
            this.Hide();
        }
    }
}

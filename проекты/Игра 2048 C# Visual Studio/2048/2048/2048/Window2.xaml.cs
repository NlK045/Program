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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            MaxHeight = 170;
            MaxWidth = 300;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            NewNickname.Text = NewNickname.Text.Trim();
            int prov = 0;
            Nickname baka = new Nickname();
            List<Nickname> user = new List<Nickname>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Nickname>));
            using (FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate))
            {
                user = (List<Nickname>)formatter.Deserialize(fs);
            }
            for (int i = 0; i < user.Count; i ++)
            {
                if (user[i].Aktiv == "yep") user[i].Aktiv = "nope";
                if (user[i].Log == NewNickname.Text)
                {
                    prov ++;
                    user[i].Aktiv = "yep";
                }
            }
            if (prov == 0)
            {
                user.Add(new Nickname(NewNickname.Text, "0", "yep"));
            }
            if (NewNickname.Text == "")
            {
                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].Log == "[Nickname]") user[i].Aktiv = "yep";
                }
            }
            using (FileStream fs = new FileStream("user.xml", FileMode.Create))
            {
                formatter.Serialize(fs, user);
            }
            new MainWindow().Show();
            this.Hide();
        }
    }
}

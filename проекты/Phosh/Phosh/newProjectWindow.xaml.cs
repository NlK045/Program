using System;
using System.Collections.Generic;
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

namespace Phosh
{
    /// <summary>
    /// Логика взаимодействия для newProjectWindow.xaml
    /// </summary>
    public partial class newProjectWindow : Window
    {
        
        /// <summary>
        /// Экземлпяр основной формы для изменения ее параметров 
        /// </summary>
        public MainWindow mw;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="mw">Экземпляр основной формы для ее непосредственной настройки</param>
        public newProjectWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }
        /// <summary>
        /// Функция обработки при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Closed(object sender, EventArgs e)
        {
            mw.IsEnabled = true;
        }

        /// <summary>
        /// Функция обработки при нажатии клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InputSize(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if ( (e.Key >= Key.D0) && (e.Key <= Key.D9))
            {
                e.Handled = false;
            } else
            {
                if (e.Key == Key.Tab)
                {
                    MessageBox.Show("123");
                }
            }

        }
        /// <summary>
        /// Функция обработки события нажатия кнопки, для создания нового документа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AccessButton_Click(object sender, RoutedEventArgs e)
        {
            string checkLine = ProjectName.Text.Trim();
            if (checkLine.Length != 0)
            {
                checkLine = WidthDoc.Text.Trim();
                if (checkLine.Length < 5 && Convert.ToInt32(checkLine) > 0 && Convert.ToInt32(checkLine) < 4000)
                {
                    checkLine = HeightDoc.Text.Trim();
                    if (checkLine.Length < 5 && Convert.ToInt32(checkLine) > 0 && Convert.ToInt32(checkLine) < 3000)
                    {
                        mw.MainCanvas.Children.Clear();
                        mw.MainCanvas.Strokes.Clear();
                        mw.Background = new SolidColorBrush((Color)ColorPicker.SelectedColor);
                        mw.BrushColor = (Color)ColorPicker.SelectedColor;
                        int width = Convert.ToInt32(WidthDoc.Text);
                        int height = Convert.ToInt32(HeightDoc.Text);
                        mw.setProjectProperties(width, height, (System.Windows.Media.Color)ColorPicker.SelectedColor);
                        mw.BrushColor = (Color)ColorPicker.SelectedColor;
                        Close();
                    } else MessageBox.Show("Задайте размеры изображения");
                } else
                {
                    MessageBox.Show("Задайте размеры изображения");
                }
            } else
            {
                MessageBox.Show("Отсутствует имя проекта!");
            }
        }
    }
}

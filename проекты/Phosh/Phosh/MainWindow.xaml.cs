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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Phosh
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Переменная определяющая текущее состояние окна
        /// </summary>
        private bool MaximizedWindow;
        /// <summary>
        /// Значение координаты мыши по Х оси
        /// </summary>
        public int xC;
        /// <summary>
        /// Значение координаты мыши по Y оси
        /// </summary>
        public int yC;

        /// <summary>
        /// Переменная для создания компонента заливки
        /// </summary>
        System.Windows.Shapes.Rectangle SelectRec;
        /// <summary>
        /// Переменная для создания компонента очистки
        /// </summary>
        System.Windows.Shapes.Rectangle CleanRec;

        /// <summary>
        /// Объект класса Point хранящий 
        /// стартовые координаты мыши при зажатой левой кнопкой мыши
        /// </summary>
        private System.Windows.Point startPoint;

        /// <summary>
        /// Текущий режим редактирование изображения
        /// </summary>
        private string mode;

        /// <summary>
        /// Текущий цвет кисти/карандаша
        /// </summary>
        public System.Windows.Media.Color BrushColor;
        /// <summary>
        /// Текущий цвет заднего фона
        /// </summary>
        public System.Windows.Media.Color _BackgroundColor;

        /// <summary>
        /// Диалог для основного цвета
        /// </summary>
        public ColorDialog BackColor = new ColorDialog();
        /// <summary>
        /// Диалог для дополнительного цвета
        /// </summary>
        public ColorDialog ForeColor = new ColorDialog();

        /// <summary>
        /// Конструктор MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MaximizedWindow = false;
            //wb = new WriteableBitmap( 
            //    (int)Width,
            //    (int)Height,
            //    32, 
            //    32, 
            //    PixelFormats.Bgr32,
            //    null
            //);
            //workImage.Source = wb;

            mode = "drawing";

            BackColor.Color = System.Drawing.Color.Black;
            ForeColor.Color = System.Drawing.Color.White;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            BrushColor = Colors.Black;
            _BackgroundColor = Colors.White;
            Cnv.Width = DrawField.Width;
            Cnv.Height = DrawField.Height;

            //MainCanvas.Width = DrawField.Width;
            //MainCanvas.Height = DrawField.Height;
            //Cnv.Background = System.Windows.Media.Brushes.White;

            //Cnv.Width = DrawField.ActualWidth;
            //Cnv.Height = DrawField.ActualHeight;

            Cnv.Background = new SolidColorBrush(_BackgroundColor);

            MainCanvas.Background = System.Windows.Media.Brushes.Transparent;
            MainCanvas.DefaultDrawingAttributes.Width = 7;
            MainCanvas.DefaultDrawingAttributes.Height = 7;


            //WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Функция устанавливающая параметры нового файла
        /// </summary>
        /// <param name="width">Ширина файла</param>
        /// <param name="height">Высота файла</param>
        /// <param name="color">Фоновый цвет файла</param>
        public void setProjectProperties(int width, int height, System.Windows.Media.Color color)
        {
            Bitmap bitmap = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear((System.Drawing.Color.FromArgb(255, color.R, color.G, color.B)));
            }
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = bitmapImage;
                Cnv.Background = myBrush;
            }
            _BackgroundColor = color;
            Cnv.Background = new SolidColorBrush(_BackgroundColor);
        }
       
        /// <summary>
        /// Функция перетаскивания окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Функция минимизации онка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeBox(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// Функция максимизации окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaximizeBox(object sender, RoutedEventArgs e)
        {
            if (!MaximizedWindow)
            {
                WindowState = WindowState.Maximized;
                MaximizedWindow = true;
            }
            else
            {
                WindowState = WindowState.Normal;
                MaximizedWindow = false;
            }

        }
        /// <summary>
        /// Функция закрытия окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWin(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Функция загрузки нового изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            Uri uri = new Uri(openFile.FileName);
            var image_source = new BitmapImage(uri);
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = image_source;
            Cnv.Background = imageBrush;

        }

        /// <summary>
        /// Функция вызывающая окно для создания нового файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewDoc(object sender, RoutedEventArgs e)
        {
            newProjectWindow projectWindow = new newProjectWindow(this);
            IsEnabled = false;
            projectWindow.Show();
        }

        /// <summary>
        /// Функция изменения основного цвета кисти и т.д.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackGround_click(object sender, RoutedEventArgs e)
        {
            BackColor.ShowDialog();
            //System.Windows.MessageBox.Show(BackColor.Color.ToString());
            back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BackColor.Color.A, BackColor.Color.R, BackColor.Color.G, BackColor.Color.B));
            BrushColor = System.Windows.Media.Color.FromArgb(BackColor.Color.A, BackColor.Color.R, BackColor.Color.G, BackColor.Color.B);
            MainCanvas.DefaultDrawingAttributes.Color = BrushColor;
            //InkCanvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromArgb(BackColor.Color.A, BackColor.Color.R, BackColor.Color.G, BackColor.Color.B);
        }
        /// <summary>
        /// Функция изменения дополнительного цвета кисти и т.д.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fore_Click(object sender, RoutedEventArgs e)
        {
            ForeColor.ShowDialog();
            fore.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(ForeColor.Color.A, ForeColor.Color.R, ForeColor.Color.G, ForeColor.Color.B));

        }

        /// <summary>
        /// Замена основного текущего цвета на текущий дополнительный
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush temp = (SolidColorBrush)fore.Background;
            System.Drawing.Color temp_dialog = new System.Drawing.Color();
            temp_dialog = BackColor.Color;
            BackColor.Color = ForeColor.Color;
            ForeColor.Color = temp_dialog;
            fore.Background = back.Background;
            back.Background = temp;
            BrushColor = System.Windows.Media.Color.FromArgb(BackColor.Color.A, BackColor.Color.R, BackColor.Color.G, BackColor.Color.B);
            MainCanvas.DefaultDrawingAttributes.Color = BrushColor;
            //InkCanvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromArgb(BackColor.Color.A, BackColor.Color.R, BackColor.Color.G, BackColor.Color.B);
        }

        /// <summary>
        /// Функция обработки режимов рисования при зажатой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cnv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (mode)
            { 
                case "scale":
                    {
                        break;
                    }
            
                case "mirror":
                    {
                        if (MainCanvas.Children.IndexOf(SelectRec) != -1) { MainCanvas.Children.Remove(SelectRec); }
                        startPoint = e.GetPosition(Cnv);

                        SelectRec = new System.Windows.Shapes.Rectangle();

                        SelectRec.Stroke = System.Windows.Media.Brushes.Black;
                        SelectRec.StrokeThickness = 2;

                        InkCanvas.SetLeft(SelectRec, startPoint.X);
                        InkCanvas.SetTop(SelectRec, startPoint.Y);

                        //Cnv.Children.Add(SelectRec);
                        MainCanvas.Children.Add(CleanRec);

                        break;
                    }
                case "clean":
                    {
                        
                        startPoint = e.GetPosition(Cnv);

                        CleanRec = new System.Windows.Shapes.Rectangle();

                        CleanRec.Stroke = System.Windows.Media.Brushes.Black;
                        CleanRec.StrokeThickness = 2;

                        InkCanvas.SetLeft(CleanRec, startPoint.X);
                        InkCanvas.SetTop(CleanRec, startPoint.Y);

                        //Cnv.Children.Add(CleanRec);
                        MainCanvas.Children.Add(CleanRec);
                        break;
                    }
                case "bucket":
                    {

                        startPoint = e.GetPosition(Cnv);

                        CleanRec = new System.Windows.Shapes.Rectangle();

                        CleanRec.Stroke = System.Windows.Media.Brushes.Black;
                        CleanRec.StrokeThickness = 2;

                        InkCanvas.SetLeft(CleanRec, startPoint.X);
                        InkCanvas.SetTop(CleanRec, startPoint.Y);

                        //Cnv.Children.Add(CleanRec);
                        MainCanvas.Children.Add(CleanRec);
                        break;
                    }
            }
        }
        /// <summary>
        /// Функция обработки режимов рисования при передвижении мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cnv_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var pos = e.GetPosition(Cnv);
            var x = Math.Min(pos.X, startPoint.X);
            var y = Math.Min(pos.Y, startPoint.Y);
            TitleName.Content = x + "|" + y;

            var w = Math.Max(pos.X, startPoint.X) - x;
            var h = Math.Max(pos.Y, startPoint.Y) - y;
            switch (mode)
            {
                case "mirror":
                    {
                        if (e.LeftButton == MouseButtonState.Released || SelectRec == null) return;
                       

                        if (pos.X >= Cnv.Width - 1 || pos.X <= 2 || pos.Y <= 2 || pos.Y >= Cnv.Height - 1)
                        {
                            MainCanvas.Children.Remove(SelectRec);
                            SelectRec = null;
                        } else
                        {
                            

                            SelectRec.Width = w;
                            SelectRec.Height = h;

                            InkCanvas.SetLeft(SelectRec, x);
                            InkCanvas.SetTop(SelectRec, y);
                        }
                        //Cnv.Children.Add(SelectRec);
                        break;
                    }
                case "drawing":
                    { 
                        break;
                    }
                case "clean":
                    {
                        if (e.LeftButton == MouseButtonState.Released || CleanRec == null) return;


                        if (pos.X >= Cnv.Width - 1 || pos.X <= 2 || pos.Y <= 2 || pos.Y >= Cnv.Height - 1)
                        {
                            MainCanvas.Children.Remove(CleanRec);
                            CleanRec = null;
                        }
                        else
                        {


                            CleanRec.Width = w;
                            CleanRec.Height = h;

                            InkCanvas.SetLeft(CleanRec, x);
                            InkCanvas.SetTop(CleanRec, y);
                        }
                        break;
                    }
                case "bucket":
                    {
                        if (e.LeftButton == MouseButtonState.Released || CleanRec == null) return;


                        if (pos.X >= Cnv.Width - 1 || pos.X <= 2 || pos.Y <= 2 || pos.Y >= Cnv.Height - 1)
                        {
                            MainCanvas.Children.Remove(CleanRec);
                            CleanRec = null;
                        }
                        else
                        {


                            CleanRec.Width = w;
                            CleanRec.Height = h;

                            InkCanvas.SetLeft(CleanRec, x);
                            InkCanvas.SetTop(CleanRec, y);
                        }
                        break;
                    }
                case "pipetka":
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
                        {

                        }
                        break;

                    }
            }
        }
        /// <summary>
        /// Функция обработки режимов рисования при отжатой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cnv_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (mode)
            {
                case "scale":
                    {
                        //MainCanvasScaleTransform.CenterX = (int)e.GetPosition(MainCanvas).X;
                        //MainCanvasScaleTransform.CenterY = (int)e.GetPosition(MainCanvas).Y;
                        //if (MainCanvasScaleTransform.ScaleX < 2)
                        //{
                        //    MainCanvasScaleTransform.ScaleX += 0.1;
                        //    MainCanvasScaleTransform.ScaleY += 0.1;
                        //}
                        break;
                    }
                case "mirror":
                    {
                        MainCanvas.Children.Remove(SelectRec);
                        SelectRec = null;
                        break;
                    }
                case "clean":
                    {
                        System.Windows.Point point = e.GetPosition(Cnv);
                        if (point.X <= 0 || point.Y <= 0 || point.X >= Cnv.Width || point.Y >= Cnv.Height) { MainCanvas.Children.Remove(CleanRec); }
                        else
                        {
                            CleanRec.StrokeThickness = 0;
                            CleanRec.Fill = new SolidColorBrush(_BackgroundColor);
                        }
                        CleanRec = null;
                        break;
                    }
                case "bucket":
                    {
                        CleanRec.StrokeThickness = 0;
                        CleanRec.Fill = new SolidColorBrush(BrushColor);
                        CleanRec = null;
                        break;
                    }
            }
        }

        /// <summary>
        /// Функция обработки размеров компонентов при изменении размеров формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TitleName.Content = MainCanvas.ActualWidth + " " + MainCanvas.ActualHeight;
            MainCanvas.Width = DrawField.ActualWidth;
            MainCanvas.Height = DrawField.ActualHeight;
            MainCanvas.MaxWidth = DrawField.ActualWidth;
            //MainCanvas.Width = DrawField.ActualWidth;
            //MainCanvas.Height = this.ActualHeight;
            MainCanvas.MaxHeight = DrawField.ActualHeight;

        }

        /// <summary>
        /// Переход в режим очистки изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "clean")
            {
                mode = "drawing";
                MainCanvas.IsEnabled = true;
            }
            else
            {
                mode = "clean";
                MainCanvas.IsEnabled = false;
            }
        }
        /// <summary>
        /// Переход в режим рисования карандашом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PencilButton_Click(object sender, RoutedEventArgs e)
        {
            mode = "pencil";
            MainCanvas.IsEnabled = true;
            MainCanvas.DefaultDrawingAttributes.Width = 2;
            MainCanvas.DefaultDrawingAttributes.Height = 2;
            MainCanvas.DefaultDrawingAttributes.Color = BrushColor;
        }
        /// <summary>
        /// Переход в режим рисования кистью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrushButton_Click(object sender, RoutedEventArgs e)
        {
            mode = "brush";
            MainCanvas.IsEnabled = true;
            MainCanvas.DefaultDrawingAttributes.Width = 7;
            MainCanvas.DefaultDrawingAttributes.Height = 7;
            MainCanvas.DefaultDrawingAttributes.Color = BrushColor;

        }
        /// <summary>
        /// Переход в режим ластика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            mode = "Erase";
            MainCanvas.IsEnabled = true;
            MainCanvas.DefaultDrawingAttributes.Color = _BackgroundColor;
            MainCanvas.DefaultDrawingAttributes.Width = 10;
            MainCanvas.DefaultDrawingAttributes.Height = 10;
        }
        /// <summary>
        /// Переход в режим заливки выделенной области
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BucketButton_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "bucket")
            {
                mode = "drawing";
                MainCanvas.IsEnabled = true;
            }
            else
            {
                mode = "bucket";
                
                MainCanvas.IsEnabled = false;
            }
        }

    }
}

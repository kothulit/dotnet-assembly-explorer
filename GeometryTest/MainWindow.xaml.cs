using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace GeometryTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //Создать объект класса Ellipse по нажатию кнопки мыши
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 50;
            ellipse.Height = 50;
            ellipse.Fill = Brushes.Red;
            ellipse.Stroke = Brushes.Black;
            ellipse.StrokeThickness = 1;
            ellipse.Margin = new Thickness(e.GetPosition(this).X, e.GetPosition(this).Y, 0, 0);
            canvas.Children.Add(ellipse);
        }

        //Масштабировать геометрию в canvas колесиком мыши без ограничения
        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                canvas.LayoutTransform = new ScaleTransform(canvas.LayoutTransform.Value.M11 + 0.1, canvas.LayoutTransform.Value.M22 + 0.1);
            }
            else
            {
                canvas.LayoutTransform = new ScaleTransform(canvas.LayoutTransform.Value.M11 - 0.1, canvas.LayoutTransform.Value.M22 - 0.1);
            }
        }

        //получить текущие параметры LayoutTransform из canvas
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            ScaleTransform scale = canvas.LayoutTransform as ScaleTransform;
            if (scale != null)
            {
                scale.ScaleX = scale.ScaleY;
            }
        }
    }
}

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

        //draw cyrcle by mouse click
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse el = new Ellipse();
            el.Width = 50;
            el.Height = 50;
            el.Fill = Brushes.Red;
            el.Stroke = Brushes.Black;
            el.StrokeThickness = 2;
            el.Margin = new Thickness(e.GetPosition(canvas).X - 25, e.GetPosition(canvas).Y - 25, 0, 0);
            canvas.Children.Add(el);
        }

        //change canvas scale in the mouse point
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                canvas.LayoutTransform = new ScaleTransform(canvas.LayoutTransform.Value.M11 * 1.1, canvas.LayoutTransform.Value.M22 * 1.1, e.GetPosition(canvas).X, e.GetPosition(canvas).Y);
            }
            else
            {
                canvas.LayoutTransform = new ScaleTransform(canvas.LayoutTransform.Value.M11 / 1.1, canvas.LayoutTransform.Value.M22 / 1.1, e.GetPosition(canvas).X, e.GetPosition(canvas).Y);
            }
        }

        //change cyrcle position by mouse move
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Ellipse el = e.Source as Ellipse;
                if (el != null)
                {
                    el.Margin = new Thickness(e.GetPosition(canvas).X - 25, e.GetPosition(canvas).Y - 25, 0, 0);
                }
            }
        }
    }
}

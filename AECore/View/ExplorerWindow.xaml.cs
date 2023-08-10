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

namespace AECore.View
{

    /// <summary>
    /// Interaction logic for ExplorerWindow.xaml
    /// </summary>
    public partial class ExplorerWindow : Window
    {
        //adding visual panel for graphics in this window
        DrawingVisual ghostVisual = null;

        public ExplorerWindow()
        {
            InitializeComponent();
            //adding visual panel for graphics in this window
            ghostVisual = new DrawingVisual();
        }

        //drwaing graphics in this window
        private void OnPaint(object sender, RoutedEventArgs e)
        {
            //adding visual panel for graphics in this window
            DrawingContext dc = ghostVisual.RenderOpen();
            dc.DrawRectangle(Brushes.Red, null, new Rect(0, 0, 100, 100));
            dc.Close();
            //adding visual panel for graphics in this window
            //((Grid)sender).Children.Add(ghostVisual);
            AddVisualChild(ghostVisual);
            AddLogicalChild(ghostVisual);
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index != 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return ghostVisual;
        }

    }
}

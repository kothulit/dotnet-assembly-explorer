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

namespace AECore
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        DrawingVisual ghostVisual = null;
        public TestWindow()
        {
            //InitializeComponent();
            Title = "Test";
            Width = 300;
            Height = 350;
            ghostVisual = new DrawingVisual();
            using(DrawingContext drawingContext = ghostVisual.RenderOpen())
            {
                //Body
                drawingContext.DrawGeometry(Brushes.Blue, null, Geometry.Parse(
                    @"M 240,250
                    C 200,375 200,250 175,200
                    C 100,400 100,250 100,200
                    C 0,350 0,250 30,130
                    C 75,0 100,0 150,0
                    C 200,0 250,0 250,150 Z"));
                //Left eye
                drawingContext.DrawEllipse(Brushes.Black, new Pen(Brushes.White, 10), new Point(95, 95), 15, 15);
                //Right eye
                drawingContext.DrawEllipse(Brushes.Black, new Pen(Brushes.White, 10), new Point(170, 105), 15, 15);
                //Mouth
                Pen p = new Pen(Brushes.Black, 10);
                p.StartLineCap = PenLineCap.Round;
                p.EndLineCap = PenLineCap.Round;

                drawingContext.DrawLine(p, new Point(75, 160), new Point(175, 150));
            }

            AddVisualChild(ghostVisual);
            AddLogicalChild(ghostVisual);
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index !=0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return ghostVisual;
        }

        //

    }
}

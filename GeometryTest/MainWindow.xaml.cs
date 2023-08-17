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
        
        private DrawingVisual CreatDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
            drawingContext.DrawRectangle(Brushes.LightBlue, (Pen)null, rect);
            drawingContext.Close();
            return drawingVisual;
        }

        public void RetrieveDrawing(Visual v)
        {
            DrawingGroup drawingGroup = VisualTreeHelper.GetDrawing(v);
            EnumDrawingGroup(drawingGroup);
        }

        public void EnumDrawingGroup(DrawingGroup drawingGroup)
        {
            DrawingCollection dc = drawingGroup.Children;
            foreach (Drawing drawing in dc)
            {
                if (drawing is DrawingGroup group)
                {
                    EnumDrawingGroup(group);
                }
                else if (drawing is GeometryDrawing geometryDrawing)
                {
                    Geometry geometry1 = geometryDrawing.Geometry;
                    if (geometry1 is RectangleGeometry rectangle)
                    {
                        Rect rect = rectangle.Rect;
                        Console.WriteLine("Rectangle: {0},{1},{2},{3}", rect.Left, rect.Top, rect.Right, rect.Bottom);
                    }
                }
                else if (drawing is ImageDrawing imageDrawing)
                {

                }
                else if (drawing is GlyphRunDrawing glyphRunDrawing)
                {
                }
                else if (drawing is VideoDrawing videoDrawing)
                {
                }
            }

        }
    }
}

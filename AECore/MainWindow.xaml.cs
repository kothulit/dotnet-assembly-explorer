using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using AECore.View;
using AECore.ViewModel;
using Autodesk.Revit.DB;

namespace AECore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TestWindow testWin = new TestWindow();
            //testWin.Show();

            ExplorerWindow explorerWin = new ExplorerWindow();
            explorerWin.Show();

            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = new AECore.ViewModel.ElementViewModel();  
        }

        //adding visual panel for graphics in this window
        DrawingVisual ghostVisual = null;
    }
}

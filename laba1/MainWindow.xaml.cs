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
using laba1.Model;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainLogic appLogic;
        Init init;
        public MainWindow()
        {
            InitializeComponent();

            init = new Init();

            appLogic = ((App)App.Current).logic;
            appLogic.Loaded += AppLogic_Loaded;

            Loaded += MainWindow_Loaded;
        }

        private void AppLogic_Loaded(object sender, EventArgs e)
        {
            init.DoInit(this);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            appLogic.onLoaded();
        }

        private void RotationRx_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
        }

        private void RotationRy_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
        }

        private void RotationRz_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
        }

        private void Dilation_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
        }

        private void Translation_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
        }

        
        private void ReflectionXY_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
        }

        private void ReflectionYZ_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
        }

        private void ReflectionXZ_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
        }

        private void BuildG2BySubstitution_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;


        }


        private void BuildG2BySpline_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;

        }

        private void Clear2dField_Click(object sender, RoutedEventArgs e)
        {
           MainLogic logic = ((App)App.Current).logic;
           logic.clear2dPaintDesk();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
            logic.testTriang(contex.N);
        }

        private void Triangulate_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            logic.Triangulate();
        }
        
        private void SavePoints_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            logic.SavePoints();
        }

        private void doSteps(object sender, RoutedEventArgs e)
        {
            MainLogic logic = ((App)App.Current).logic;
            Variables contex = (Variables)DataContext;
            logic.DoSteps(contex.Steps);
        }
    }
}

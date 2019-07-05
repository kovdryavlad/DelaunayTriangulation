using laba1.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainLogic logic = new MainLogic();

        /*
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            logic.Loaded += Logic_Loaded;
            logic.onLoaded();
        }
        */
        /*
        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);
            
            logic.Loaded += Logic_Loaded;
            logic.onLoaded();
        }

        private void Logic_Loaded(object sender, EventArgs e)
        {
            CanvasPainter painter = new CanvasPainter(((MainWindow)MainWindow).FigureCanvas);
            painter.DrawPoint(new SimpleMatrix.Vector(new[] { 10.0, 10 }));
        }
        */
    }
}

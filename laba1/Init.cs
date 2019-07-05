using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba1.Model;

namespace laba1
{
    class Init
    {
        
        public void DoInit(MainWindow mainWindow)
        {
            MainLogic logic = ((App)App.Current).logic;
            logic.SetPaintDesk(mainWindow.PaintDesk);

            mainWindow.DataContext = new Variables();

            //logic.testTriang();

            logic.drawFigure();
        }

        
    }
}

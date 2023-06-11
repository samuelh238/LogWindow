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

namespace LogWindowTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.lgLogger.DisplayLogMessage("INFO", LogWindow.LogWindow.LogLevels.INFO);
            this.lgLogger.DisplayLogMessage("DEBUG", LogWindow.LogWindow.LogLevels.DEBUG);
            this.lgLogger.DisplayLogMessage("WARNING", LogWindow.LogWindow.LogLevels.WARNING);
            this.lgLogger.DisplayLogMessage("SUCCESS", LogWindow.LogWindow.LogLevels.SUCCESS);
            this.lgLogger.DisplayLogMessage("ERROR", LogWindow.LogWindow.LogLevels.ERROR);

            this.lgLogger.DisplayLogMessage("", LogWindow.LogWindow.LogLevels.INFO);

            for (int i = 0; i < 10000; i++)
            {
                this.lgLogger.DisplayLogMessage("This is a Test", LogWindow.LogWindow.LogLevels.DEBUG);
                this.lgLogger.DisplayLogMessage("It Worked!", LogWindow.LogWindow.LogLevels.SUCCESS);
            }
            

        }
    }
}

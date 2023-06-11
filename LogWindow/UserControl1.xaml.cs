using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace LogWindow
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LogWindow : UserControl
    {
        public enum LogLevels
        {
            INFO, //White
            DEBUG, //White
            WARNING, //Yellow
            SUCCESS, //Green
            ERROR //Red
        }

        private Paragraph _paragraph = new Paragraph();

        public LogWindow()
        {
            InitializeComponent();
            this.rtbLogWindow.Document.Blocks.Add(_paragraph);
        }
        
        public void DisplayLogMessage(string logmessage, LogLevels colorCode)
        {
            var brushColor = GetBrushColorFromLogLevel(colorCode);
            string? debugTag = Enum.GetName(typeof(LogLevels), colorCode);
            var run = new Run() { Text = $">{debugTag}: {logmessage}\r\n", Foreground = brushColor };
            _paragraph.Inlines.Add(run);
        }

        private Brush GetBrushColorFromLogLevel(LogLevels colorCode)
        {
            switch (colorCode)
            {
                case LogLevels.INFO:
                    return Brushes.White;
                case LogLevels.DEBUG:
                    return Brushes.White;
                case LogLevels.WARNING:
                    return Brushes.Yellow;
                case LogLevels.SUCCESS:
                    return Brushes.Green;
                case LogLevels.ERROR:
                    return Brushes.Red;
                default:
                    return Brushes.White;
            }
        }
    }
}
using System;
using System.IO;
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
            this.rtbLogWindow.ScrollToEnd();
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
        private void miSaveLogToFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            //dialog.FileName = $""; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt|Log Files (.log)|*.log"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result != true)
                return;
            // Save document
            string filename = dialog.FileName;
            this.DisplayLogMessage($"Saving Log to File: {filename}", LogLevels.INFO);
            try
            {
                StreamWriter outputFile = new StreamWriter(filename);
                outputFile.Write(StringFromRichTextBox());
                outputFile.Close();
                this.DisplayLogMessage($"Log successfully saved to File: {filename}", LogLevels.SUCCESS);
            }
            catch (Exception ex)
            {
                this.DisplayLogMessage($"Failed to write log to File: {filename}", LogLevels.ERROR);
                this.DisplayLogMessage($"{ex.Message}", LogLevels.ERROR);
                this.DisplayLogMessage($"{ex.StackTrace}", LogLevels.DEBUG);
            }
        }

        private string StringFromRichTextBox()
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                this.rtbLogWindow.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                this.rtbLogWindow.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }
    }
}
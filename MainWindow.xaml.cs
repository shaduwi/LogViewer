using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace LogViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread thread = new Thread(StartLog);
            thread.Start();
        }
        public void StartLog()
        {
            int i = 0;
            while (true)
            {
                i++;
                LogAdd("test " + i.ToString());
                Thread.Sleep(100);
            }
        }
        public void LogAdd(string LogStr)
        {
            this.Dispatcher.Invoke(() =>
            {
                int selStart = OutputBlock.SelectionStart;
                int selLeng = OutputBlock.SelectionLength;
                OutputBlock.Text += DateTime.Now.ToString("HH:mm:ss") + " - " + LogStr + "\n";
                OutputBlock.SelectionStart = selStart;
                OutputBlock.SelectionLength = selLeng;
                if (Autoscroll.IsChecked == true)
                {
                    Scroller.ScrollToEnd();
                }
            });
        }
    }
}

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartProgress(object sender, RoutedEventArgs e)
        {
            var thread1 = new Thread(() =>
            {
                thread1.Priority = ThreadPriority.Highest;
                for (int i = 0; i < 100; i++)
                {
                    Dispatcher.Invoke(() =>
                    {
                        
                    });
                }
            });
        }
    }
}
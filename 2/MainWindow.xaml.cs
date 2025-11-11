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

        private void Start(object sender, RoutedEventArgs e)
        {
            var thread1 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    Dispatcher.Invoke(() => firstTh.Text = $"Поток с высшим приоритетом: {i}");
                }
            });

            var thread2 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    Dispatcher.Invoke(() => secondTh.Text = $"Поток с средним приоритетом: {i}");
                }
            });

            var thread3 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    Dispatcher.Invoke(() => thirdTh.Text = $"Поток с низким приоритетом: {i}");
                }
            });

            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Normal;
            thread3.Priority = ThreadPriority.Lowest;

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread waitThread = new Thread(() =>
            {
                thread1.Join();
                thread2.Join();
                thread3.Join();

                Dispatcher.Invoke(() =>
                {
                    firstTh.Text = "Поток с высшим приоритетом: завершен";
                    secondTh.Text = "Поток с средним приоритетом: завершен";
                    thirdTh.Text = "Поток с низким приоритетом: завершен";
                });
            });

            waitThread.Start();
        }
    }
}
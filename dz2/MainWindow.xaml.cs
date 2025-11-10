using System.Windows;

namespace dz2
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



        private void ProgressBad(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(() =>
            {

                for (int i = 0; i < 100; i+=10) {
                    Thread.Sleep(500);
                    Dispatcher.Invoke(() =>
                    {
                        Progres1.Value = i;
                    });
                }

            });

        }
        private void HighestThread(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(() =>
            {
                for (int i = 100; i > 0; i -= 10)
                {
                    Thread.Sleep(500);
                    Dispatcher.Invoke(() =>
                    {
                        Progres1.Value = i;
                    });
                }

            });

            thread.Priority = ThreadPriority.Highest;

            if(thread.Priority == ThreadPriority.Highest)
            {
                Dispatcher.Invoke(() =>
                {
                    OutputHighestThread.Text = $"Поток уровня {thread.Priority}";
                });
            }

            thread.Start();
        }

        private void UpdateUI(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    TextOut.Text = "text";
                }
                catch (InvalidOperationException err)
                {
                    Dispatcher.Invoke(() =>
                    {
                        ExOut.Text = err.Message;
                    });
                }
                catch (Exception err)
                {
                    Dispatcher.Invoke(() =>
                    {
                        ExOut.Text = "Unknown Exception";
                    });
                }
            });
            thread.Start();
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ShowAlbum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timerUpdate = new DispatcherTimer();
        private TaskScheduler ui = TaskScheduler.FromCurrentSynchronizationContext();

        public MainWindow()
        {
            InitializeComponent();
            timerUpdate.Tick += new System.EventHandler(dispatchertimer_Tick);
            timerUpdate.Interval = new TimeSpan(0, 0, 10);
            timerUpdate.Start();
        }

        private void dispatchertimer_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void ShowData()
        {
            var _ViewModelAlbumList = new Album
            {
                Title = KafkaService.Receiver.GetAlbumName(),
            };

            lblAlbumName.Content = _ViewModelAlbumList.Title;
        }

        private void Update()
        {
            ShowData();
        }
    }
}
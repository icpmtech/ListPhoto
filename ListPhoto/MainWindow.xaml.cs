using System.Windows;

namespace ListPhoto
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

        public void ShowHide()
        {
            if (About.Visibility == Visibility.Hidden)
            {
                About.Visibility = Visibility.Visible;
                Album.Visibility = Visibility.Hidden;
            }
            else
            {
                About.Visibility = Visibility.Hidden;
                Album.Visibility = Visibility.Visible;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowHide();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
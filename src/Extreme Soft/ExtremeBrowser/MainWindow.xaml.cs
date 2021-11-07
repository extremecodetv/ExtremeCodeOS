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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uri uri = new Uri("https://yandex.com");

        public MainWindow()
        {
            InitializeComponent();

            UrlBox.Text = uri.Host;
            Wind.Source = uri;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (UrlBox.Text[UrlBox.Text.Length - 3] == '.' ||
                UrlBox.Text[UrlBox.Text.Length - 4] == '.')
            {      
                uri = new Uri($"https://{UrlBox.Text}");
            }
            else
            {
                uri = new Uri($"https://yandex.ru/search/?text={UrlBox.Text.Replace(' ', '+')}&lr=976");
            }

            Wind.Navigate(uri);

            window.Title = uri.Host;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Wind.Refresh();
        }
    }
}

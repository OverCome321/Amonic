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

namespace Laba_Biznes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TourPage());
            Manager.MainFarme = MainFrame;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFarme.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
                BackButton.Visibility = Visibility.Visible;
            else
                BackButton.Visibility = Visibility.Hidden;
        }
    }
}





//private static HotelDBEntities _context = new HotelDBEntities();

//public static HotelDBEntities GetContext()
//{
//    if (_context == null)
//        _context = new HotelDBEntities();

//    return _context;
//}

//public string ActualText
//{
//    get { return ((bool)Is_Actual) ? "Актуален" : "Завершен"; }
//}



//public string ActualText
//{
//    get { return ((bool)Is_Actual) ? "Активен" : "Завершен"; }
//}
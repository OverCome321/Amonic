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
    /// Логика взаимодействия для TourPage.xaml
    /// </summary>
    public partial class TourPage : Page
    {
        public TourPage()
        {
            InitializeComponent();

            var allTypes = HotelDBEntities.GetContext().Type_Hotel.ToList();
            allTypes.Insert(0, new Type_Hotel
            {
                Name_type = "Все типы"
            });
            TypeCB.ItemsSource = allTypes;

            ActualCheck.IsChecked = true;
            TypeCB.SelectedIndex = 0;

            var currentTours = HotelDBEntities.GetContext().Tour.ToList();
            TourView.ItemsSource = currentTours;

            UpdateTours();
        }

        private  void UpdateTours()
        {
            var currentTours = HotelDBEntities.GetContext().Tour.ToList();

            var currentType = TypeCB.SelectedItem as Type_Hotel;

            if (TypeCB.SelectedIndex > 0)
                //currentTours = currentTours.Where(p => p.Type_Hotel.Name_type.Contains(Convert.ToString(currentType))).ToList();
                currentTours = currentTours.Where(p => p.Type_Hotel.Name_type.Contains((TypeCB.SelectedItem as Type_Hotel).Name_type)).ToList();


            currentTours = currentTours.Where(p => p.Name_tour.ToLower().Contains(SearchTB.Text.ToLower())).ToList();

            if (ActualCheck.IsChecked.Value)
                currentTours = currentTours.Where(p => (bool)p.Is_Actual).ToList();

            TourView.ItemsSource = currentTours.OrderBy(p => p.Ticket_count).ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ActualCheck_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}

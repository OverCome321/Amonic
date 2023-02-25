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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currenthotel = new Hotel();
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                _currenthotel = selectedHotel;

            DataContext = _currenthotel;
            CountryComboBox.ItemsSource = HotelDBEntities.GetContext().Country.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currenthotel.Name_hotel))
                err.AppendLine("Укажите название отеля");

            if (_currenthotel.Count_of_stars < 1 || _currenthotel.Count_of_stars > 5)
                err.AppendLine("Неверное количество звезд");

            if (_currenthotel.Country == null)
                err.AppendLine("Выберите страну");

            if(err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }

            if (_currenthotel.id == 0)
                HotelDBEntities.GetContext().Hotel.Add(_currenthotel);

            try
            {
                HotelDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

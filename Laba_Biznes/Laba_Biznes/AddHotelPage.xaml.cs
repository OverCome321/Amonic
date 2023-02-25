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
    /// Логика взаимодействия для AddHotelPage.xaml
    /// </summary>
    public partial class AddHotelPage : Page
    {
        public AddHotelPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Hotel h = new Hotel();

            h.Name_hotel = NameTextB.Text;

            if (Convert.ToInt32(CountOfStarsTextB.Text) <= 5 && Convert.ToInt32(CountOfStarsTextB.Text) >= 0)
                h.Count_of_stars = Convert.ToInt32(CountOfStarsTextB.Text);
            else
                MessageBox.Show("Неверное количество звезд!", "Ошибка!");

            AppData.db.Hotel.Add(h);
            AppData.db.SaveChanges();

            Manager.MainFarme.GoBack();
        }
    }
}

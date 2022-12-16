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
using DifPlaksin.Components;

namespace DifPlaksin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            if(login.Length == 0 && password.Length == 0)
            {
                MessageBox.Show("Пусто");
            }
            else
            {
                Navigation.user = DBConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if(Navigation.user == null)
                {
                    MessageBox.Show("Не существует");
                }
                else
                {
                    Navigation.isAuth = true;
                    Navigation.NextPage(new Nav("Products", new ProductPage()));
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Registration", new RegistrPage()));
        }
    }
}

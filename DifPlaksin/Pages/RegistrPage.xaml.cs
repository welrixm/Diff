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
    /// Логика взаимодействия для RegistrPage.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        public RegistrPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            if(login.Length > 0 && password.Length > 0)
            {
                DBConnect.db.User.Add(new User
                {
                    Login = login,
                    Password = password
                });
                DBConnect.db.SaveChanges();
                MessageBox.Show("Вы зарегистрированы");
            }
            else
            {
                MessageBox.Show("Пусто");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "";
            PasswordTb.Text = "";

        }
    }
}

using BusinessLogicLayer;
using EntitiesLayer.Entities;
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

namespace PresentationLayer1
{
    
    public partial class MainWindow : Window
    {
        private readonly UserService _userService;

        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
           
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string password = txtMainWindowPassword.Password;
            string username = txtMainWindowUsername.Text;

            if (_userService.LoginUser(username, password))
            {
                UserSession.Username = username;
                Menu menu = new Menu(username);
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed, invalid or unregistered account!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

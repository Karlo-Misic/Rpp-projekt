using BusinessLogicLayer;
using System;
using System.Windows;

namespace PresentationLayer1
{
   
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            var username = txtRegistrationUsername.Text;
            var email = txtEmail.Text;
            var password = txtRegistrationPassword.Password;

            var userService = new UserService();
            var isRegistered = userService.RegisterUser(username, email, password);

            if (isRegistered)
            {
                ClearFields();
                ShowMainWindow();
            }
            if (username == "" || email == "" || password == "")
            {
                MessageBox.Show("Registration failed. Fill all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(!isRegistered)
            {
                MessageBox.Show("Registration failed. User with this email or username already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Clear();
                txtRegistrationUsername.Clear();
            }
        }

        private void ShowMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();

        }

        private void ClearFields()
        {
            txtRegistrationUsername.Clear();
            txtEmail.Clear();
            txtRegistrationPassword.Clear();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ShowMainWindow();
        }
    }
}

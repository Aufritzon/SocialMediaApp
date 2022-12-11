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
using System.Windows.Shapes;



namespace SocialMediaApp
{
    public partial class UserRegistrationWindow : Window
    {
        public UserRegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            string username = usernameTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordBox.Password;
            string confirmPassword = confirmPasswordBox.Password;
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
      
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter an email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter a first name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter a last name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            if (!XmlFileManager.AddUser(user))
            {
                MessageBox.Show($"The username {username} is already taken!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();

        }

    }


}


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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly List<User> users;
        public LoginWindow()
        {
            InitializeComponent();
            this.users = XmlFileManager.GetUsers();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User? user = XmlFileManager.GetUser(username, password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Open personalized window for user
            UserWindow personalizedWindow = new UserWindow(user);
            personalizedWindow.Show();
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            UserRegistrationWindow registerWindow = new UserRegistrationWindow();
            registerWindow.Show();
            Close();
        }
    }
}

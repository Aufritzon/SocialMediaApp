using Microsoft.Win32;
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
    /// Interaction logic for PersonalizedWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        User user;
        public UserWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            this.user = user;
            QuoteTextBlock.Text = user.Quote;
            Title = $"{user.FirstName} {user.LastName}'s page";
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void UploadProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            // Use a FileOpenDialog to allow the user to select a profile picture
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                ProfilePicture.Source = new BitmapImage(new Uri(filePath));
                // TODO: Store the selected image in a member variable or save it to a file
            }
        }

        private void ChangeQuote_Click(object sender, RoutedEventArgs e)
        {
            XmlFileManager.UpdateUserQuote(QuoteTextBox.Text, user);
            QuoteTextBlock.Text = QuoteTextBox.Text;


        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("Knappen " + btn.Content + " har ingen funktion än!");
        }


        private void FriendsButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("Knappen " + btn.Content + " har ingen funktion än!");
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("Knappen " + btn.Content + " har ingen funktion än!");
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("Knappen " + btn.Content + " har ingen funktion än!");
        }

    }
}

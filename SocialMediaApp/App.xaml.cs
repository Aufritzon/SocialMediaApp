using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;

namespace SocialMediaApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Set the main window of the application

            XmlFileManager.InitXmlFile();
            XmlFileManager.AddUser(new User() { Username = "Bragd" });
            List<User> users = XmlFileManager.GetUsers();
            users.ForEach(user => MessageBox.Show(user.Username,"hffd0",MessageBoxButton.OK));
            MainWindow = new LoginWindow();
            MainWindow.Show();
            
        }
    }
}

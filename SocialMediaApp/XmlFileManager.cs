using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

namespace SocialMediaApp
{

    
    public static class XmlFileManager
    {
        private static string xmlFilePath = "users.xml";

        public static void InitXmlFile()
        {
            if (!System.IO.File.Exists(xmlFilePath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlFilePath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("users");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        public static bool AddUser(User user) {

            List<User> users = GetUsers();


            if (users.Exists(u => u.Username.Equals(user.Username)))
            {
                return false;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlElement userElement = doc.CreateElement("User");
            userElement.SetAttribute("username", user.Username);
            userElement.SetAttribute("password", user.Password);
            userElement.SetAttribute("email", user.Email);
            userElement.SetAttribute("firstname", user.FirstName);
            userElement.SetAttribute("lastname", user.LastName);


            doc.DocumentElement.AppendChild(userElement);
            doc.Save(xmlFilePath);
            
            return true;
        }

        public static void DeleteUser(string username)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNodeList users = doc.GetElementsByTagName("User");

            foreach (XmlNode user in users)
            {
                if (user.Attributes["username"].Value == username)
                {
                    user.ParentNode.RemoveChild(user);
                    break;
                }
            }

            doc.Save(xmlFilePath);
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNodeList userElements = doc.SelectNodes("users/User");

            foreach (XmlNode userElement in userElements)
            {
                XmlAttribute emailAttribute = userElement.Attributes["email"];
                XmlAttribute firstNameAttribute = userElement.Attributes["firstname"];
                XmlNode lastNameAttrubute = userElement.Attributes["lastname"];
                XmlNode passwordAttribute = userElement.Attributes["password"];
                XmlNode usernameAttribute = userElement.Attributes["username"];


                User user = new User
                {
                    Email = emailAttribute.Value,
                    FirstName = firstNameAttribute.Value,
                    LastName = lastNameAttrubute.Value,
                    Username = usernameAttribute.Value,
                    Password =passwordAttribute.Value
                };

                users.Add(user);
            }


            return users;
        }

        public static User? GetUser(string username)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode userElement = doc.SelectSingleNode($"users/user[username='{username}']");

            if (userElement != null)
            {
                XmlNode emailElement = userElement.SelectSingleNode("email");
                XmlNode firstNameElement = userElement.SelectSingleNode("firstname");
                XmlNode lastNameElement = userElement.SelectSingleNode("lastname");
                XmlNode passwordElement = userElement.SelectSingleNode("password");

                User user = new User
                {
                    Email = emailElement.InnerText,
                    FirstName = firstNameElement.InnerText,
                    LastName = lastNameElement.InnerText,
                    Password = passwordElement.InnerText
                };

                return user;
            }

            return null;
        }

    }
}

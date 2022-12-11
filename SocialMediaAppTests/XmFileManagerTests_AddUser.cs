using SocialMediaApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;


namespace SocialMediaAppTests
{
    public class XmFileManagerTests_AddUser
    {
        
        public User testUser = new User() { Username = "rav"};



        [Fact]
        public void AddUser_When_User_Not_Exists()
        {
            XmlFileManager.InitXmlFile();

            // Arrange
            bool expectedResult = true;

            // Act
            bool result = XmlFileManager.AddUser(testUser);


            // Assert
            Assert.Equal(expectedResult, result);

            XmlFileManager.DeleteUser(testUser.Username);


        }

        [Fact]
        public void AddUser_When_User_Exists()
        {
            XmlFileManager.InitXmlFile();

            // Arrange
            bool expectedResult = false;

            // Act
            XmlFileManager.AddUser(testUser);
            bool result = XmlFileManager.AddUser(testUser);

            // Assert
            Assert.Equal(expectedResult, result);

            XmlFileManager.DeleteUser(testUser.Username);

        }
    }
}

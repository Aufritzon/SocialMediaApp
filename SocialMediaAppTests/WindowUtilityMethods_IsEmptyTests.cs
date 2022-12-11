using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp;


namespace SocialMediaAppTests
{

    public class WindowUtilityMethods_IsEmptyTests
    {

        [Fact]
        public void TestEmptyString()
        {

            bool result = WindowUtilityMethods.IsEmpty("", "field");

            Assert.True(result);

        }

        [Fact]
        public void TestWhitespaceString()
        {
            bool result = WindowUtilityMethods.IsEmpty("   ", "field");

            Assert.True(result);
        }

        [Fact]
        public void TestNonEmptyString()
        {
            bool result = WindowUtilityMethods.IsEmpty("abc", "field");

            Assert.False(result);
        }

        
    }
}

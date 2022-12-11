using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialMediaApp
{
    [XmlRoot]
    public class User
    {
        [XmlAttribute]
        public string Email { get; set; }
        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlAttribute]
        public string Username { get; set; }

        [XmlAttribute]
        public string Password { get; set; }


        public void Serialize(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using(TextWriter writer = new StreamWriter(@filename)) 
            {
                serializer.Serialize(writer,this);
            }
        }

    }
}

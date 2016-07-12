using Newtonsoft.Json;
using PioneerET.Models;
using PioneerET.Models.Pioneer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PioneerET.LDAP
{
    public class Authenticate
    {
        public static User ValidateUser(string username, string password)
        {
            return new User();
        }

        public static User mockValidateUser(string username, string password, string path)
        {
            string json = null;
           using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }
            var jsonObject = JsonConvert.DeserializeObject<MockObjectLDAPUser>(json);
            PersonDetail personDetail = jsonObject.ldapusers.SelectMany(x => x.GetPersonResponse.PersonDetails.Where(e => e.EmailAddress == username)).FirstOrDefault();
            if(personDetail != null)
            {
                return new User()
                {
                    EmailAddress = personDetail.EmailAddress,
                    FirstName = personDetail.FirstName,
                    LastName = personDetail.LastName,
                    Role = "Dispatcher" // will change as per LDAP group
                };
            }
            else
            {
                return null;
            }
            
        }
    }
}

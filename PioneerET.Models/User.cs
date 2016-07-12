using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerET.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PioneerUserIdentifier { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public bool isManager { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string ManagerPioneerUserIdentifier { get; set; }
        public string ManagerEmailAddress { get; set; }
    }
}

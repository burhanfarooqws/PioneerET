using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerET.Models.Pioneer
{
    public class LDAPUser
    {
        public GetPersonResponse GetPersonResponse { get; set; }
    }
    public class MemberOfGroups
    {
        public List<string> GroupName { get; set; }
    }
    public class PersonDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PioneerUserIdentifier { get; set; }
        public string EmailAddress { get; set; }
        public MemberOfGroups MemberOfGroups { get; set; }
        public bool isManager { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string ManagerPioneerUserIdentifier { get; set; }
        public string ManagerEmailAddress { get; set; }
    }
    public class GetPersonResponse
    {
        public List<PersonDetail> PersonDetails { get; set; }
    }   
    public class MockObjectLDAPUser
    {
        public List<LDAPUser> ldapusers { get; set; }
    }
}

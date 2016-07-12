using PioneerET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerET.Data
{
    public class Users
    {
        public List<User> Get()
        {
            string cs = ConfigurationManager.ConnectionStrings["PioneerETConnectionString"].ConnectionString;
            using (var db = new PioneerETDataContext(cs))
            {
                return (from u in db.PioneerET_Users_from_LDAP
                        orderby u.FirstName
                        select new User()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            EmailAddress = u.EmailAddress,
                            PioneerUserIdentifier = u.PioneerUserIdentifier,
                            Role = u.MemberOfGroups
                        }).ToList();
            }
        }
    }
}

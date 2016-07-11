using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PioneerET.API.Models
{
    public class Books
    {
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ISBN { get; set; }
    }
}
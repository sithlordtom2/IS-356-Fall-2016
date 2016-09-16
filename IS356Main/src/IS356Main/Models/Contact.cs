using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS356Main.Models
{
    public class Contact
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string streetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int zipCode { get; set; }

        public string phoneNumber { get; set; }

        public string emailAddress { get; set; }

        public string pictureLink { get; set; }

        public string siteLink { get; set; }
    }
}

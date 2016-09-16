using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS356Main.Models
{
    public class Admin
    {
        public Admin()
        {
            listLinks = new List<Links>();
            listContacts = new List<Contact>();
            listGroups = new List<Groups>();
            listPresentations = new List<Presentations>();
        }

        public List<Links> listLinks { get; set; }

        public List<Contact> listContacts { get; set; }

        public List<Groups> listGroups { get; set; }

        public List<Presentations> listPresentations { get; set; }
    }
}

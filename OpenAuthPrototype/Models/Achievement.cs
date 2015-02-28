using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAuthPrototype.Models
{
    public class Achievement
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
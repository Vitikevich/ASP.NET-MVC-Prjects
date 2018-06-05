using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseXPagedListMVC.Models
{
    public class User
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; }
        public string SName { get; set; }
        public int Age { get; set; }
        public bool IsStudent { get; set; }
    }
}
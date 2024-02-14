using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiletypeAPI.Models
{
    public class Me
    {
        public Me() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Hobbies { get; set; }

        public override string ToString()
        {
            return $"This is me. my name is {FirstName} {LastName}, my Email is {Email}, My hobbies involves {String.Join(",", Hobbies)}";
        }
    }
}

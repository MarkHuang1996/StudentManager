using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Student
    {
        public int StudentId { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string Gender { get; set; }
        public  decimal Birthday { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
    }
}

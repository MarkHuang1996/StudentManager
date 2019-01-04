using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class StudentScore
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CSharp { get; set; }
        public int Database { get; set; }
        public decimal UpdateTime { get; set; }

    }
}

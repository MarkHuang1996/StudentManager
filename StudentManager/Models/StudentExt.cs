﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class StudentExt : Student
    {
        public string  ClassName { get; set; }
        public int CSharp { get; set; }
        public int SQLServerDB{ get; set; }
    }
}

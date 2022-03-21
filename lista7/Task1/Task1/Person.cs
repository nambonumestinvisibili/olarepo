using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Person
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public Category Category { get; set; }

        internal object[] ToArray()
        {
            return new string[] { Firstname, Surname, Birthday, Address };
        }
    }
}

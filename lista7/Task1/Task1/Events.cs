using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Events
    {
    }

    public class CategoryNodeClicked
    {
        public Category Category { get; set; }
    }

    public class PersonNodeClicked 
    {
        public Person Person { get; set; }
    }

    public class AddNewPersonEvent
    {
        public Person Person { get; set; }
    }

    public class ChangePersonEvent
    {
        public Person OldPerson { get; set; }
        public Person Person { get; set; }
    }

    public class PersonAdded
    {
        public Person Person { get; set; }
    }

    public class PersonChanged
    {
        public Person Person { get; set; }

    }
}

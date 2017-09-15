using System;

namespace Properties
{
    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; private set; }
        public Person(DateTime birthday)
        {
            Birthday = birthday;
        }
        
        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthday;
                var years = timeSpan.Days / 365;

                return years;
            }

        }
    }
}
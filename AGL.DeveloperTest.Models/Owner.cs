using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Here we show this class is cleaner because base class is hiding implementation.
    /// Age 
    /// 
    /// </summary>
    public class Owner : Person
    {
        public ICollection<Pets> Pets { get; set; }

        public Owner(string name, Gender gender) : base(name, gender)
        {

        }

        public Owner(string first, string last, Gender gender) : base(first, last, gender)
        {

        }

        public Owner(string name, Gender gender, int age) : base(name, gender)
        {
            base.Age = age;
        }
    }
}

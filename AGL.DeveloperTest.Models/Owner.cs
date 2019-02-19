using System.Collections.Generic;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Here we show this class is cleaner because base class is hiding implementation.
    /// </summary>
    public class Owner : Person
    {
        public ICollection<Pets> Pets { get; set; }

        public Owner(string name, GenderType gender) : base(name, gender)
        {

        }

        public Owner(string first, string last, GenderType gender) : base(first, last, gender)
        {

        }

        public Owner(string name, GenderType gender, int age) : base(name, gender)
        {
            base.Age = age;
        }
    }
}

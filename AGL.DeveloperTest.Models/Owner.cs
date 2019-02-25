using System.Collections.Generic;

using Newtonsoft.Json;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Here we show this class is cleaner because base class is hiding implementation.
    /// </summary>
    public class Owner : Person
    {
        public IList<Pets> Pets { get; set; }

        [JsonConstructor]
        public Owner(string name, string gender, int age) : base(name, gender, age)
        {

        }


        public Owner(string name, string gender) : base(name, gender)
        {

        }

        public Owner(string first, string last, string gender) : base(first, last, gender)
        {

        }

    }
}

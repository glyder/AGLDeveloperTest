using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Decisons here is we could of created a BASE class to house all the complexity around NAME
    /// but not to get into is a Pet and a Person the same name discussion, I'll just let this be a simple class for now.
    /// </summary>
    public class Pets
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}

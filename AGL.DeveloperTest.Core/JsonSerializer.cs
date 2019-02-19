using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace AGL.DeveloperTest.Core
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        public IList<T> DeserializeURL(string s)
        {
            return JsonConvert.DeserializeObject<List<T>>(s);
        }
    }

}

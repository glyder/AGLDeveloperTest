using System.Collections.Generic;

using Newtonsoft.Json;

namespace AGL.DeveloperTest.Core
{
    public class JsonDeserializer<T> : IDeserializer<T>
    {
        public IList<T> DeserializeURL(string s)
        {
            return JsonConvert.DeserializeObject<List<T>>(s);
        }
    }

}

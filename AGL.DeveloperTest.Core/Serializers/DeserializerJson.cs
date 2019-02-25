using System.Collections.Generic;

using Newtonsoft.Json;

namespace AGL.DeveloperTest.Core
{
    public class DeserializerJson<T> : IDeserializer<T>
    {
        public IList<T> DeserializeText(string text)
        {
            return JsonConvert.DeserializeObject<IList<T>>(text);
        }
    }

}

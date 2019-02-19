using System.Collections.Generic;

namespace AGL.DeveloperTest.Core
{
    public interface IDeserializer<T>
    {
        IList<T> DeserializeURL(string url);
    }
}

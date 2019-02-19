using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.DeveloperTest.Core
{
    public interface ISerializer<T>
    {
        IList<T> DeserializeURL(string url);
    }
}

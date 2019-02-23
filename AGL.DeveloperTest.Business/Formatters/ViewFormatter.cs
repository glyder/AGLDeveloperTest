
using System.Collections.Generic;

namespace AGL.DeveloperTest.Business
{
    public interface IViewFormatter<T>
    {
        IList<T> GetByType(string Type);
    }

    public class ViewFormatter<T> : IViewFormatter<T>
    {
        public IList<T> GetByType(string Type)
        {
            throw new System.NotImplementedException();
        }


    }
}

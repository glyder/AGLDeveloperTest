using System;
using System.IO;

namespace AGL.Base
{
    public abstract class BaseTests : IDisposable
    {
        protected BaseTests()
        {
            // Do "global" initialization here; Called before every test method.
        }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
        }

        #region "Properties"

        public readonly string PEOPLE_FILE_JSON = Directory.GetCurrentDirectory() + 
                                                  @"\_Data\people.json";

        public readonly bool runLiveTests = true;

        #endregion

        #region "Helpers"

        protected string helperGetSONFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        #endregion

    }
}

using System.IO;

namespace AGL.Base
{
    public abstract class BaseCoreTests
    {
        #region "Properties"

        public readonly string PEOPLE_FILE_JSON = Directory.GetCurrentDirectory() + 
                                                  @"\_Data\people.json";

        #endregion

        #region "Helpers"

        protected string helperGetSONFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        #endregion

    }
}

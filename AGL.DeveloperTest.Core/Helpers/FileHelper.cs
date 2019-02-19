using System;
using System.IO;

namespace AGL.DeveloperTest.Core
{
    public class FileHelper : IFileReader
    {
        public string Get(string path)
        {
            try
            {
                using (var reader = File.OpenText(path))
                {
                    var fileText = reader.ReadToEnd();
                    return fileText.ToString();
                }

            }
            catch (Exception ex)
            {
                // TODO: Logger;
                new Logger().Log(Models.LoggingEventType.Error, ex.Message);
                return null;
            }
        }
    }
}

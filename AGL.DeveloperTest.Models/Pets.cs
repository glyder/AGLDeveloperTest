
namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Is a Pet and Person Name the same?
    /// Probably not and we shouldn't build a base heirarchy because it shares Name property
    /// I'll leave this as a simple class.
    /// </summary>
    public class Pets
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}

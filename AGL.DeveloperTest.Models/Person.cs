
using Newtonsoft.Json;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Demonstration of hiding complex code in an abstract class.
    /// So Owner, etc would be less complex to understand.
    /// </summary>
    public abstract class Person
    {
        #region "Properties - private"

        [JsonIgnore]
        private string _firstName { get; set; }

        [JsonIgnore]
        private string _lastName { get; set; }

        #endregion

        #region "Properites - public"

        [JsonProperty("name")]
        public string Name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_lastName))
                {
                    return _firstName + ' ' + _lastName;
                }
                else
                {
                    return _firstName ?? string.Empty;
                }
            }

            set
            {
                _firstName = value;
            }
        }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonIgnore]
        [System.ComponentModel.DefaultValue(GenderType.Unknown)]
        public GenderType GenderType { get; set; }

        [JsonProperty("age")]
        [System.ComponentModel.DefaultValue(0)]
        public int Age { get; set; }

        #endregion

        #region "Constructors"

        public Person(string name,
                      string gender,
                      int age)
        {
            this._firstName = name;
            this.Gender = gender;
            this.Age = age;
        }

        public Person(string name,
                      GenderType Gender = GenderType.Unknown)
        {
            _firstName = name;
        }

        public Person(string firstName, 
                      string lastName, 
                      GenderType Gender = GenderType.Unknown)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        #endregion 
    }
}

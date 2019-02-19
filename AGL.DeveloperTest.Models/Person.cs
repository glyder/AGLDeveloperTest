using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Demonstration of hiding complex code in an abstract class.
    /// So Owner, etc would be less complex to understand.
    /// </summary>
    public abstract class Person
    {
        #region "Properties - private"

        private string _firstName { get; set; }
        private string _lastName { get; set; }

        #endregion

        #region "Properites - public"

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
        }

        [System.ComponentModel.DefaultValue(Gender.Unknown)]
        public Gender Gender { get; set; }

        [System.ComponentModel.DefaultValue(0)]
        public int Age { get; set; }

        #endregion

        #region "Constructors"

        public Person(string name,
                      Gender Gender = Gender.Unknown)
        {
            _firstName = name;
        }

        public Person(string firstName, 
                      string lastName, 
                      Gender Gender = Gender.Unknown)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        #endregion 
    }
}

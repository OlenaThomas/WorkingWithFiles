using System;

namespace TeacherStudentsLibrary
{
    [Serializable]
    public class Teacher : Person
    {
        public string Specialty
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} ", ID, FirstName, LastName, Specialty);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student person) return FirstName == person.FirstName;
            return false;
        }
    }
}

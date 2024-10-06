using System;

namespace TeacherStudentsLibrary
{
    [Serializable]
    public class Student : Person
    {
        public int GroupID
        {
            get;
            set;
        }

        public int RecordBookNumber
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", ID, FirstName, LastName, GroupID, RecordBookNumber);
        }
    }
}

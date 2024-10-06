namespace TeacherStudentsLibrary
{
    public class Person : TXTFiles
    {
        public int ID
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("[{0,2}] - {1} {2}", ID, FirstName, LastName);
        }
    }
}

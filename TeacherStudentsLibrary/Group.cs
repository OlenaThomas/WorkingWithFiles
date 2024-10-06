namespace TeacherStudentsLibrary
{
    public class Group : TXTFiles
    {
        public int ID
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public int TeacherID
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", ID, GroupName, TeacherID);
        }
    }
}

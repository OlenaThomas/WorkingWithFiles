using System.Collections.Generic;

namespace TeacherStudentsLibrary
{
    public class TeacherStudentsDataModel
    {
        #region         

        private List<Group> _groups = new List<Group>();
        private List<Teacher> _teachers = new List<Teacher>();
        private List<Student> _students = new List<Student>();
        //private List<Schedule> _schedule = new List<Schedule>();
        private Dictionary<DayLesson, Schedule> _schedule = new Dictionary<DayLesson, Schedule>();

        #endregion

        public TeacherStudentsDataModel()
        {
            _teachers.Add(new Teacher() { ID = 1, FirstName = "Nicolay", LastName = "Ivanov", Specialty = "Prog" });
            _teachers.Add(new Teacher() { ID = 2, FirstName = "Vasiliy", LastName = "Petrov", Specialty = "Test" });
            _teachers.Add(new Teacher() { ID = 3, FirstName = "Dmitriy", LastName = "Sidorov", Specialty = "Mngr" });
            _teachers.Add(new Teacher() { ID = 12, FirstName = "Alexey", LastName = "Simonov", Specialty = "Mngr" });
            _teachers.Add(new Teacher() { ID = 15, FirstName = "Alexandr", LastName = "Ivanov", Specialty = "Prog" });

            _groups.Add(new Group() { ID = 1, GroupName = "Gr_1", TeacherID = 2 });
            _groups.Add(new Group() { ID = 2, GroupName = "Gr_2", TeacherID = 3 });
            _groups.Add(new Group() { ID = 3, GroupName = "Gr_3", TeacherID = 1 });
            _groups.Add(new Group() { ID = 2, GroupName = "Gr_4", TeacherID = 3 });
            _groups.Add(new Group() { ID = 4, GroupName = "Gr_7", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_8", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_9", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_9", TeacherID = 18 });

            _students.Add(new Student() { ID = 15, FirstName = "Alexandr", LastName = "Ivanov", GroupID = 1, RecordBookNumber = 10201 });
            _students.Add(new Student() { ID = 4, FirstName = "Alexey", LastName = "Simonov", GroupID = 1, RecordBookNumber = 10201 });
            _students.Add(new Student() { ID = 5, FirstName = "Alexandr", LastName = "Alexandrov", GroupID = 4, RecordBookNumber = 10202 });
            _students.Add(new Student() { ID = 6, FirstName = "Genadiy", LastName = "Belaev", GroupID = 1, RecordBookNumber = 10203 });

            _students.Add(new Student() { ID = 7, FirstName = "Alexey", LastName = "Coval", GroupID = 2, RecordBookNumber = 10204 });
            _students.Add(new Student() { ID = 3, FirstName = "Stanislav", LastName = "Alekxeenko", GroupID = 2, RecordBookNumber = 10205 });
            _students.Add(new Student() { ID = 9, FirstName = "Valentina", LastName = "Belkina", GroupID = 3, RecordBookNumber = 10206 });
            _students.Add(new Student() { ID = 9, FirstName = "Alexandr", LastName = "Miroshnichenko", GroupID = 3, RecordBookNumber = 10207 });
            _students.Add(new Student() { ID = 10, FirstName = "Marat", LastName = "Ivaschenko", GroupID = 2, RecordBookNumber = 10202 });
            _students.Add(new Student() { ID = 11, FirstName = "Vasiliy", LastName = "Petrov", GroupID = 8, RecordBookNumber = 10208 });
        }

        public IEnumerable<Student> Students
        {
            get
            {
                return _students;
            }
        }

        public IEnumerable<Teacher> Teachers
        {
            get
            {
                return _teachers;
            }
        }

        public IEnumerable<Group> Groups
        {
            get
            {
                return _groups;
            }
        }

        public IEnumerable<Person> GetInvalidPersons()
        {
            return null;
        }

        public void GetCountGroupByTeacher(int teacherId = -1)
        {

        }
    }
}

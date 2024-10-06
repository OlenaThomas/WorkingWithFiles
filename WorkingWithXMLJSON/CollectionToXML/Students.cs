using System;
using System.Collections;
using TeacherStudentsLibrary;

namespace WorkingWithXMLJSON.CollectionToXML
{
    public class Students : ICollection
    {
        private ArrayList _studentsArray = new ArrayList();

        public Student this[int index] => (Student)_studentsArray[index];
        public void Add(Student student)
        {
            _studentsArray.Add(student);
        }

        public void CopyTo(Array array, int index)
        {
            _studentsArray.CopyTo(array, index);
        }

        public int Count => _studentsArray.Count;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public IEnumerator GetEnumerator() => _studentsArray.GetEnumerator();
    }
}

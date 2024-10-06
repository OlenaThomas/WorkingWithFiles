using System.Collections.Generic;
using System.IO;
using TeacherStudentsLibrary;
using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.DataLayers
{
    public class BinaryDataLayer
    {
        public void Write(string fileName, IEnumerable<Student> students)
        {
            using (Stream strm = new FileStream(fileName, FileMode.Create))
            {
                BinaryWriter wrtr = new BinaryWriter(strm);

                foreach (Student student in students)
                {
                    wrtr.Write(student);
                }

                wrtr.Flush();
            }
        }

        public IEnumerable<Student> Read(string fileName)
        {
            using (Stream strm = new FileStream(fileName, FileMode.Open))
            {
                BinaryReader rdr = new BinaryReader(strm);

                while (strm.Position < strm.Length)
                {
                    Student student;

                    rdr.Read(out student);

                    yield return student;
                }
            }
        }
    }
}

using System.Collections.Generic;
using System.IO;
using TeacherStudentsLibrary;

namespace WorkingWithFiles
{
    public static class TextFilesService
    {
        public async static void StreamWriterToTxt<T>(string fileName, IEnumerable<T> source) where T : TXTFiles
        {
            using (Stream strm = new FileStream(fileName, FileMode.Append))
            {
                StreamWriter writer = new StreamWriter(strm);

                foreach (var s in source)
                {
                    await writer.WriteAsync(s + "\n");
                }

                writer.Flush();
            }
        }

        public static IEnumerable<Student> StreamReaderTxtStudents(string fileName)
        {
            using (Stream strm = new FileStream(fileName, FileMode.Open))
            {
                StreamReader reader = new StreamReader(strm);

                string str = string.Empty;

                while ((str = reader.ReadLine()) != null)
                {
                    Student student = new Student();
                    string[] parameters = str.Split();

                    student.ID = int.Parse(parameters[0]);
                    student.LastName = parameters[1];
                    student.FirstName = parameters[2];
                    student.GroupID = int.Parse(parameters[3]);
                    student.RecordBookNumber = int.Parse(parameters[4]);

                    yield return student;
                }
            }
        }

        public static IEnumerable<Teacher> StreamReaderTxtTeachers(string fileName)
        {
            using (Stream strm = new FileStream(fileName, FileMode.Open))
            {
                StreamReader reader = new StreamReader(strm);

                string str = string.Empty;

                while ((str = reader.ReadLine()) != null)
                {
                    Teacher teacher = new Teacher();
                    string[] parameters = str.Split();

                    teacher.ID = int.Parse(parameters[0]);
                    teacher.LastName = parameters[1];
                    teacher.FirstName = parameters[2];
                    teacher.Specialty = parameters[3];

                    yield return teacher;
                }
            }
        }
    }
}

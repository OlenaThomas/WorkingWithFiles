using System;
using System.IO;
using TeacherStudentsLibrary;
using WorkingWithFiles.Exceptions;

namespace WorkingWithFiles.Helpers
{
    public struct StudentIO : IEntityObject<Student>
    {
        public Student ReadFromRecord(string[] parameters)
        {
            Student student = new Student();
            try
            { 
                student.ID = int.Parse(parameters[0]);
                student.FirstName = parameters[1];
                student.LastName = parameters[2];
                student.GroupID = int.Parse(parameters[3]);
                student.RecordBookNumber = int.Parse(parameters[4]);
            }
            catch(FormatException ex)
            {
                throw new ReadFromRecordException("StudentIO. Can't cast to int!", ex, parameters);
            }

            return student;
        }
        public void Write(StreamWriter writer, Student entity, char separator)
        {
            writer.Write(string.Format("{0}{5}{1}{5}{2}{5}{3}{5}{4}\n",
                                        entity.ID,
                                        entity.FirstName,
                                        entity.LastName,
                                        entity.GroupID,
                                        entity.RecordBookNumber, separator));
        }
    }
}

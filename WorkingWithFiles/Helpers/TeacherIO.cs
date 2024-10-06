using System;
using System.IO;
using TeacherStudentsLibrary;
using WorkingWithFiles.Exceptions;

namespace WorkingWithFiles.Helpers
{
    public struct TeacherIO : IEntityObject<Teacher>
    {
        public Teacher ReadFromRecord(string[] parameters)
        {
            Teacher teacher = new Teacher();

            try
            {
                teacher.ID = int.Parse(parameters[0]);
                teacher.FirstName = parameters[1];
                teacher.LastName = parameters[2];
                teacher.Specialty = parameters[3];
            }
            catch (FormatException ex)
            {
                throw new ReadFromRecordException("TeacherIO. Can't cast to int!", ex, parameters);
            }

            return teacher;
        }

        public void Write(StreamWriter writer, Teacher entity, char separator)
        {
            writer.Write(string.Format("{0}{4}{1}{4}{2}{4}{3}\n",
                                       entity.ID,
                                       entity.FirstName,
                                       entity.LastName,
                                       entity.Specialty, separator));
        }
    }
}

using System.IO;
using TeacherStudentsLibrary;

namespace WorkingWithFiles.Helpers
{
    static class WriteReadHelper
    {
        public static void Write(this BinaryWriter writer, Student student)
        {
            writer.Write(student.ID);
            writer.Write(student.FirstName);
            writer.Write(student.LastName);
            writer.Write(student.GroupID);
            writer.Write(student.RecordBookNumber);
        }

        public static void Read(this BinaryReader reader, out Student student)
        {
            int id = reader.ReadInt32();
            string firstName = reader.ReadString();
            string lastName = reader.ReadString();
            int GroupID = reader.ReadInt32();
            int RecordBookNumber = reader.ReadInt32();

            student = new Student()
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                GroupID = GroupID,
                RecordBookNumber = RecordBookNumber
            };
        }

        public static void Read(this StreamReader reader, string[] parameters, out Student student)
        {
            student = new Student();

            student.ID = int.Parse(parameters[0]);
            student.LastName = parameters[1];
            student.FirstName = parameters[2];
            student.GroupID = int.Parse(parameters[3]);
            student.RecordBookNumber = int.Parse(parameters[4]);
        }
    }
}

using System.IO;
using TeacherStudentsLibrary;

namespace WorkingWithFiles.Helpers
{
    public struct GroupIO : IEntityObject<Group>
    {
        public Group ReadFromRecord(string[] parameters)
        {
            Group group = new Group();

            group.ID = int.Parse(parameters[0]);
            group.GroupName = parameters[1];
            group.TeacherID = int.Parse(parameters[2]);

            return group;
        }

        public void Write(StreamWriter writer, Group entity, char separator)
        {
            writer.Write(string.Format("{0}{3}{1}{3}{2}\n",
                                                    entity.ID,
                                                    entity.GroupName,
                                                    entity.TeacherID, separator));
        }
    }
}

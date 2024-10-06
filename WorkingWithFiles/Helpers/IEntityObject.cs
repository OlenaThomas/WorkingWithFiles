using System.IO;

namespace WorkingWithFiles.Helpers
{
    public interface IEntityObject<T>
    {
        T ReadFromRecord(string[] parameters);
        void Write(StreamWriter writer, T entity, char separator);
    }
}

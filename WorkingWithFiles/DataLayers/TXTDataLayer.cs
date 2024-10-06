using System.Collections.Generic;
using System.IO;
using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.DataLayers
{
    public abstract class TXTDataLayer<TEntity, TEntityIO> : IDataLayer<TEntity, TEntityIO> 
        where TEntityIO : IEntityObject<TEntity>, new()
    {
        public abstract char Separator { get; }

        public void Write(string fileName, IEnumerable<TEntity> items)
        {
            FileInfo fiWorkFile = new FileInfo(fileName);

            FileMode mode = fiWorkFile.Exists ? FileMode.Append : FileMode.Create;

            using (Stream strm = new FileStream(fileName, mode))
            {
                StreamWriter writer = new StreamWriter(strm);

                TEntityIO entityIO = new TEntityIO();

                foreach (var s in items)
                {
                    entityIO.Write(writer, s, Separator);
                }

                writer.Flush();
            }
        }

        public IEnumerable<TEntity> Read(string fileName)
        {
            using (Stream strm = new FileStream(fileName, FileMode.Open))
            {
                StreamReader reader = new StreamReader(strm);

                TEntityIO entityIO = new TEntityIO();

                string str = string.Empty;
                
                while ((str = reader.ReadLine()) != null)
                {
                    string[] parameters = str.Split(new char[] { Separator });

                    if (parameters != null)
                    {
                        yield return entityIO.ReadFromRecord(parameters); ; 
                    }
                }
            }
        }
    }
}

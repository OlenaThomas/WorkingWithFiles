using System.Collections.Generic;
using System.IO;

namespace WorkingWithXMLJSON.DataLayers
{
    public class JSONDataLayer<T>
    {
        public void Write(string fileName, IEnumerable<T> items)
        {
            using(FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                System.Text.Json.JsonSerializer.Serialize(fs, items);
            }
        }

        public IEnumerable<T> Read(string fileName)
        {
            IEnumerable<T> result = null;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                result = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>(fs);
            }

            return result;
        }
    }
}

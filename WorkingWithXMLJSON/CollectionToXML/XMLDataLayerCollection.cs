using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace WorkingWithXMLJSON.CollectionToXML
{
    public class XMLDataLayerCollection<T>
    {
        XmlSerializer _xmlSrzr = new XmlSerializer(typeof(T));

        public void Write(string fileName, ICollection items)
        {
            using (FileStream fs = File.Create(fileName))
            {
                _xmlSrzr.Serialize(fs, items);
            }
        }

        public T Read(string fileName)
        {
            T values;

            using (FileStream fs = File.OpenRead(fileName))
            {
                values = (T)_xmlSrzr.Deserialize(fs);
            }

            return values;
        }
    }
}

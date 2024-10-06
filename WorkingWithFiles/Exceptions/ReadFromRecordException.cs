using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFiles.Exceptions
{
    public class ReadFromRecordException : Exception
    {
        private string[] _source;
        public int FieldCount
        {
            get { return _source.Length; }
        }
        public string this[int index]
        {
            get { return _source[index]; }
        }
        public ReadFromRecordException() :base()
        {
            
        }

        public ReadFromRecordException(string message) : base(message)
        {

        }

        public ReadFromRecordException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public ReadFromRecordException(string message, Exception innerException, string[] source) : base(message, innerException)
        {
            _source = (string[])source.Clone();
        }
    }
}

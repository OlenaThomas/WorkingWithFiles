using System.Collections.Generic;
using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.DataLayers
{
    public interface IDataLayer<TEntity, TEntityIO>
        where TEntityIO : IEntityObject<TEntity>, new()
    {
        void Write(string fileName, IEnumerable<TEntity> items);
        IEnumerable<TEntity> Read(string fileName);
    }
}

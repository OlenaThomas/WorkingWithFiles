using WorkingWithFiles.DataLayers;
using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.Services
{
    public abstract class DataLayerCreator<TEntity, TEntityIO>
        where TEntityIO : IEntityObject<TEntity>, new()
    {
        public abstract IDataLayer<TEntity, TEntityIO> Create();
    }
}

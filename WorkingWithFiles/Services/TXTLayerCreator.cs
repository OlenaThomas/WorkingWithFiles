using WorkingWithFiles.DataLayers;
using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.Services
{
    internal class TXTLayerCreator<TEntity, TEntityIO> : DataLayerCreator<TEntity, TEntityIO>
        where TEntityIO : IEntityObject<TEntity>, new()
        where TEntity : class
    {
        public override IDataLayer<TEntity, TEntityIO> Create() =>
            new TXTData<TEntity, TEntityIO>();
    }
}

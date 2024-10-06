using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.DataLayers
{

    public class TXTData<TEntity, TEntityIO> : TXTDataLayer<TEntity, TEntityIO>
         where TEntityIO : IEntityObject<TEntity>, new()
         where TEntity : class
    {
        public override char Separator { get; } = ' ';
    }
}

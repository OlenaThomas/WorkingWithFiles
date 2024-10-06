using WorkingWithFiles.Enums;
using WorkingWithFiles.Helpers;

namespace WorkingWithFiles.Services
{
    public class DataLayerService<TEntity, TEntityIO>
        where TEntityIO : IEntityObject<TEntity>, new()
        where TEntity : class
    {
        public static DataLayerCreator<TEntity, TEntityIO> GetDataLayerCreator(FileType fileType)
        {
            DataLayerCreator<TEntity, TEntityIO> creator = null;

            if (fileType == FileType.csv)
            {
                creator = new CSVLayerCreator<TEntity, TEntityIO>();
            }
            else if (fileType == FileType.txt)
            {
                creator = new TXTLayerCreator<TEntity, TEntityIO>();
            }

            return creator;
        }
    }
}

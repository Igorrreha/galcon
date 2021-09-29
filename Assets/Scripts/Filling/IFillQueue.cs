
namespace Galcon.Filling
{
    public interface IFillQueue<TItem, TData>
    {
        void AddObjectIntoFillQueue(TItem item);


        void AddDataIntoFillQueue(TData data);
    }
}

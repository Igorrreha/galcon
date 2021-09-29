using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Filling
{
    public abstract class QueuedFiller<TItem, TData> : MonoBehaviour, IFillQueue<TItem, TData>
        where TItem : IFillable<TData>
    {
        [SerializeField] private UnityEvent _onDataRequested;

        private Queue<TItem> _itemsQueue = new Queue<TItem>();
        private Queue<TData> _dataItemsQueue = new Queue<TData>();


        public void AddObjectIntoFillQueue(TItem item)
        {
            _itemsQueue.Enqueue(item);

            if (_dataItemsQueue.Count > 0)
            {
                Fill(_itemsQueue.Dequeue(), _dataItemsQueue.Dequeue());
            }
            else
            {
                RequestData();
            }
        }


        public void AddDataIntoFillQueue(TData dataItem)
        {
            _dataItemsQueue.Enqueue(dataItem);

            if (_itemsQueue.Count > 0)
            {
                Fill(_itemsQueue.Dequeue(), _dataItemsQueue.Dequeue());
            }
        }


        private void Fill(TItem item, TData data)
        {
            item.Fill(data);
        }


        private void RequestData()
        {
            _onDataRequested?.Invoke();
        }
    }
}

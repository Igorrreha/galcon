using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Filling
{
    public abstract class ObjectDataPairQueuedGenerator<TObject, TData, TEvent> : MonoBehaviour, IFillQueue<TObject, TData>
        where TEvent : UnityEvent<KeyValuePair<TObject, TData>>
    {
        [SerializeField] private TEvent _onPairGenerated;

        private Queue<TObject> _objectsQueue = new Queue<TObject>();
        private Queue<TData> _dataItemsQueue = new Queue<TData>();


        public void AddObjectIntoFillQueue(TObject item)
        {
            _objectsQueue.Enqueue(item);

            if (_dataItemsQueue.Count > 0)
            {
                Fill(_objectsQueue.Dequeue(), _dataItemsQueue.Dequeue());
            }
        }


        public void AddDataIntoFillQueue(TData dataItem)
        {
            _dataItemsQueue.Enqueue(dataItem);

            if (_objectsQueue.Count > 0)
            {
                Fill(_objectsQueue.Dequeue(), _dataItemsQueue.Dequeue());
            }
        }


        private void Fill(TObject item, TData data)
        {
            KeyValuePair<TObject, TData> pair = new KeyValuePair<TObject, TData>(item, data);

            _onPairGenerated?.Invoke(pair);
        }
    }
}

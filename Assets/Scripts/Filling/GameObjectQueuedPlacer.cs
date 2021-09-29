using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Filling
{
    public class GameObjectQueuedPlacer : MonoBehaviour, IFillQueue<GameObject, Vector2>
    {
        [SerializeField] private UnityEvent _onDataRequested;

        private Queue<GameObject> _itemsQueue = new Queue<GameObject>();
        private Queue<Vector2> _dataItemsQueue = new Queue<Vector2>();


        public void AddObjectIntoFillQueue(GameObject item)
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


        public void AddDataIntoFillQueue(Vector2 dataItem)
        {
            _dataItemsQueue.Enqueue(dataItem);

            if (_itemsQueue.Count > 0)
            {
                Fill(_itemsQueue.Dequeue(), _dataItemsQueue.Dequeue());
            }
        }


        private void Fill(GameObject item, Vector2 data)
        {
            item.transform.position = data;
        }


        private void RequestData()
        {
            _onDataRequested?.Invoke();
        }
    }
}

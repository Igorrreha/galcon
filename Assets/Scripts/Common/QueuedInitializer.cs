using System.Collections.Generic;

using UnityEngine;

using Galcon.Events;

namespace Galcon.Common
{
    public class QueuedInitializer : MonoBehaviour
    {
        [SerializeField] private UnityGameObjectEvent _onObjectInitialized;
        [SerializeField] private UnityGameObjectEvent _onLastObjectInitialized;

        private Queue<Initializable> _objectsQueue = new Queue<Initializable>();


        public void InitializeNext()
        {
            if (_objectsQueue.Count == 0) return;

            _objectsQueue.Dequeue().Initialize();
            
            if (_objectsQueue.Count == 0)
            {
                _onLastObjectInitialized?.Invoke(gameObject);
            }
            else
            {
                _onObjectInitialized?.Invoke(gameObject);
            }
        }


        public void AddObjectInitoQueue(Initializable initializable)
        {
            _objectsQueue.Enqueue(initializable);
        }


        public void AddObjectIntoQueue(GameObject gameObject)
        {
            AddObjectInitoQueue(gameObject.GetComponent<Initializable>());
        }
    }
}

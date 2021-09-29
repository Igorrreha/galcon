using System.Collections.Generic;

using UnityEngine;

using Galcon.Events;

namespace Galcon.Common
{
    public class QueuedResetter : MonoBehaviour
    {
        [SerializeField] private UnityGameObjectEvent _onObjectResetted;
        [SerializeField] private UnityGameObjectEvent _onLastObjectResetted;

        private Queue<Resettable> _objectsQueue = new Queue<Resettable>();


        public void ResetNext()
        {
            if (_objectsQueue.Count == 0) return;

            _objectsQueue.Dequeue().ResetToDefault();
            
            if (_objectsQueue.Count == 0)
            {
                _onLastObjectResetted?.Invoke(gameObject);
            }
            else
            {
                _onObjectResetted?.Invoke(gameObject);
            }
        }


        public void AddObjectInitoQueue(Resettable resettable)
        {
            _objectsQueue.Enqueue(resettable);
        }


        public void AddObjectIntoQueue(GameObject gameObject)
        {
            AddObjectInitoQueue(gameObject.GetComponent<Resettable>());
        }
    }
}

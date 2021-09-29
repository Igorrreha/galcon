using UnityEngine;

using Galcon.Storages;
using Galcon.Providers;

namespace Galcon.Observing
{
    public class ObservableGameObjectsObserver : MonoBehaviour
    {
        [SerializeField] private GameObjectsProvider _objectsProvider;
        [SerializeField] private PrefabedGameObjectsStorage _observableObjectsStorage;


        public void StartObserving(GameObject objectToObserve, GameObject prefab)
        {
            // add object into pool
            if (!_observableObjectsStorage.Data.ContainsKey(objectToObserve))
            {
                _observableObjectsStorage.Add(objectToObserve, prefab);
            }

            InitializeObject(objectToObserve);
        }


        private void InitializeObject(GameObject objectToObserve)
        {
            if (objectToObserve.TryGetComponent(out Observable observable))
            {
                observable.Initialize(this);
            }
            else
            {
                throw new UnityException("Observable object must contain Observable component");
            }
        }


        public void ReturnToProvider(GameObject providedObject)
        {
            _objectsProvider.AddReadyToProvideObject(providedObject, _observableObjectsStorage.Data[providedObject]);
        }
    }
}

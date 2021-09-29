using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Galcon.Events;
using Galcon.Observing;
using Galcon.Factories;

namespace Galcon.Providers
{
    public class GameObjectsProvider : MonoBehaviour
    {
        [SerializeField] private ObservableGameObjectsObserver _observableGameObjectsObserver;
        [SerializeField] private UnityGameObjectEvent _onObjectProvided;

        private Dictionary<GameObject, GameObject> _readyToProvideObjectsDictionary = new Dictionary<GameObject, GameObject>(); // key: instance, value: prefab

        private GameObjectFactory _factory = new GameObjectFactory();


        public void Provide(GameObject prefab)
        {
            ProvideAndReturn(prefab);
        }


        public GameObject ProvideAndReturn(GameObject prefab)
        {
            GameObject provideableGameObject;
            if (!TryGetFromPool(prefab, out provideableGameObject))
            {
                provideableGameObject = GetFromFactory(prefab);
            }

            _observableGameObjectsObserver.StartObserving(provideableGameObject, prefab);

            _onObjectProvided?.Invoke(provideableGameObject);

            return provideableGameObject;
        }


        public void AddReadyToProvideObject(GameObject gameObject, GameObject prefab)
        {
            _readyToProvideObjectsDictionary.Add(gameObject, prefab);
        }


        private bool TryGetFromPool(GameObject prefab, out GameObject gettedObject)
        {
            if (_readyToProvideObjectsDictionary.ContainsValue(prefab))
            {
                KeyValuePair<GameObject, GameObject> findedPair = _readyToProvideObjectsDictionary.First(x => x.Value == prefab);
                gettedObject = findedPair.Key;
                _readyToProvideObjectsDictionary.Remove(gettedObject);
                return true;
            }
            else
            {
                gettedObject = null;
                return false;
            }
        }


        private GameObject GetFromFactory(GameObject prefab)
        {
            GameObject newObject = _factory.Create(prefab);

            return newObject;
        }
    }
}

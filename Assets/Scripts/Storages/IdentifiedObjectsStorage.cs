using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Storages
{
    public abstract class IdentifiedObjectsStorage<TIdentifier, TObject, TObjectEvent> : EnumerableStorage<Dictionary<TIdentifier, TObject>>
        where TObjectEvent: UnityEvent<TObject>
    {
        [SerializeField] private TObjectEvent _onObjectAdded;
        [SerializeField] private TObjectEvent _onObjectRemoved;


        public void Add(TIdentifier identifier, TObject item)
        {
            Data.Add(identifier, item);

            _onObjectAdded?.Invoke(item);
        }


        public void Add(KeyValuePair<TIdentifier, TObject> identifierGameObjectPair)
        {
            Add(identifierGameObjectPair.Key, identifierGameObjectPair.Value);
        }


        public void RemoveByIdentifier(TIdentifier identifier)
        {
            TObject item = Data[identifier];
            
            Data.Remove(identifier);

            _onObjectRemoved?.Invoke(item);
        }


        public TObject GetByIdentifier(TIdentifier identifier)
        {
            return Data[identifier];
        }
    }
}
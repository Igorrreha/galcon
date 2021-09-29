using UnityEngine;

namespace Galcon.Storages
{
    public abstract class DataStorage<T> : MonoBehaviour
    {
        [SerializeField] private T _data;


        public T Data => _data;


        public void StoreData(T data)
        {
            _data = data;
        }
    }
}

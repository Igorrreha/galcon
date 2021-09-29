using System;
using System.Collections;

using UnityEngine;

namespace Galcon.Storages
{
    public abstract class EnumerableStorage<T> : MonoBehaviour
        where T : IEnumerable, new()
    {
        [SerializeField] private T _data = new T();


        public T Data => _data;


        public void StoreData(T data)
        {
            _data = data;
        }
    }
}

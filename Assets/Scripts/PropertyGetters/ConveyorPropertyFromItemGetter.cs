using UnityEngine;
using UnityEngine.Events;

namespace Galcon.PropertyGetters
{
    public abstract class ConveyorPropertyFromItemGetter<TItem, TProperty, TEvent> : MonoBehaviour
        where TEvent : UnityEvent<TProperty>
    {
        [SerializeField] private TEvent _onGetted;


        public void GetFrom(TItem item)
        {
            _onGetted?.Invoke(Get(item));
        }


        protected abstract TProperty Get(TItem item);
    }
}

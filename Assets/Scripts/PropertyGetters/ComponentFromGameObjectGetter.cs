using UnityEngine;
using UnityEngine.Events;

namespace Galcon.PropertyGetters
{
    public abstract class ComponentFromGameObjectGetter<TComponent, TEvent> : ConveyorPropertyFromItemGetter<GameObject, TComponent, TEvent>
        where TEvent : UnityEvent<TComponent>
    {
        protected override TComponent Get(GameObject item) => item.GetComponent<TComponent>();
    }
}

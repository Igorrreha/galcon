using UnityEngine;

using Galcon.Events;

namespace Galcon.PropertyGetters
{
    public abstract class GameObjectFromComponentGetter<TComponent> : ConveyorPropertyFromItemGetter<TComponent, GameObject, UnityGameObjectEvent>
        where TComponent : MonoBehaviour
    {
        protected override GameObject Get(TComponent item) => item?.gameObject ?? default(GameObject);
    }
}

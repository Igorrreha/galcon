using UnityEngine;

using Galcon.Events;

namespace Galcon.PropertyGetters
{
    public class PositionFromGameObjectGetter : ConveyorPropertyFromItemGetter<GameObject, Vector2, UnityVector2Event>
    {
        protected override Vector2 Get(GameObject item) => item.transform.position;
    }
}

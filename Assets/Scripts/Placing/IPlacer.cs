using UnityEngine;

namespace Galcon.Placing
{
    public abstract class Placer : MonoBehaviour
    {
        public abstract void Place(GameObject item);
    }
}

using UnityEngine;

namespace Galcon.Filters
{
    public abstract class Filter : MonoBehaviour
    {
        public abstract bool IsPermitted();
    }
}
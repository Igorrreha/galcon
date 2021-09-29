using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Dispatchers
{
    public sealed class StartEventDispatcher : MonoBehaviour
    {
        [SerializeField] private UnityEvent _started;

        private void Start()
        {
            _started?.Invoke();
        }
    }
}
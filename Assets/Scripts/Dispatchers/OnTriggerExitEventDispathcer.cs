using UnityEngine;

using Galcon.Events;

namespace Galcon.Dispatchers
{
    public sealed class OnTriggerExitEventDispathcer : MonoBehaviour
    {
        [SerializeField] private UnityColliderEvent _exited;


        private void OnTriggerExit(Collider collider)
        {
            _exited?.Invoke(collider);
        }
    }
}
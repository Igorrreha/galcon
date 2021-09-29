using UnityEngine;

using Galcon.Events;

namespace Galcon.Dispatchers
{
    public sealed class OnTriggerEnterEventDispathcer : MonoBehaviour
    {
        [SerializeField] private UnityColliderEvent _entered;


        private void OnTriggerEnter(Collider collider)
        {
            _entered?.Invoke(collider);
        }


        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("COllision");
        }
    }
}
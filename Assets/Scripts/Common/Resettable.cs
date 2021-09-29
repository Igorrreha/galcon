using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Common
{
    public class Resettable : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onResetting;


        public void ResetToDefault()
        {
            _onResetting?.Invoke();
        }
    }
}

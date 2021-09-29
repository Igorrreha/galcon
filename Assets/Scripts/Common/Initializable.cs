using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Common
{
    public class Initializable : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onInitializing;


        public void Initialize()
        {
            _onInitializing?.Invoke();
        }
    }
}

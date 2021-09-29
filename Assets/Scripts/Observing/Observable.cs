using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Observing
{
    public sealed class Observable : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onInitialized;
        [SerializeField] private UnityEvent _onResetedToDefault;

        private ObservableGameObjectsObserver _observer;


        public void Initialize(ObservableGameObjectsObserver observer)
        {
            _observer = observer;

            _onInitialized?.Invoke();
        }


        public void ResetToDefault()
        {
            _observer.ReturnToProvider(gameObject);

            _onResetedToDefault?.Invoke();
        }
    }
}
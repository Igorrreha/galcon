using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Actions
{
    public class SimpleAction : Action
    {
        [SerializeField] private UnityEvent _done;

        public override void DoAction()
        {
            _done?.Invoke();
        }
    }
}

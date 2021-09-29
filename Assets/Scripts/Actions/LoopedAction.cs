using System.Collections;
using UnityEngine;

namespace Galcon.Actions
{
    public sealed class LoopedAction : MonoBehaviour
    {
        [SerializeField] private Action _action;
        [SerializeField] private float _delay;

        private Coroutine _loopCoroutine;
        

        public void BeginAction()
        {
            StopLooping();

            _loopCoroutine = StartCoroutine(LoopCoroutine());
        }


        public void EndAction()
        {
            StopLooping();
        }
        

        public void RestartIfIsActive()
        {
            if (_loopCoroutine == null) return;

            BeginAction();
        }


        private void StopLooping()
        {
            if (_loopCoroutine == null) return;
            
            StopCoroutine(_loopCoroutine);
            _loopCoroutine = null;
        }


        private IEnumerator LoopCoroutine()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(_delay);
            
                _action.DoAction();
            }

            _loopCoroutine = null;
        }
    }
}
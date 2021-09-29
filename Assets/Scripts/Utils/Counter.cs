using System;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Utils
{
    public class Counter : MonoBehaviour, IDisposable
    {
        [Min(1)]
        [SerializeField] private int _maxCalls = 1;

        [SerializeField] private UnityEvent _maxReached;

        private int _currentCallsNumber = 0;
        private bool _isMaxReached;


        public void Count()
        {
            if (_isMaxReached) return;

            _currentCallsNumber++;

            if (_currentCallsNumber == _maxCalls)
            {
                _isMaxReached = true;
                _maxReached?.Invoke();
            }
        }


        public void Dispose()
        {
            _currentCallsNumber = 0;
            _isMaxReached = false;
        }
    }
}

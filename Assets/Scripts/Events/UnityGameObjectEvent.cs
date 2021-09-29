using System;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Events
{
    [Serializable]
    public class UnityGameObjectEvent : UnityEvent<GameObject> { }
}
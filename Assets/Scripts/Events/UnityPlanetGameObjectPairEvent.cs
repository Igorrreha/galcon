using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using Galcon.Core;

namespace Galcon.Events
{
    [Serializable]
    public class UnityPlanetGameObjectPairEvent : UnityEvent<KeyValuePair<Planet, GameObject>> { }
}
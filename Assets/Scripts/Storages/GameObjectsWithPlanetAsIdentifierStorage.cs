using UnityEngine;

using Galcon.Core;
using Galcon.Events;

namespace Galcon.Storages
{
    public sealed class GameObjectsWithPlanetAsIdentifierStorage : IdentifiedObjectsStorage<Planet, GameObject, UnityGameObjectEvent> { }
}

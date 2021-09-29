using UnityEngine;
using Galcon.Events;

namespace Galcon.Storages
{
    public sealed class PrefabedGameObjectsStorage : IdentifiedObjectsStorage<GameObject, GameObject, UnityGameObjectEvent> { }
}
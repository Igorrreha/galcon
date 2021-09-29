using System.Collections.Generic;

using UnityEngine;

using Galcon.Events;
using Galcon.Storages;

namespace Galcon.Selectors
{
    public sealed class FilteredInstanceSelectorFromPrefabedGameObjectsStorage : FilteredItemSelectorFromEnumerableStorage<PrefabedGameObjectsStorage,
        Dictionary<GameObject, GameObject>, KeyValuePair<GameObject, GameObject>, GameObject, UnityGameObjectEvent>
    {
        protected override GameObject GetItemFromDataItem(KeyValuePair<GameObject, GameObject> dataItem) => dataItem.Key;
    }
}

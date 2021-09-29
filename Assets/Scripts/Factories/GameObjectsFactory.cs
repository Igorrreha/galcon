using UnityEngine;

namespace Galcon.Factories
{
    public sealed class GameObjectFactory : IFactory<GameObject, GameObject>
    {
        public GameObject Create(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }
    }
}
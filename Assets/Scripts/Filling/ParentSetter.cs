using UnityEngine;

namespace Galcon.Filling
{
    public sealed class ParentSetter : MonoBehaviour
    {
        [SerializeField] private Transform _parentTransform;

        public void SetParent(GameObject item)
        {
            item.transform.SetParent(_parentTransform);
        }
    }
}
using UnityEngine;

namespace Galcon.Filling
{
    public sealed class ScaleSetter : MonoBehaviour
    {
        [SerializeField] private Vector3 _scale;


        public void SetScale(GameObject target)
        {
            SetScale(target.transform);
        }


        public void SetScale(Transform target)
        {
            target.localScale = _scale;
        }
    }
}
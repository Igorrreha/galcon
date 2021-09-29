using UnityEngine;

namespace Galcon.Filters
{
    public class BooleanFilter : Filter
    {
        [SerializeField] private bool _isPermitted;


        public void SetPermitted(bool value) => _isPermitted = value;


        public override bool IsPermitted()
        {
            return _isPermitted;
        }
    }
}

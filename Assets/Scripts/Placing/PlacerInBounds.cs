using UnityEngine;

namespace Galcon.Placing
{
    public sealed class PlacerInBounds : Placer
    {
        [SerializeField] private Transform _targetTransform;
        
        [SerializeField] private Vector2 _size;

        private Bounds _bounds;


        private void Awake()
        {
            _bounds = new Bounds(_targetTransform.position, _size);
        }


        public override void Place(GameObject item)
        {
            item.transform.position = GetRandomPositionInBounds();
        }


        private Vector2 GetRandomPositionInBounds()
        {
            _bounds.center = _targetTransform.position;
            
            var xPosition = Random.Range(_bounds.min.x, _bounds.max.x);
            var yPosition = Random.Range(_bounds.min.y, _bounds.max.y);

            return new Vector2(xPosition, yPosition);
        }


#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (_targetTransform == null)
            {
                return;
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(_targetTransform.position, _size);
        }
#endif
    }
}
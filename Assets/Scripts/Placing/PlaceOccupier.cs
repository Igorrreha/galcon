using UnityEngine;

namespace Galcon.Placing
{
    public class PlaceOccupier : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;


        public Collider2D Collider => _collider;
    }
}

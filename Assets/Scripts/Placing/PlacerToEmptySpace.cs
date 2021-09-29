using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Galcon.Placing
{
    public sealed class PlacerToEmptySpace : Placer
    {
        [SerializeField] private Placer _placer;
        [Min(1)]
        [SerializeField] private int _maxPlaceAttempts = 1;

        [SerializeField] private UnityEvent _onPlaced;
        [SerializeField] private UnityEvent _onPlacingFailed;

        private List<Bounds> _boundsList = new List<Bounds>();


        public override void Place(GameObject item)
        {
            bool isPlaced = false;

            for (int i = 0; i < _maxPlaceAttempts; i++)
            {
                if (TryPlace(item))
                {
                    isPlaced = true;
                    break;
                }
            }

            AddItemBoundsToList(item);

            if (isPlaced)
            {
                _onPlaced?.Invoke();
            }
            else
            {
                _onPlacingFailed?.Invoke();
            }
        }


        private bool TryPlace(GameObject item)
        {
            _placer.Place(item);

            return !HasCollision(item);
        }


        private bool HasCollision(GameObject item)
        {
            Bounds itemBounds = GetBounds(item);

            foreach (Bounds bounds in _boundsList)
            {
                if (itemBounds.Intersects(bounds))
                {
                    return true;
                }
            }

            return false;
        }


        private void AddItemBoundsToList(GameObject item)
        {
            _boundsList.Add(GetBounds(item));
        }


        private Bounds GetBounds(GameObject item)
        {
            if (!item.TryGetComponent(out PlaceOccupier placeOccupier)) {
                throw new UnityException("Placeable object must contain PlaceOccupier component");
            }

            Collider2D collider = placeOccupier.Collider;

            Bounds bounds = collider.bounds;
            bounds.center = item.transform.position;

            return bounds;
        }
    }
}
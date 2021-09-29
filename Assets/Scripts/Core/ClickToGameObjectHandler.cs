using UnityEngine;
using UnityEngine.EventSystems;

using Galcon.Events;

namespace Galcon.Core
{
    public class ClickToGameObjectHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private UnityGameObjectEvent _gameObjectClicked;


        public void OnPointerClick(PointerEventData eventData)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 rayDirection = (Vector3.zero - Camera.main.transform.position).normalized;

            Ray ray = new Ray(worldPoint, rayDirection);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _layerMask);
            if (hit != default(RaycastHit2D))
            {
                _gameObjectClicked?.Invoke(hit.transform.gameObject);
            }
        }
    }
}

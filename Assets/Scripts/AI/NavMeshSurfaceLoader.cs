using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Galcon.AI
{
    [RequireComponent(typeof(NavMeshSurface2d))]
    public class NavMeshSurfaceLoader : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onLoaded;
        

        public void Load()
        {
            NavMeshSurface2d surface = GetComponent<NavMeshSurface2d>();
            surface.BuildNavMeshAsync().completed += LoadingCompleted;
        }


        private void LoadingCompleted(AsyncOperation operation)
        {
            _onLoaded?.Invoke();
        }
    }
}

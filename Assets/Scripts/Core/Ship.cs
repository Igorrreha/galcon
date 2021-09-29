using UnityEngine;
using UnityEngine.AI;

namespace Galcon.Core
{
    public class Ship : MonoBehaviour
    {
        private Player _owner;
        private GameObject _target;
        private NavMeshAgent _navMeshAgent;


        public Player Owner => _owner;


        public GameObject Target => _target;


        public void Initialize(Player owner, GameObject target)
        {
            gameObject.AddComponent(typeof(NavMeshAgent));

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;

            _owner = owner;
            _target = target;

            //_navMeshAgent.SetDestination(target.transform.position);
        }
    }
}

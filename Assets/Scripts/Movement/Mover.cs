using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{ 
    public class Mover : MonoBehaviour
    {

        private NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            UpdateAnimator();
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
            navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
        private void UpdateAnimator()
        {
            // In Unreal this would be done with a UAnimInstance
            Vector3 worldVelocity = navMeshAgent.velocity;
            Vector3 localVeloctity = transform.InverseTransformDirection(worldVelocity);
            float speed = localVeloctity.z; // Forward speed

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}

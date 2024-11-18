using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;


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

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel(); // Might want to change this later to remove dependency
            MoveTo(destination);
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

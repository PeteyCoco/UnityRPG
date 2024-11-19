using UnityEngine;
using UnityEngine.AI;
using RPG.Core;


namespace RPG.Movement
{ 
    public class Mover : MonoBehaviour, IAction
    {

        private NavMeshAgent navMeshAgent;
        private Health health;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
            navMeshAgent.isStopped = false;
        }
        private void UpdateAnimator()
        {
            // In Unreal this would be done with a UAnimInstance
            Vector3 worldVelocity = navMeshAgent.velocity;
            Vector3 localVeloctity = transform.InverseTransformDirection(worldVelocity);
            float speed = localVeloctity.z; // Forward speed

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        //~ Begin IAction interface
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
        //~ End IAction interface

    }
}

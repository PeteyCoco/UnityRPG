using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{ 
    public class Mover : MonoBehaviour
    {

        void Update()
        {
            UpdateAnimator();
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }

        private void UpdateAnimator()
        {
            // In Unreal this would be done with a UAnimInstance
            Vector3 worldVelocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVeloctity = transform.InverseTransformDirection(worldVelocity);
            float speed = localVeloctity.z; // Forward speed

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}

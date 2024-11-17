using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }

    private void MoveToCursor()
    {
        // Move the NavMeshAgent to the cursor location
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hitInfo);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
        }
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

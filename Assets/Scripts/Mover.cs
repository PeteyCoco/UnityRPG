using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
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
}

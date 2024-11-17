using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    void Start()
    {
        
    }
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }
}

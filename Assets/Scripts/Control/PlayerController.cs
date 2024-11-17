using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButton(0))
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
                GetComponent<Mover>().MoveTo(hitInfo.point);
            }
        }
    }
}

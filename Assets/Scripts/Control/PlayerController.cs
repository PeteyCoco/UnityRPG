using UnityEngine;
using RPG.Combat;
using RPG.Movement;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                // Attack any hit combat targets
                CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
                if (!target) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
            }
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hitInfo);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hitInfo.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

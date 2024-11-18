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
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            print("Nothing to do...");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
                if (!target)
                {
                    continue;
                }
                if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hitInfo);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hitInfo.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

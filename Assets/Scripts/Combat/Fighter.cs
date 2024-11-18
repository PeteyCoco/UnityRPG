using UnityEngine;
using RPG.Movement;
using Unity.VisualScripting;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {

        [SerializeField] float weaponRange = 2f;
        private Transform target;

        private void Update()
        {
            if (target)
            {
                bool isInRange = Vector3.Distance(target.position, transform.position) < weaponRange;

                if (!isInRange)
                {
                    GetComponent<Mover>().MoveTo(target.position);
                }
                else
                {
                    GetComponent<Mover>().Stop();
                }
            }
        }
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}

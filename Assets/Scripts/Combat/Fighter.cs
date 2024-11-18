using UnityEngine;
using Unity.VisualScripting;
using RPG.Core;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {

        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float timeBetweenAttacks = 1f;

        private Health target;
        private float timeSinceLastAttack = 0f;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (!target) return;
            if (target.IsDead()) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // Triggers hit event
                TriggerAttack();
                timeSinceLastAttack = 0f;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }


        // Animation hit event callback
        void Hit()
        {
            if (!target) return;
            
            target.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(target.transform.position, transform.position) < weaponRange;
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetHealth = combatTarget.GetComponent<Health>();
            return targetHealth && !targetHealth.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        //~ Begin IAction interface
        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
        //~ End IAction interface
    }
}

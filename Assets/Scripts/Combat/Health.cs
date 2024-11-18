using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        private bool isDead = false;

        public bool IsDead() { 
            return isDead; 
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0f);
            if (healthPoints == 0f)
            {
                Die();
            }
        }

        private void Die()
        {
            if (IsDead()) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}
using UnityEngine;
using UnityEngine.Events;
using AAA.Utility.GlobalVariables;

namespace XYRalityTest
{
    public class DealDamage : MonoBehaviour
    {
        [SerializeField] private int damageAmount;
        [SerializeField] private UnityEvent onHit;

        public void DealDamageTo(Collision collision)
        {
            DealDamageTo(collision.gameObject.GetComponent<IDamageable>());
        }
        public void DealDamageTo(GameObject gameObject)
        {
            DealDamageTo(gameObject.GetComponent<IDamageable>());
        }
        public void DealDamageTo(IDamageable damageable)
        {
            if(damageable == null)
                return;

            onHit.Invoke();
            damageable.Damage(damageAmount);
        }
    }
}
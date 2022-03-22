using UnityEngine;
using UnityEngine.Events;
using AAA.Utility.GlobalVariables;

namespace XYRalityTest
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private IntRangeReference healthPoints;
        [SerializeField] private UnityEvent onHit, onDied;
        public void Damage(int amount)
        {
            healthPoints.Value.Value -= amount;
            onHit.Invoke();
            
            if(healthPoints.Value.Value == 0)
                onDied.Invoke();
        }

        // Turns out I actually don't need this afterall
        public int GetHealth()
        {
            return healthPoints.Value.Value;
        }
    }
}
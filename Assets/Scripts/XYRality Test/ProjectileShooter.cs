using UnityEngine;
using AAA.Utility.GlobalVariables;
using Sirenix.OdinInspector;

namespace XYRalityTest
{
    public class ProjectileShooter : MonoBehaviour
    {
        [SerializeField] private PrefabPool projectilePrefabs;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private float projectileVelocity;

        public void SetShootingTarget(GameObject target)
        {
            targetTransform = target.transform;
        }

        [Button]
        public void ShootProjectile()
        {
            GameObject go = projectilePrefabs.GetInstanceFromPool(0);
            
            PointProjectileTowardsTarget(go);

            AccelerateProjectile(go);
        }

        private void PointProjectileTowardsTarget(GameObject go)
        {
            go.transform.position = transform.position;
            if (targetTransform == null)
                go.transform.LookAt(transform.position + transform.forward);
            else
                go.transform.LookAt(targetTransform);
        }

        // idk, maybe move this functionality out into the projectile
        private void AccelerateProjectile(GameObject go)
        {
            var rBody = go.GetComponent<Rigidbody>();
            if (rBody != null)
                rBody.velocity = (targetTransform.position - transform.position).normalized * projectileVelocity;
        }
    }
}
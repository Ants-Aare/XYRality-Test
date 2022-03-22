using UnityEngine;
using AAA.Utility.GlobalVariables;
using Sirenix.OdinInspector;

namespace XYRalityTest
{
    public class RandomizedPrefabInstantiator : MonoBehaviour
    {
        [SerializeField] private PrefabPool prefabPool;
        [SerializeField] private Transform[] instantiationLocations;
        [SerializeField] private bool onlyAllowOnePerLocation = true;

        [Button]
        public void InstantiatePrefab()
        {
            if (TryGetInstantiationLocation(out Transform location))
            {
                GameObject go = prefabPool.GetRandomInstanceFromPool();

                go.transform.parent = location;
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;
            }
        }

        // Maybe move this out into an ILocationProvider, also the while loop is slightly hacky, but whatever
        private bool TryGetInstantiationLocation(out Transform location, int maxIterations = 30)
        {
            int iterations = 0;
            while (iterations <= maxIterations)
            {
                location = instantiationLocations[Random.Range(0, instantiationLocations.Length)];
                if (!onlyAllowOnePerLocation || location.childCount == 0)
                    return true;

                iterations++;
            }
            location = null;
            return false;
        }
    }
}
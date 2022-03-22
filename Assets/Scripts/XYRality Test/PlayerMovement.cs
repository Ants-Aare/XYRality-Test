using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using AAA.Utility.GlobalVariables;

namespace AAA.XYRalityTest
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private BoolReference isGameInputBlocked;
        [SerializeField] private float movementSpeed;
        [ShowInInspector, ReadOnly] private Vector3 inputMoveDirection = Vector3.zero;
        [SerializeField] private Rigidbody rBody;

        #if UNITY_EDITOR
        void OnValidate()
        {
            if(rBody == null)
            rBody = GetComponent<Rigidbody>();
        }
        #endif
        
        void FixedUpdate()
        {
            ReceiveInputs();
            ApplyMovement();
        }
        private void ReceiveInputs()
        {
            inputMoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
        private void ApplyMovement()
        {
            if(isGameInputBlocked.Value)
            {
                rBody.velocity = Vector3.zero;
                return;
            }
            rBody.velocity = inputMoveDirection * movementSpeed;
        }
    }
}
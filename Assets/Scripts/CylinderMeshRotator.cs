using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class CylinderMeshRotator : MonoBehaviour
{
    [SerializeField] private float maxAngularSpeed = 180;    // degrees/sec
    [SerializeField] private float acceleration = 540;       // degrees/sec^2
    [SerializeField] private float damping = 360;            // degrees/sec^2
    
    private float _angularSpeed;
    private InputAction _rotateCylinderIA;
    private Transform _cylinderMeshToRotate;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        _cylinderMeshToRotate = transform.GetChild(0);
        _rotateCylinderIA = playerInput.actions["RotateCylinder"];
    }

    private void FixedUpdate()
    {
        float input = _rotateCylinderIA.ReadValue<float>();
        float target = input * acceleration - Mathf.Sign(_angularSpeed) * damping;
        _angularSpeed = Mathf.Clamp(_angularSpeed + target * Time.fixedDeltaTime, -maxAngularSpeed, maxAngularSpeed);
        
        _cylinderMeshToRotate.Rotate(0, _angularSpeed * Time.fixedDeltaTime, 0, Space.World);
        
    }

    private void OnEnable()  { _rotateCylinderIA.Enable(); }
    private void OnDisable() { _rotateCylinderIA.Disable(); }

}

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class CylinderRotator : MonoBehaviour
{
    [SerializeField] private float maxAngularSpeed = 180;    // degrees/sec
    [SerializeField] private float acceleration = 540;       // degrees/sec^2
    [SerializeField] private float damping = 360;            // degrees/sec^2

    private float _angularYSpeed;
    private InputAction _rotateCylinder;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        _rotateCylinder = playerInput.actions["RotateCylinder"];
    }

    private void FixedUpdate()
    {
        float input = _rotateCylinder.ReadValue<float>();  
        float target = input * acceleration - Mathf.Sign(_angularYSpeed) * damping;
        _angularYSpeed = Mathf.Clamp(_angularYSpeed + target * Time.fixedDeltaTime, -maxAngularSpeed, maxAngularSpeed);
        transform.Rotate(0, _angularYSpeed * Time.fixedDeltaTime, 0, Space.World);
    }

    private void OnEnable()  { _rotateCylinder.Enable(); }
    private void OnDisable() { _rotateCylinder.Disable(); }

}

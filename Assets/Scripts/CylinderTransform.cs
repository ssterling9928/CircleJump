using UnityEngine;
using UnityEngine.Rendering.UI;

/// <summary>
/// Cylinder Coordinate System to transform and attach/snap game objects to the Game World Cylinder
/// Uses θ (theta) and y in a cylindrical space
/// </summary>

[ExecuteAlways]
public class CylinderTransform : MonoBehaviour
{

    // Properties
    [SerializeField] private Transform meshTransform; // Transform of the World Cylinder
    

    [Tooltip("Radians around the tube (0..2π).")]
    [SerializeField] private float theta;   // angle around the cylinder, in radians
    [SerializeField] private float y;  // height along the cylinder

    private float _radius; // length from origin of cylinder to outside edge
    private bool _isOrientOutward = false; // Whether to orient the object to face outwards from the cylinder

    // Getter Properties that calculates the position and rotation on the cylinder 
    // with the given y, theta, and radius values. 
    public Vector3 WorldPosition
    {
        get
        {
            float x = Mathf.Cos(theta) * _radius;
            float z = Mathf.Sin(theta) * _radius;
            Vector3 localPosition = new Vector3(x, y, z);
            return meshTransform.localPosition + meshTransform.rotation * localPosition;
        }
    }
    public Quaternion WorldRotation
    {
        get
        {
            float x = Mathf.Cos(theta);
            float z = Mathf.Sin(theta);
            Quaternion outwards = Quaternion.LookRotation(new Vector3(x, 0, z), Vector3.up);
            return meshTransform.rotation * outwards;
        }
    }

    
    private void Update()
    {
        UpdateLocationOnCylinder();
    }

    private void UpdateLocationOnCylinder()
    {
        // Update both in edit mode and play mode
        if (!meshTransform) return;

        _radius = meshTransform.localScale.x / 2f; // Assuming uniform scale and cylinder aligned with Y axis

        if (_isOrientOutward)
            transform.SetPositionAndRotation(WorldPosition, WorldRotation);
        else
            transform.position = WorldPosition;
    }

    void OnValidate()
    {
        // Keep theta in the range 0 to 2π because the angles wrap around
        const float TAU = Mathf.PI * 2f;
        theta = Mathf.Repeat(theta, TAU);
        
        UpdateLocationOnCylinder();
    }
}


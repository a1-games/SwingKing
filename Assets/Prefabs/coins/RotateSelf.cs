using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    [Tooltip("Value is a float. Can be set to a negative number to rotate in the opposite direction.")]
    [SerializeField] private float rotationSpeedX = 0f;
    [Tooltip("Value is a float. Can be set to a negative number to rotate in the opposite direction.")]
    [SerializeField] private float rotationSpeedY = 0f;
    [Tooltip("Value is a float. Can be set to a negative number to rotate in the opposite direction.")]
    [SerializeField] private float rotationSpeedZ = 0f;

    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ));
    }
}

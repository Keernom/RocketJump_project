using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int _rotationThisFrame = 50;

    public bool rotating;

    int _thrustForce = 0;
    int _rotateDirection = 0;

    private Rigidbody rb;
    private Vector3 eulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eulerAngleVelocity = new Vector3(0, 0, _rotationThisFrame);
    }

    private void Update()
    {
        if (rotating)
        {
            rb.freezeRotation = true;
            rb.MoveRotation(GetComponent<Rigidbody>().rotation * Quaternion.Euler(_rotateDirection * eulerAngleVelocity * Time.deltaTime));
            rb.freezeRotation = false;
        }


        rb.AddRelativeForce(Vector3.up * _thrustForce * Time.deltaTime);
    }

    public void Thrust(int value)
    {
        _thrustForce = value;
        Debug.Log("JUMP");
    }

    public void Rotate(int rotateValue)
    {
        _rotateDirection = rotateValue;
        Debug.Log("ROTATE" + rotateValue);
    }

    public void SetRotating(bool value)
    {
        rotating = value;
    }
}

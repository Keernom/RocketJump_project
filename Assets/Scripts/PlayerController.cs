using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    int _thrustForce = 0;
    int _rotationThisFrame = 50;
    int _rotateDirection = 0;

    private void Update()
    {
        transform.Rotate(Vector3.forward * _rotationThisFrame * _rotateDirection * Time.deltaTime);
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * _thrustForce * Time.deltaTime);    
    }

    public void Jump(int value)
    {
        _thrustForce = value;
        Debug.Log("JUMP");
    }

    public void Rotate(int rotateValue)
    {
        _rotateDirection = rotateValue;
        Debug.Log("ROTATE" + rotateValue);
    }
}

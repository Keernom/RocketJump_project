using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class TouchCheck : MonoBehaviour
{
    int jumpForce = 0;
    int rotationThisFrame = 50;
    int rotateDirection = 0;

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * rotateDirection * Time.deltaTime);
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * jumpForce * Time.deltaTime);
    }

    public void Jump(int value)
    {
        jumpForce = value;
        Debug.Log("JUMP");
    }

    public void Rotate(int rotateValue)
    {
        rotateDirection = rotateValue;
        Debug.Log("ROTATE" + rotateValue);
    }
}

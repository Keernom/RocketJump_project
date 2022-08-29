using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int _rotationThisFrame = 50;
    [SerializeField] int _thrustForce = 0;

    [SerializeField] ParticleSystem _mainThrust;
    [SerializeField] ParticleSystem _leftThrust;
    [SerializeField] ParticleSystem _rightThrust;

    bool _rotating;
    bool _thrusting;

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
        if (_rotating)
        {
            rb.freezeRotation = true;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(_rotateDirection * eulerAngleVelocity * Time.deltaTime));

            if (_rotateDirection == 1)
            {
                if (!_leftThrust.isPlaying)
                    _leftThrust.Play();
            }
            else if (_rotateDirection == -1)
            {
                if (!_rightThrust.isPlaying)
                    _rightThrust.Play();
            }
                
            rb.freezeRotation = false;
        }
        else
        {
            _leftThrust.Stop();
            _rightThrust.Stop();
        }

        if (_thrusting)
        {
            if (!_mainThrust.isPlaying)
                _mainThrust.Play();
            rb.AddRelativeForce(Vector3.up * _thrustForce * Time.deltaTime);
        }
        else
        {
            _mainThrust.Stop();
        }

        print(_rotateDirection);
    }

    public void SetThrust(bool value)
    {
        _thrusting = value;
    }

    public void SetRotateDirection(int rotateValue)
    {
        _rotateDirection = rotateValue;
    }

    public void SetRotating(bool value)
    {
        _rotating = value;
    }
}

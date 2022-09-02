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

    [SerializeField] AudioClip _thrustSound;

    bool _rotating;
    bool _thrusting;

    int _rotateDirection = 0;

    private Rigidbody rb;
    private AudioSource _audioSource;

    private Vector3 eulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        eulerAngleVelocity = new Vector3(0, 0, _rotationThisFrame);
    }

    private void Update()
    {
        ProcessRotate();
        ProcessThrust();
    }

    private void ProcessThrust()
    {
        if (_thrusting)
        {
            if (!_mainThrust.isPlaying)
                _mainThrust.Play();

            if (!_audioSource.isPlaying)
                _audioSource.PlayOneShot(_thrustSound);

            rb.AddRelativeForce(Vector3.up * _thrustForce * Time.deltaTime);
        }
        else
        {
            _mainThrust.Stop();
        }
    }

    private void ProcessRotate()
    {
        if (_rotating)
        {
            rb.freezeRotation = true;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(_rotateDirection * eulerAngleVelocity * Time.deltaTime));

            if (_rotateDirection == -1)
            {
                if (!_leftThrust.isPlaying)
                    _leftThrust.Play();
            }
            else if (_rotateDirection == 1)
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
    }

    public void StopThrusting()
    {
        _leftThrust.Stop();
        _rightThrust.Stop();
        _mainThrust.Stop();
        _audioSource.Stop();
    }

    public void SetThrust(bool value) => _thrusting = value;

    public void SetRotateDirection(int rotateValue) => _rotateDirection = rotateValue;

    public void SetRotating(bool value) => _rotating = value;
}

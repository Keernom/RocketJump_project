using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Controll Sensivity")]
    [SerializeField] int _rotationThisFrame = 50;
    [SerializeField] int _thrustForce = 0;

    [Header("Visual Effects")]
    [SerializeField] ParticleSystem _mainThrustEffect;
    [SerializeField] ParticleSystem _leftThrustEffect;
    [SerializeField] ParticleSystem _rightThrustEffect;

    [Header("Audio Effects")]
    [SerializeField] AudioClip _thrustSound;

    bool _rotating;
    bool _thrusting;

    int _rotateDirection = 0;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private Vector3 _eulerAngleVelocity;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _eulerAngleVelocity = new Vector3(0, 0, _rotationThisFrame);
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
            if (!_mainThrustEffect.isPlaying)
                _mainThrustEffect.Play();

            if (!_audioSource.isPlaying)
                _audioSource.PlayOneShot(_thrustSound);

            _rb.AddRelativeForce(Vector3.up * _thrustForce * Time.deltaTime);
        }
        else
        {
            _mainThrustEffect.Stop();
        }
    }

    private void ProcessRotate()
    {
        if (_rotating)
        {
            _rb.freezeRotation = true;
            _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotateDirection * _eulerAngleVelocity * Time.deltaTime));

            PlayRotateEffects();

            _rb.freezeRotation = false;
        }
        else
        {
            _leftThrustEffect.Stop();
            _rightThrustEffect.Stop();
        }
    }

    private void PlayRotateEffects()
    {
        if (_rotateDirection == -1)
        {
            if (!_leftThrustEffect.isPlaying)
                _leftThrustEffect.Play();
        }
        else if (_rotateDirection == 1)
        {
            if (!_rightThrustEffect.isPlaying)
                _rightThrustEffect.Play();
        }
    }

    public void StopThrusting()
    {
        _leftThrustEffect.Stop();
        _rightThrustEffect.Stop();
        _mainThrustEffect.Stop();
        _audioSource.Stop();
    }

    public void SetThrust(bool value) => _thrusting = value;

    public void SetRotateDirection(int rotateValue) => _rotateDirection = rotateValue;

    public void SetRotating(bool value) => _rotating = value;
}

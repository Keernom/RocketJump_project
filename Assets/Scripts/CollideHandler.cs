using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(AudioSource))]
public class CollideHandler : MonoBehaviour
{
    [Header("Visual Effects")]
    [SerializeField] ParticleSystem _explosionEffect;

    [Header("Audio Effects")]
    [SerializeField] AudioClip _explosionSound;
    [SerializeField] AudioClip _successSound;

    [Header("Special Settings")]
    [SerializeField] float _levelLoadDelay = 1f;

    AudioSource _audioSource;

    bool _isAlive = true;
    bool _isLanded = false;
    int _sceneIndex;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Start"))
            return;

        if (collision.gameObject.CompareTag("Finish") && _isAlive && !_isLanded)
        {
            Landing(collision);
        }
        else if (!_isLanded)
        {
            SpaceshipCrash();
        }
    }

    private void SpaceshipCrash()
    {
        _isAlive = false;
        _explosionEffect.Play();
        GetComponent<PlayerController>().StopThrusting();
        GetComponent<PlayerController>().enabled = false;
        _audioSource.PlayOneShot(_explosionSound, 1f);
    }

    private void Landing(Collision collision)
    {
        _audioSource.PlayOneShot(_successSound, 1f);

        if (_sceneIndex == SceneManager.sceneCountInBuildSettings - 1)
            collision.gameObject.transform.GetChild(0).GetComponent<FireworksLaunch>().FinishLaunch();
        else
        {
            collision.gameObject.transform.GetChild(0).GetComponent<FireworksLaunch>().SuccessLaunch();
            Invoke(nameof(NextLevelLoad), _levelLoadDelay);
        }

        _isLanded = true;
    }

    private void NextLevelLoad() => SceneManager.LoadScene(_sceneIndex + 1);
}

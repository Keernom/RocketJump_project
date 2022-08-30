using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideChecker : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionEffect;
    [SerializeField] float _loadDelay = 1f;

    bool _isAlive = true;
    bool _isLanded = false;
    int _sceneIndex;

    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        print(SceneManager.sceneCountInBuildSettings);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Start"))
            return;

        if (collision.gameObject.CompareTag("Finish") && _isAlive)
        {
            if (_sceneIndex == SceneManager.sceneCountInBuildSettings - 1)
                collision.gameObject.transform.GetChild(0).GetComponent<FireworksLaunch>().FinishLaunch();
            else
            {
                collision.gameObject.transform.GetChild(0).GetComponent<FireworksLaunch>().SuccessLaunch();
                Invoke("NextLevelLoad", _loadDelay);
            }

            _isLanded = true;
        }
        else if (!_isLanded)
        {
            _isAlive = false;
            _explosionEffect.Play();
            GetComponent<PlayerController>().StopThrusting();
            GetComponent<PlayerController>().enabled = false;
        }
    }

    private void NextLevelLoad() => SceneManager.LoadScene(_sceneIndex + 1);
}

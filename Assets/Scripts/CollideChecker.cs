using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideChecker : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Start"))
            return;

        if (collision.gameObject.CompareTag("Finish"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            _explosionEffect.Play();
            FindObjectOfType<PlayerController>().enabled = false;
        }
    }
}

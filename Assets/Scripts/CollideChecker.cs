using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Start"))
            return;

        if (collision.gameObject.CompareTag("Finish"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            print("BOOM");
    }
}

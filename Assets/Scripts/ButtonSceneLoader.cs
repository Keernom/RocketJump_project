using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    [Header("Level Load Settings")]
    [SerializeField] float _levelLoadDelay = 1f;

    int _index = 0;

    public void LoadScene(int buildIndex)
    {
        _index = buildIndex;
        Invoke(nameof(Load), _levelLoadDelay);
    }

    public void Load()
    {
        SceneManager.LoadScene(_index);
    }
}

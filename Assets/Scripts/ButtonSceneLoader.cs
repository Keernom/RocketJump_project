using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    [SerializeField] float _levelDelay = 1f;
    int _index = 0;

    public void LoadScene(int buildIndex)
    {
        _index = buildIndex;
        Invoke("Load", _levelDelay);
    }

    public void Load()
    {
        SceneManager.LoadScene(_index);
    }
}

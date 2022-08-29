using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public void LoadScene(int buildIxdex) => SceneManager.LoadScene(buildIxdex);
}

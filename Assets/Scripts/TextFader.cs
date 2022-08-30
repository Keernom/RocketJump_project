using System.Collections;
using UnityEngine;
using TMPro;

public class TextFader : MonoBehaviour
{
    [SerializeField] float _fadeTime = 2;

    TMP_Text text;
    CanvasRenderer canvas;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        canvas = GetComponent<CanvasRenderer>();
        StartCoroutine("Fade", _fadeTime);
    }

    public IEnumerator Fade(float time)
    {
        while (true)
        {
            while (canvas.GetAlpha() > 0.5)
            {
                canvas.SetAlpha(canvas.GetAlpha() - Time.deltaTime / time);
                text.fontSize -= Time.deltaTime / time * 10; 
                yield return null;
            }

            while (canvas.GetAlpha() < 1)
            {
                canvas.SetAlpha(canvas.GetAlpha() + Time.deltaTime / time);
                text.fontSize += Time.deltaTime / time * 10;
                yield return null;
            }
        }
    }
}

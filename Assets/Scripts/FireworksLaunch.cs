using System.Collections;
using UnityEngine;

public class FireworksLaunch : MonoBehaviour
{
    public void FinishLaunch()
    {
        StartCoroutine("InfiniteLaunch");
    }

    IEnumerator InfiniteLaunch()
    {
        var finishChild = transform.GetChild(0);
        int childCount = finishChild.childCount;

        while (true)
        {
            for (int i = 0; i < childCount; i++)
            {
                finishChild.GetChild(i).GetComponent<ParticleSystem>().Play();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SuccessLaunch()
    {
        var finishChild = transform.GetChild(1);
        finishChild.GetChild(0).GetComponent<ParticleSystem>().Play();
    }
}

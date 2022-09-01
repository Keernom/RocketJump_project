using UnityEngine;

public class FireworksLaunch : MonoBehaviour
{
    public void FinishLaunch()
    {
        var finishChild = transform.GetChild(0);
        int childCount = finishChild.childCount;
        
        for (int i = 0; i < childCount; i++)
        {
            finishChild.GetChild(i).GetComponent<ParticleSystem>().Play();
        }

        GetComponent<AudioSource>().Play();
    }

    public void SuccessLaunch()
    {
        var finishChild = transform.GetChild(1);
        finishChild.GetChild(0).GetComponent<ParticleSystem>().Play();
    }
}

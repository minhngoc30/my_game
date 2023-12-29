using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatFormManage : MonoBehaviour
{
    [SerializeField]
    GameObject[] platform;
    int numberOffatform;
    int toggleTime;
    [SerializeField]
    float cycleTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        numberOffatform = platform.Length;
        if (numberOffatform - 1 == 0) toggleTime = 1; else toggleTime = numberOffatform - 1;
        StartCoroutine(StarMonagePlatforms());
    }
    IEnumerator StarMonagePlatforms()
    {
        for (int i = 0; i < numberOffatform; i++)
        {
            StartCoroutine(ManagePlatform(platform[i]));
            yield return new WaitForSeconds(cycleTime);
        }
    }
    IEnumerator ManagePlatform(GameObject platform)
    {
        while (true) {
            platform.SetActive(true);
            yield return new WaitForSeconds(cycleTime);
            platform.SetActive(false);
            yield return new WaitForSeconds(toggleTime * cycleTime);
        }
    }
}

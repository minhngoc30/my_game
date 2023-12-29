using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapfall : MonoBehaviour
{
    public static mapfall instance = null;
    public float x, y, x2, y2, x3, y3;
    [SerializeField]
    GameObject platformPrefal;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platformPrefal, new Vector2(x, y), platformPrefal.transform.rotation);
        Instantiate(platformPrefal, new Vector2(x2, y2), platformPrefal.transform.rotation);
        Instantiate(platformPrefal, new Vector2(x3, y3), platformPrefal.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(5f);
        Instantiate(platformPrefal, spawnPosition, platformPrefal.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public float x, x1, y, y1;
    public GameObject stars;
    public GameObject stars2;
    void Start()
    {

    }
    void Update()
    {
        Vector3 random = new Vector3(Random.Range(x, x1), Random.Range(y, y1), 0f);
        Instantiate(stars, random, Quaternion.identity);
        Instantiate(stars2, random, Quaternion.identity);

    }
}

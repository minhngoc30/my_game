using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFilp : MonoBehaviour
{
    public GameObject pl;
    public float  tall, fals;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (pl.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(tall, fals);
        }
        if (pl.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-tall, fals);
        }
    }
}

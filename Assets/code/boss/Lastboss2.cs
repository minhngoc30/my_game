using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lastboss2 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Ground5;
    public float distance; private Transform player;
    [SerializeField]
    public GameObject Ground1;
    int index;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(Spawner());
        if (distance < 70)
        {
            index = Random.Range(0, Ground5.Length);
            Ground1 = Ground5[index];
            Instantiate(Ground1, transform.position, Quaternion.identity);
        }
    }
    void Update()
    {
         distance = Vector2.Distance(transform.position, player.transform.position);
    }
}

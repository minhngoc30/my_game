using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenLightning : MonoBehaviour
{
    public GameObject lightning;
    private Transform player;
    public float maxposition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float targetplayer = Vector2.Distance(player.position, transform.position);

        if (targetplayer < maxposition)
        {
            lightning.SetActive(true);
        }
        else lightning.SetActive(false);
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxposition);
    }
}

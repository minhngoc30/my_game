using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquito : MonoBehaviour
{
    public float shootingRange, maxtingRange,speed;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= maxtingRange && distanceFromPlayer >= shootingRange)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(transform.position, maxtingRange);

    }
}

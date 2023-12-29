using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public float maxPosition , FireRate;
    private float time;
    public GameObject egg ,hairy;
    private Animator anim;
    float nextTimeToFire;
    private Source source;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        source = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();
    }
    void Update()
    {
        float targetPlayer = Vector2.Distance(player.position, transform.position);
        if (targetPlayer <= maxPosition)
        {
            rb.velocity = new Vector2(0, 25);
            time = 2;
         
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }          
    }
    void shoot()
    {
        if (time == 2)
        {
          Instantiate(egg, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cung")
        {
            Instantiate(hairy, transform.position, Quaternion.identity);
            anim.SetBool("run", true);
            source.Playsound("chicken");
        }
    }
}

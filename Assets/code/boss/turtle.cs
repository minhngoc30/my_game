using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    public float maxRanger, minRanger, speed,time=2;
    private Transform player;
    private Animator anim;
    private Rigidbody2D rb;
    private Source source;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        source = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetplayer = Vector2.Distance(player.position, transform.position);
        if (targetplayer <= maxRanger && targetplayer > minRanger )
        {
            if (player.transform.position.x > transform.position.x)
                rb.velocity = new Vector2(speed, rb.velocity.y);
            else if (player.transform.position.x < transform.position.x)
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            rb.isKinematic = false;
        }
        if ( targetplayer <= minRanger)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.isKinematic = true;
        } 
        if (targetplayer >= maxRanger) anim.SetBool("run", false);else anim.SetBool("run", true);
           
        if (time <= 1)
        {
            time -= Time.deltaTime;
            if (time <= -2)
            {
                anim.SetBool("sleep", false);
                time = 2;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxRanger);
        Gizmos.DrawWireSphere(transform.position, minRanger);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cung")
        {
            anim.SetBool("sleep", true);
            source.Playsound("turtle");
            time -= 1;
        }
        //if (collision.gameObject.tag == "Player")
        //{
        //    rb.isKinematic = true;
        //}
        //else rb.isKinematic = false;
    }
}

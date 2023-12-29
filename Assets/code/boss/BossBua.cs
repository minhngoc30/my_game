using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBua : MonoBehaviour
{
    public float speed ;
    private Animator anim;
    private Rigidbody2D rb;
    public float shootingRange;
    private Transform player;
    private bool awake = false,  lookingRight = true,   MoveRight;
    public float distance; //khoang cach giua nguoi choi voi beast
    public float wakerange; //khoangcach beast tan cong
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (MoveRight)
        {
            if (distanceFromPlayer > shootingRange)
                rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            if (distanceFromPlayer > shootingRange)
                rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        RangeCheck();
        anim.SetBool("Awake", awake);
        if (player.transform.position.x > transform.position.x && lookingRight)
        {
            Flip();
        }
        if (player.transform.position.x < transform.position.x&& !lookingRight)
        {
            Flip();
        }
    }
    void RangeCheck()//beast tinh day
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < wakerange)
            awake = true;
        if (distance > wakerange)
            awake = false;
    }
    void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "block")
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
}

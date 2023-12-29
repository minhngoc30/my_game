using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baby : MonoBehaviour
{
    float time=1;
    public float wakerange, distance; //khoangcach beast tan cong
    public float speed = 0;//, tall, fals; //khoangcach beast tan cong
    public GameObject pl;
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        RangeCheck();
    }
    private void up()
    {
        rb.velocity = new Vector2(0, 25f);        
    }
    void RangeCheck()//beast tinh day
    {
        distance = Vector2.Distance(transform.position, pl.transform.position);
        if (distance < wakerange && time == 1)
        {
            up();
            time = 2;
        }
        if (distance > 7 && time == 2)
        {
            move();
            anim.SetBool("attack", false);
            anim.SetBool("attackleft", false);
        }
            if (distance <= 7 && time == 2 && pl.transform.position.x > transform.position.x)
        {
            anim.SetBool("attack", true);
            anim.SetBool("attackleft", false);
        }
        if (distance <= 7 && time == 2 && pl.transform.position.x < transform.position.x)
        {
            anim.SetBool("attack", false);
            anim.SetBool("attackleft", true);
        }
    }
    private void move()
    {
        if (pl.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            speed = 10;
        }
        if (pl.transform.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            speed = 10;
        }
    }
   
}

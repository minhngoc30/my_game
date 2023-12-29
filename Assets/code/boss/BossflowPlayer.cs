using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossflowPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject pl;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        if (pl.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (pl.transform.position.x < transform.position.x)
        {          
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cung"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}

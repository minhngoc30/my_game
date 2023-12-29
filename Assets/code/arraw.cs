using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arraw : MonoBehaviour
{
    private cameraShake cam;
    private void Start()
    {
        cam = Camera.main.GetComponent<cameraShake>();
    }
    void Update()
    {
        Destroy(gameObject, 0.3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        cam.move();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pike" )
        {
            Destroy(gameObject);
        }
    }
}

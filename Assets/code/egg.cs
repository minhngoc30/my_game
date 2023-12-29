using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    [SerializeField]
    GameObject die;
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    Instantiate(die, transform.position, Quaternion.identity);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boss")
        {
            Instantiate(die, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "pike")
        {
            Instantiate(die, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

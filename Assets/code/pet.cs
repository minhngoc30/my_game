using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pet : MonoBehaviour
{
    [SerializeField]
    GameObject hitPicture;
    public float speed;
    public Transform target;

    void Start()
    {  

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "boss")
        {

            Instantiate(hitPicture, transform.position, Quaternion.identity);
        }
    }
    
   
    
}
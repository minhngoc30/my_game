using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmagnet : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float shootingRange;
    public static bool magnets=false;
    public Source sound;

    void Start()
    {  //di chuyen theo player 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sound = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();

        //   magnets = false;
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);
        if (magnets)
        {
            if (distanceFromPlayer < shootingRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sound.Playsound("xu");
            Coin.moneyAmount += 5;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
}

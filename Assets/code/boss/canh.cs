using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canh : MonoBehaviour
{
    [SerializeField]
    private float move, time;
    [SerializeField]
    private Transform[] waypoint;
    public int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoint[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 1)
        {
            Move();
            if (waypointIndex == waypoint.Length-1)
            {
                waypointIndex = 0;
            }
        }
       
    }
    private void Move()
    {
        if (waypointIndex <= waypoint.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, move * Time.deltaTime);
            if (transform.position == waypoint[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
       
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("Player"))
        {
         time = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFly : MonoBehaviour
{
    [SerializeField]
    private float move;
    [SerializeField]
    private Transform[] waypoint;
    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoint[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (waypointIndex == waypoint.Length)
        {
            waypointIndex = 0;
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
}

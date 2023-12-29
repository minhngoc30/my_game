using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector2 velocity;
    public float Y;
    public float x;
    private GameObject player;

    public bool bounds;
    public Vector3 min;
    public Vector3 max;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, x);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, Y);
        transform.position = new Vector3(posx, posy, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), Mathf.Clamp(transform.position.z, min.z, max.z));
        }
    }
}

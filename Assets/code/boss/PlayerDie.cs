using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private cameraShake cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<cameraShake>();

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            cam.move();
          //  Destroy(gameObject);
        }
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmoving : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 f = transform.position;
        f.x -= speed * Time.deltaTime;
        transform.position = f;
    }
}

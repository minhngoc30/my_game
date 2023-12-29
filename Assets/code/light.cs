using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    Light fireLight;
    float lightInt;
    public float minInt = 3f, maxInt = 5f;
    void Start()
    {
        fireLight = GetComponent<Light>();
    }
    void Update()
    {
        lightInt = Random.Range(minInt, maxInt);
        fireLight.intensity = lightInt;
        if (Input.GetKey(KeyCode.A))
            this.GetComponent<Light>().enabled = true;
        if (Input.GetKey(KeyCode.B))
            this.GetComponent<Light>().enabled = false;
    }
}

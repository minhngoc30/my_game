using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class army : MonoBehaviour
{
    public Image ao;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ao.gameObject.SetActive(true);
            Destroy(gameObject);
        } 
    }
}

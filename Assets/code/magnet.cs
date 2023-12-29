using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class magnet : MonoBehaviour
{
    public Button ao;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ao.gameObject.SetActive(true);
            Destroy(gameObject);
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : MonoBehaviour
{
    [SerializeField]
    GameObject hitPicture;
    [SerializeField]
    GameObject die;
    [SerializeField]
    private Source sound;
    private cameraShake cam;

    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();
        cam = Camera.main.GetComponent<cameraShake>();

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cung")
        {
            cam.move();
            Instantiate(die, transform.position, Quaternion.identity);
            Instantiate(hitPicture, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);
            sound.Playsound("Bongbong");
        }
    }
    
}

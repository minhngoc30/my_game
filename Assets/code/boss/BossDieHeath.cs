using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDieHeath : MonoBehaviour
{
    public int Health ;
    private int currenHealth;
    public HealthBar hearthbar;
    [SerializeField]
    private Transform map;
    [SerializeField]
    GameObject hitPicture;
    [SerializeField]
    GameObject die;
    [SerializeField]
    private Transform barrel;
    private Source sound;

    void Start()
    {
        currenHealth = Health;
        hearthbar.SetMaxHealth(Health);
        sound = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();

    }
    void Update()
    {
        if (currenHealth <= 0)
        {
            map.gameObject.SetActive(true);
            sound.Playsound("doxu");
            Instantiate(die, barrel.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else map.gameObject.SetActive(false);

        hearthbar.SetHealth(currenHealth);

    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "cung")
        {
            currenHealth -= 1;
            Instantiate(hitPicture, barrel.position, Quaternion.identity);
        }
    }

}

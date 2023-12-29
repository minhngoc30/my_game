using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fungus : MonoBehaviour
{
    private Animator anim;
    private bool run;
    public GameObject FungusPretab;
    private Source source;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("run", run);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            run = true;
            Instantiate(FungusPretab, transform.position, transform.rotation);
            source.Playsound("bell");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            run = false;
        }
    }
}

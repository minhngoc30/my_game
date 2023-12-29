using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float move, jump = 20f;
    private Rigidbody2D rb;
    private Animator anim;
    float dirx;
    private bool doubleJumpe = false, onTheGround = false, wallJumpAllowed, face = true, run, walljump, jump2 , ao;
    private Source sound;
    //attack
    private int noOfclick = 0;
    float lastCllickedTime = 0;
    private float maxComboDelay = 0.9f;
    public GameObject magnet;
    public GameObject coat;
    public GameObject god;
    //heath
    public int Health;
    private int currenHealth;
    public HealthBar hearthbar;

    //pet
    // int isbird1, isbird2, isbird3;
    // public GameObject bird1, bird2, bird3;


    public GameObject win;


    void Start()
    {
        currenHealth = Health;
        hearthbar.SetMaxHealth(Health);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();
        ao = false;
        //pet
     /*   isbird1 = PlayerPrefs.GetInt("bird1");
        isbird2 = PlayerPrefs.GetInt("bird2");
        isbird3 = PlayerPrefs.GetInt("bird3");
        if (isbird3 == 1) bird3.SetActive(true); else bird3.SetActive(false);
        if (isbird1 == 1) bird1.SetActive(true); else bird1.SetActive(false);
        if (isbird2 == 1) bird2.SetActive(true); else bird2.SetActive(false);*/
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Jump", jump2);
        anim.SetBool("run", run);
        anim.SetBool("walljump", walljump);
        //jum + doupble Jump
        if (Mathf.Abs(rb.velocity.y) < 0.1f) { onTheGround = true; walljump = false; jump2 = false; }
        else { onTheGround = false; jump2 = true; }
        if (onTheGround) doubleJumpe = true;
        if (onTheGround && Input.GetButtonDown("Jump")) { Jump(); }
        else if (doubleJumpe && Input.GetButtonDown("Jump")) { Jump(); doubleJumpe = false; }
        if (wallJumpAllowed && Input.GetButtonDown("Jump")) { Jump(); walljump = true; }

        //move
        dirx = Input.GetAxis("Horizontal") * move;
        if (dirx > 0 && face) { Flip(); sound.Playsound("run"); }
        if (dirx < 0 && !face) { Flip(); sound.Playsound("run"); }
        if (dirx == 0) run = false; else { run = true; };

        //attack
        if (Time.time - lastCllickedTime > maxComboDelay)
        {
            noOfclick = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            lastCllickedTime = Time.time;
            noOfclick++;
            if (noOfclick == 1)
            {
                anim.SetBool("Attack", true);
            }
            noOfclick = Mathf.Clamp(noOfclick, 0, 2);
        }

        //heath
        hearthbar.SetHealth(currenHealth);

        if(Input.GetKey(KeyCode.H))
        {
            Time.timeScale = 0f;
            win.SetActive(true);
        }    

    }

    public void return1()
    {
        if (noOfclick >= 2) anim.SetBool("Attack2", true);
        else
        {
            anim.SetBool("Attack", false);
            noOfclick = 0;
        }
    }
    public void return2()
    {
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack", false);
        noOfclick = 0;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, rb.velocity.y);
    }
    void Jump()
    {
        rb.velocity = new Vector2(dirx, 25f);
        rb.AddForce(Vector2.up * jump);
        sound.Playsound("jump");
    }

    void Flip()
    {
        face = !face;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            wallJumpAllowed = true;
            walljump = true;
        }
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = collision.gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            wallJumpAllowed = false;
            walljump = false;
        }
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = null;
        }
    }
    public void magnetopent()
    {
        magnet.gameObject.SetActive(true);
        followmagnet.magnets = true;
    }
    public void magnetClose()
    {
        magnet.gameObject.SetActive(false);
        followmagnet.magnets = false;
    }
    public void coatopent()
    {
        coat.gameObject.SetActive(true);
        ao = true;
        
    }
    public void coattClose()
    {
        coat.gameObject.SetActive(false);
        ao = false;
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pike" && ao==false)
        {
            currenHealth -= 1;
        }
        if (col.gameObject.tag == "god")
        {
            god.gameObject.SetActive(true);
        }
        if (col.gameObject.tag == "dia")
        {
            Application.LoadLevel("Play");
        }
    }
    public void Closegod()
    {
        god.gameObject.SetActive(false);
    }

}

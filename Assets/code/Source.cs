using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    private AudioClip bongbong, muiten,jump,run, doxu, xu,bell,chicken,turtle;
    private AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
        bongbong = Resources.Load<AudioClip>("Bongbong");
        muiten = Resources.Load<AudioClip>("muiten");
        jump = Resources.Load<AudioClip>("jump");
        run = Resources.Load<AudioClip>("run");
        doxu = Resources.Load<AudioClip>("doxu");
        xu = Resources.Load<AudioClip>("xu");
        bell = Resources.Load<AudioClip>("bell");
        chicken = Resources.Load<AudioClip>("chicken");
        turtle = Resources.Load<AudioClip>("turtle");
        adisrc = GetComponent<AudioSource>();
    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "Bongbong":
                adisrc.clip = bongbong;
                adisrc.PlayOneShot(bongbong, 0.3f);
                break;
            case "muiten":
                adisrc.clip = muiten;
                adisrc.PlayOneShot(muiten, 0.3f);
                break;
            case "jump":
                adisrc.clip = jump;
                adisrc.PlayOneShot(jump, 0.3f);
                break;
            case "run":
                adisrc.clip = run;
                adisrc.PlayOneShot(run, 0.3f);
                break;
            case "doxu":
                adisrc.clip = doxu;
                adisrc.PlayOneShot(doxu, 0.3f);
                break;
            case "xu":
                adisrc.clip = xu;
                adisrc.PlayOneShot(xu, 0.3f);
                break;
            case "bell":
                adisrc.clip = bell;
                adisrc.PlayOneShot(bell, 0.3f);
                break;
            case "chicken":
                adisrc.clip = chicken;
                adisrc.PlayOneShot(chicken, 0.3f);
                break; 
            case "turtle":
                adisrc.clip = turtle;
                adisrc.PlayOneShot(turtle, 0.3f);
                break;
        }
    }
}

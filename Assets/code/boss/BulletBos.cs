using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBos : MonoBehaviour
{
    private Vector2 move;
    private float speed;
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    void Start()
    {
        speed = 5f;
    }
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }
    public void SetMove(Vector2 dir)
    {
        move = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}

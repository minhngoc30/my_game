using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject cross;
    public GameObject pun;
    public GameObject bulletpretab;
    public float speed = 60f;
    private Vector3 target;
    public Transform vitri;
    private Source sound;
    void Start()
    {
        Cursor.visible = false;
        sound = GameObject.FindGameObjectWithTag("source").GetComponent<Source>();
    }
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        cross.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - pun.transform.position;

        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        pun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            firBullet(direction, rotation);
            sound.Playsound("muiten");
        }
    }
    void firBullet(Vector2 direction, float rotation)
    {
        GameObject newArrow = Instantiate(bulletpretab, vitri.position, vitri.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}

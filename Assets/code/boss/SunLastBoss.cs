using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLastBoss : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;
    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;//goc

    public float speed;
    private Transform target;
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);//bat kha xam pham 
        target = GameObject.FindGameObjectWithTag("sunlastboss").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void Fire()
    {
        float angeStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDriX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDriY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDriX, bulDriY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;
            GameObject bul = Bullet2.bullet.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletBos>().SetMove(bulDir);
            angle += angeStep;
        }
    }
}

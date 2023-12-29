using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform target;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject Bullet;
    public float FireRate , Foces , Range;
    float nextTimeToFire;
    public Transform point;
  
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);

         Vector2 targetPos = target.position;
         Direction = targetPos - (Vector2)transform.position;
        if (distanceFromPlayer <= Range)
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
  
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, point.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Foces);
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
 
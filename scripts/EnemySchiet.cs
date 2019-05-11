using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySchiet : MonoBehaviour
{
    public float distance;
    public Transform firepoint;
    public GameObject bullet;
    RaycastHit2D rayInfo;
    public Transform groundDetection;
    EnemieMovement em;
    int buffer;
    bool canShoot = true;
    private void Start()
    {
        em = GetComponent<EnemieMovement>();
    }
    void Update()
    {
        
        buffer++;
        if (em.movingRight)
        {
            rayInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);
        }else if (!em.movingRight)
        {
            rayInfo = Physics2D.Raycast(groundDetection.position, -Vector2.right, distance);
        }
        if (buffer % 120 == 0)
        {
            canShoot = true;
        }
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.CompareTag("Player"))
            {
                if (canShoot)
                {
                    Shoot();
                }

            }
        }
        

        
    }
    void Shoot()
    {
        canShoot = false;

        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
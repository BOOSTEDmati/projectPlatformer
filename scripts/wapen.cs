using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wapen : MonoBehaviour
{

    public Transform firepoint;
    public int ammo;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (ammo > 0 && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        ammo--;
    }

    public void GiveAmmo()
    {
        ammo+=5;
    }
}

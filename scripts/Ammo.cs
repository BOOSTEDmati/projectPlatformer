using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public wapen wp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)// script voor de collision
    {
        if (collision.gameObject.CompareTag("Player")){
            wp.GiveAmmo();
            Destroy(gameObject);
        }
    }
}
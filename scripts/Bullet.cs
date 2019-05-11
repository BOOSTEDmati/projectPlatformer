using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        EnemyDamage enemyDamage = hitInfo.GetComponent<EnemyDamage>();
        Playecontroll playerControll = hitInfo.GetComponent<Playecontroll>();
        if (enemyDamage != null)
        {
            enemyDamage.TakeDamage(damage);
        }
        if (hitInfo.gameObject.CompareTag("Player")|| hitInfo.gameObject.CompareTag("Enemy")|| hitInfo.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
      

        if (playerControll != null)
        {
            playerControll.TakeDamage(damage);
        }
        
    }
}

using UnityEngine;

public class Playecontroll : MonoBehaviour
{

    public float Speed = 10f;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform check;
    public LayerMask mask;
    public GameObject restartButton, gameOverText, victoryScreen;
    bool isFacingRight = true;
    public int hp = 100;

    private void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        victoryScreen.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() // script voor het lopen

    {
        
        isGrounded = Physics2D.OverlapCircle(check.position, 0.01f,mask);

        if (Input.GetKey(KeyCode.D))
        {
            transform.position+=new Vector3(1 * Speed * Time.deltaTime, 0) ;
            isFacingRight = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isFacingRight = false;
            transform.position -= new Vector3(1 * Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W)&&isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,7f);
        }
    }

    private void FixedUpdate()
    {
        if (isFacingRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }else if (!isFacingRight)
        {
            transform.localEulerAngles = new Vector3(0, -180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)// script voor de collision
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Border"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag.Equals("finish")){
            restartButton.SetActive(true);
            gameObject.SetActive(false);
            victoryScreen.SetActive(true);

        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

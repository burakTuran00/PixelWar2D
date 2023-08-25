using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletForce = 10.0f;

    public int bulletDamage = 20;

    private Rigidbody2D rb;

    private PlayerMovement playerMovement;

    private float directionWay;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        directionWay = playerMovement.transform.localScale.x * bulletForce;

        Destroy(gameObject, 1.75f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(directionWay, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(bulletDamage);
        }
        Destroy (gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
             EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(bulletDamage);
        }
        Destroy (gameObject);
    }
}

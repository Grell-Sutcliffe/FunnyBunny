using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float damage = 1;
    [SerializeField]
    float speed = 5f;

    Vector2 direction;
    Rigidbody2D rb;

    void Start()
    {

    }

    void Awake()
    {
        rb = rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BANG BANG COLLISION WITH PLAYER");
            collision.gameObject.GetComponent<Player>().ChangeHealth(-damage, true);
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

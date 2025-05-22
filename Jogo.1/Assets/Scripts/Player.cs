using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Só anda na diagonal se A e D forem pressionados ao mesmo tempo
        if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector2(1, 1).normalized; // Diagonal (ajuste como quiser
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector2(-1, 1).normalized; // Diagonal (ajuste como quiser)
        }
        else
        {
            movement = Vector2.zero; // Não se move
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moviment1 = new Vector2(0.5f,1f);
    private Vector2 moviment2 = new Vector2(-0.5f,1);
    private Vector2 moviment3 = new Vector2(0,1);
    private Vector2 moviment4 = Vector2.zero; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        
        if (right && left)
        {
            rb.AddForce(moviment3 * speed,ForceMode2D.Force);
        }
        else if (left)
        {
            rb.AddForce(moviment1 * speed,ForceMode2D.Force);
        }
        else if (right)
        {
            rb.AddForce(moviment2 * speed, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(moviment4,0);
        }
        
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);

    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public float hitForce;
    private int vidas = 3;
    private Rigidbody2D rb;
    private Vector2 movement1 = new Vector2(0.5f,1f);
    private Vector2 movement2 = new Vector2(-0.5f,1);
    private Vector2 movement3 = new Vector2(0,1);
    private Vector2 movement4 = Vector2.zero; 
    private Vector2 hit = new Vector2(0,-1);
    
    private float initialRotationZ;
    private float holdTimer = 0f;
    public float holdTimeToStartRotating = 1.0f; // Tempo segurando A para começar a rotacionar
    public float maxRotationAngle = 45f;         // Rotação máxima permitida para a direita (em graus)
    public float rotationSpeed = 30f;            // Velocidade de rotação em graus por segundo


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialRotationZ = transform.eulerAngles.z;
    }

    void Update()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        
        if (right && left)
        {
            rb.AddForce(movement3 * speed,ForceMode2D.Force);
        }
        else if (left)
        {
            rb.AddForce(movement1 * speed,ForceMode2D.Force);
        }
        else if (right)
        {
            rb.AddForce(movement2 * speed, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(movement4,0);
        }

        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            rb.linearVelocity = hit * hitForce;
            vidas--;
        }

        if (vidas == 0)
        {
            Destroy(gameObject);
        }
    }
}

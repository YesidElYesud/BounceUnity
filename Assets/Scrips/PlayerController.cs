using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad = 5f;
    public float fuerzaSalto = 12f;
    private bool enSuelo;

    public Transform detectorSuelo;
    public float radioDeteccion = 0.2f;
    public LayerMask capaSuelo;

    public int vidas = 3;
    public int puntos = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f; // Aumentamos un poco la gravedad para un salto más rápido
    }

      void Update()
    {
        // Movimiento horizontal
       float movimiento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Saltar solo si está "tocando" algo (ground), que lo maneja la física
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            Debug.Log("Pasaste un checkpoint");
        }

        if (collision.CompareTag("Enemigo"))
        {
            vidas--;
            Debug.Log("Perdiste una vida. Vidas restantes: " + vidas);
            if (vidas <= 0)
            {
                Debug.Log("Game Over");
            }
        }

        if (collision.CompareTag("Anillo"))
        {
            puntos += 10;
            Debug.Log("Puntos: " + puntos);
            Destroy(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (detectorSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(detectorSuelo.position, radioDeteccion);
        }
    }
}

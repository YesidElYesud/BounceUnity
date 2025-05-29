using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad = 8f;
    public float fuerzaSalto = 12f;

    public Transform ultimoCheckpoint; // Último checkpoint alcanzado

    public int vidas = 3;
    public int puntos = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f; // Aumentamos un poco la gravedad para un salto más rápido
        GameManager.instance.IniciarNivel(transform.position);
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
        // Modificar OnTriggerEnter2D:
        if (collision.CompareTag("Checkpoint"))
        {
            Debug.Log("Pasaste un checkpoint");
            ultimoCheckpoint = collision.transform; // Guardamos el checkpoint
        }

        if (collision.CompareTag("Enemigo"))
        {
            GameManager.instance.RestarVida();
        }


        if (collision.CompareTag("Anillo"))
        {
            GameManager.instance.SumarPuntos(10);
            Destroy(collision.gameObject);
        }
    }
}

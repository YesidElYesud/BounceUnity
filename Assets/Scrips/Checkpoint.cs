using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite spriteOriginal; // Sprite antes de ser activado
    public Sprite spriteActivado; // Sprite cuando se activa
    private SpriteRenderer sr;

    private bool activado = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteOriginal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activado && collision.CompareTag("Player"))
        {
            // Cambiar sprite a activado
            sr.sprite = spriteActivado;
            activado = true;

            // Guardar este checkpoint como el último en el jugador
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ultimoCheckpoint = this.transform;
            }
        }
    }
}

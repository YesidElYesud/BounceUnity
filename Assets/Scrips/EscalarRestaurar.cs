using UnityEngine;

public class EscalarRestaurar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}

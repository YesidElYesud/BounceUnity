using UnityEngine;

public class EscalarAumentar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }
    }
}

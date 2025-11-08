using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Notificar al GameManager
            GameManager.Instance.CollectItem();

            if (collectSound)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Destruir el objeto
            Destroy(gameObject);
        }
    }
}

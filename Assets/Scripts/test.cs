using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody grueRigidbody;

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le crochet touche le terrain
        if (collision.gameObject.CompareTag("Terrain"))
        {
            // Gèle les mouvements de la grue (si nécessaire)
            grueRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Lorsque le crochet ne touche plus le terrain, libère les contraintes
        if (collision.gameObject.CompareTag("Terrain"))
        {
            grueRigidbody.constraints = RigidbodyConstraints.None; // Réinitialise les contraintes
        }
    }
}
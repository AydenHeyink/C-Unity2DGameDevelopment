using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            snowParticles.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            snowParticles.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explosionFX;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if (explosionFX != null) 
        { 
            ParticleSystem i = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(i.gameObject, i.main.duration + i.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake) 
        { 
            cameraShake.Play();
        }
    }
}

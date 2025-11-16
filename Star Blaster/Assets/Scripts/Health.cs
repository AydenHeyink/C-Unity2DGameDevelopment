using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreValue = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreKeeper= FindFirstObjectByType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if we hit a damage dealer
        // 
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            damageDealer.Hit();

            if (applyCameraShake) 
            { 
                cameraShake.Play();
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ChangeScore(scoreValue);
        }
        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if (hitParticles != null) 
        { 
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            //Destroy(particles, particles.main.duration, particles.main.startLifetime.constantMax);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}


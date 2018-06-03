using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 50;             // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public AudioClip deathClip;                 // The sound to play when the enemy dies
    private AudioSource enemyAudio;             // Reference to the audio source.


    // Reference to the particle system that plays when the enemy is damaged/dead.
    public ParticleSystem hitParticles;
    public ParticleSystem DeathParticles;       

    // Whether the enemy is dead.
    public bool IsDead { get; private set; }

    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if (IsDead)
            // exit the function.
            return;

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = hitPoint;

        // create the particles.
        Instantiate(hitParticles, hitParticles.transform.position, hitParticles.transform.rotation);

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead.
        IsDead = true;

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        Instantiate(DeathParticles, transform.position, transform.rotation);
        Destroy(gameObject.gameObject);
    }
}
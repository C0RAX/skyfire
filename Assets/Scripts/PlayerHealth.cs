using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    public ParticleSystem hitParticles;
    public ParticleSystem DeathParticles;


    private AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool damaged;                                               // True when the player gets damaged.

    public int StartingHealth
    {
        get
        {
            return startingHealth;
        }

        set
        {
            startingHealth = value;
        }
    }

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        //playerMovement = GetComponent<PlayerMovement>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        currentHealth = StartingHealth;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.maxValue = startingHealth;
        healthSlider.value = currentHealth;

        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = hitPoint;

        Instantiate(hitParticles, hitParticles.transform.position, hitParticles.transform.rotation);

        // Play the hurt sound effect.
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 )
        {
            // ... it should die.
            Death();
        }
    }

    public void AddHealth()
    {
        currentHealth += startingHealth/2;
        if (currentHealth < 0) { currentHealth = 0; }
        if (currentHealth > startingHealth) { currentHealth = startingHealth; }
        healthSlider.value = currentHealth;
    }


    void Death()
    {

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        Camera.main.transform.parent = null;
        Instantiate(DeathParticles, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    IEnumerator ChangeLevel0()
    {
        //GameObject a = GameObject.Find("GameController");
        GetComponent<FaderScript>().BeginFade(9);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}

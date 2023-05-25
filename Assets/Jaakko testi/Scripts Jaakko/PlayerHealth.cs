using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 6;
    public int maxHealth = 6;
    [SerializeField] Image[] healthImages;
    [SerializeField] Image gameOver;
    private bool canTakeDamage;
    PlayerMovementJaakko playermovement; 
    public bool isAttackingFetched = true;
    private Color originalColor; // stores the original color of the health images
    [SerializeField] PlayerAudio pAudio;
    void Start()
    {
        
        gameOver.gameObject.SetActive(false);
        canTakeDamage = true;
        // store the original color of the health images
        originalColor = healthImages[0].color;
    }
    void Update()
    {
        
    }
    // TODO: Implement the OnTriggerEnter2D() function to handle taking damage from Enemy objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //isAttackingFetched = GetComponent<PlayerMovementJaakko>().isAttacking;
        if (collision.gameObject.CompareTag("Enemy") && !isAttackingFetched)
        {
            pAudio.PlaySound("Hurt");
            currentHealth--;
            Debug.Log("Current health: " + currentHealth);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Impulse);

            if (currentHealth >= 0 && currentHealth < healthImages.Length)
            {
                Color newColor = Color.HSVToRGB(0f, 0f, 0f);
                healthImages[currentHealth].color = newColor;
            }

            if (currentHealth == 0)
            {
                gameOver.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Ball"))
        {
            pAudio.PlaySound("Happy");
        }
        
        if (collision.CompareTag("Health"))
        {
            pAudio.PlaySound("Bark");
            // Check if the collided object is tagged as a "MeatBone" or "SuperMeatBone"
            if (collision.gameObject.name == "MeatBone")
            {
                currentHealth += 3;
            }
            else if(collision.gameObject.name == "SuperMeatBone")
            {
                currentHealth = maxHealth;
            }

            // Clamp the current health to the maximum health
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            // Reset the color of the health images
            ResetHealthImages();

            // Destroy the health item object
            Destroy(collision.gameObject);
        }
    }

    // Resets the color of the health images to their original color
    private void ResetHealthImages()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].color = originalColor;
            }
        }
    }
    public void DisableAttack()
    {
        isAttackingFetched = false;
    }
}


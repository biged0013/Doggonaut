using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Define the health amounts for each type of item in the inspector
    public int meatBoneHealthAmount = 2;
    public int superMeatBoneHealthAmount = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Get the player's health script
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Check the name of the collectible item and add the appropriate amount of health
                if (gameObject.name == "MeatBone")
                {
                    playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth + meatBoneHealthAmount, playerHealth.maxHealth);
                }
                else if (gameObject.name == "SuperMeatBone")
                {
                    playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth + superMeatBoneHealthAmount, playerHealth.maxHealth);
                }

                Debug.Log("Current health: " + playerHealth.currentHealth);

                // Destroy the collectible item object
                Destroy(gameObject);
            }
        }
    }
}

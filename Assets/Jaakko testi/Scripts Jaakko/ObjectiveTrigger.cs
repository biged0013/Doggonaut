using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Objective trigger hit");
            playerInventory.OnObjectiveTriggerEnter();
            gameObject.SetActive(false); // Disable the trigger object once activated
        }
    }
    
}

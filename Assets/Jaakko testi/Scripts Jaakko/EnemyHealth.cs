using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    public int health;
    bool isAttackingFetched;
    void Start()
    {
        
        
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isAttackingFetched = GetComponent<PlayerMovementJaakko>().isAttacking;
        if (collision.CompareTag("Weapon") && isAttackingFetched)
        {
            TakeDamage(3);
            Debug.Log("Enemy health is: " + health);
        }
    }
}

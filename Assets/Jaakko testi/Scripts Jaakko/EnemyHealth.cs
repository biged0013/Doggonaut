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
        isAttackingFetched = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().isAttackingFetched;
        if (collision.CompareTag("Weapon") && isAttackingFetched)
        {
            TakeDamage(collision.gameObject.GetComponent<Weapon>().damage);
            Debug.Log("Damage: "+ collision.gameObject.GetComponent<Weapon>().damage +"Enemy: " + gameObject.name + " health is: " + health);
        }
    }
}

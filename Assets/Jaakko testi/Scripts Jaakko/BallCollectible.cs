using UnityEngine;

public class BallCollectible : MonoBehaviour
{
    public int ball = 1;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit ball");
            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
            inventory.currentBalls += ball;
            Destroy(gameObject);


        }
    }
}

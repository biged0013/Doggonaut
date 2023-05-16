//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class PlatformMove : MonoBehaviour
//{

//    public float moveSpeed;


//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {

//            MovePlatform();
//        }
//    }
//    public void MovePlatform()
//    {
//        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
//    }
//}
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveSpeed;
    public float minYPosition;
    public float maxYPosition;

    private bool shouldMove = false;
    private bool movingUp = true;

    private void Update()
    {
        if (shouldMove)
        {
            if (movingUp)
            {
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                if (transform.position.y >= maxYPosition)
                {
                    movingUp = false;
                }
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                if (transform.position.y <= minYPosition)
                {
                    movingUp = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldMove = true;
        }
    }
}

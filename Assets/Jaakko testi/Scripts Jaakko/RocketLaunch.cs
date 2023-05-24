using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private Animator rocketAnimator;
    [SerializeField] private GameObject fire;
    public bool launch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fire.SetActive(true);
            rocketAnimator.SetBool("launching", true);
            // You can add any other logic or code you want here
            collision.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MainCamera").transform.SetParent(gameObject.transform);
            launch = true;

        }
    }
    private void Update()
    {
        if (launch)
        {
            transform.Translate(0, 2 * Time.deltaTime, 0);
            
        }
    }
}


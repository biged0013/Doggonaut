using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private Animator rocketAnimator;
    [SerializeField] private GameObject fire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fire.SetActive(true);
            rocketAnimator.SetBool("launching", true);
            // You can add any other logic or code you want here
        }
    }
}


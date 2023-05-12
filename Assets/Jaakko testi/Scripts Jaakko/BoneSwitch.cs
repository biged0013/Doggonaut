using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSwitch : MonoBehaviour
{
    public Animator switchAnimator;
    // Start is called before the first frame update
    void Start()
    {
        switchAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switchAnimator.SetTrigger("Switch");
        }
    }
}

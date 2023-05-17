using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int currentBalls = 0;
    public TextMeshProUGUI balls;

    // Update is called once per frame
    void Update()
    {
        balls.text = currentBalls.ToString();
    }
}


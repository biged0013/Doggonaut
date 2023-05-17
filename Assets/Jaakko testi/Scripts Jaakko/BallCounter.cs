using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallCounter : MonoBehaviour
{
    public TextMeshProUGUI balls;
    public static int ballCount;

    // Start is called before the first frame update
    void Start()
    {
        balls = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

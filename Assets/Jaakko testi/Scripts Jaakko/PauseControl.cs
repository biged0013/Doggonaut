using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCanvas != null)
            {
                if(!pauseCanvas.activeSelf)
                {
                    pauseCanvas.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    pauseCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }

    }
}

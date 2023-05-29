using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
    public int currentBalls = 0;
    public TextMeshProUGUI balls;
    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;
    public string[] objective;
    public GameObject playButton;
    public AudioSource incoming;

    public float typingSpeed = 0.05f;
    private int index = 0;
    private Coroutine typingCoroutine;
    private void Start()
    {
        objectivePanel.SetActive(false);
        objectiveText.text = "";
    }



    private void Update()
    {
        balls.text = currentBalls.ToString();

        if (currentBalls == 20)
        {
            incoming.Play();
            objectivePanel.SetActive(true);
            objectiveText.text = objective[1];
            StartTyping();
        }
    }
    public void OnObjectiveTriggerEnter()
    {
        incoming.Play();
        objectivePanel.SetActive(true);
        objectiveText.text = objective[0];
        StartTyping();

        //if (currentBalls == 20 && index == 0)
        //{
        //    objectiveText.text = objective[index];
        //    objectivePanel.SetActive(true);
        //    index++;
        //}
    }

    public void OnContinueButtonClicked()
    {
        //if (typingCoroutine != null)
        //    StopCoroutine(typingCoroutine);

        //if (index == 0)
        //{
        //    currentBalls = 0;
        //    balls.text = currentBalls.ToString();
        //}

        objectivePanel.SetActive(false);

        if (index < objective.Length - 1)
            index++;

            
        objectivePanel.SetActive(false);


    }


    private void StartTyping()
    {
        objectiveText.text = "";
        typingCoroutine = StartCoroutine(TypeObjectiveText());
    }

    private IEnumerator TypeObjectiveText()
    {
        foreach (char letter in objective[index])
        {
            objectiveText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

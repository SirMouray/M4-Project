using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float residueTime;
    [SerializeField] OutrangeReposition outrangeReposition;
    [SerializeField] GameObject player;
    [SerializeField] float startTime = 300f;

    void Start()
    {
        residueTime = startTime;
        outrangeReposition = FindObjectOfType<OutrangeReposition>();
    }

    void Update()
    {
        if (residueTime > 0)
        {
            residueTime -= Time.deltaTime;
        }
        else
        {
            residueTime = 0;
            ResetGame();
        }

        UpdateTimerUI();
    }

    void ResetGame()
    {
        outrangeReposition.Restart(GameObject.FindGameObjectWithTag("Player"));

        residueTime = startTime;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(residueTime / 60);
        int seconds = Mathf.FloorToInt(residueTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
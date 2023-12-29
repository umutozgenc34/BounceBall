using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private AudioSource loseSource;
    [SerializeField] private AudioSource winSource;

    int timer= 0;

    void Start()
    {
        EndGameManager.endManager.RegisterPanelController(this);
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTime()
    {
        timer++;
        timerText.text = timer.ToString();
    }

    public void ActivateWinScreen()
    {
        winSource.Play();
        cGroup.alpha = 1;
        winScreen.SetActive(true);
    }

    public void ActivateLoseScreen()
    {
        loseSource.Play();
        cGroup.alpha = 1;
        loseScreen.SetActive(true);
    }

    public void HideTimerText()
    {
        timerText.gameObject.SetActive(false);
    }
}

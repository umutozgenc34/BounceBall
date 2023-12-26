using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject ball;
    [SerializeField] private PanelController panelController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.endManager.gameOver == true)
            return;

        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            ball.SetActive(false);
            panelController.HideTimerText();
            EndGameManager.endManager.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }

  
    
}

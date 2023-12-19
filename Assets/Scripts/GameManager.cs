using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject ball;
    
    int time = 0;

    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TimeUpdate()
    {
        time++;
        timerText.text = time.ToString();
        
    }

    public void GameStart()
    {
        InvokeRepeating("TimeUpdate", 2f, 1f);
    }

    void WinGame()
    {
        winScreen.SetActive(true);
        Debug.Log("KAZANDIN");
    }

    void LoseGame()
    {
        loseScreen.SetActive(true);
        Debug.Log("KAYBETTÝN");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" || time < 20)
        {
            LoseGame();
        }
        else
        {
            WinGame();
        }
    }

}

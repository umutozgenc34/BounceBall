using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private PanelController panelController;

    [HideInInspector]
    public string levelUnlock = "LevelUnlock";

    private void Awake()
    {
        if (endManager == null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        
    }
    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(0.5f);
        ResolveGame();
    }
    public void ResolveGame()
    {
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }
    public void WinGame()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(levelUnlock, 0))
        {
            PlayerPrefs.SetInt(levelUnlock, nextLevel);
        }
        panelController.ActivateWinScreen();
    }

    public void LoseGame()
    {
        
        panelController.ActivateLoseScreen();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }

    
}

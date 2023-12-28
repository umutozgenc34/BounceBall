using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName)
    {
        FadeCanvas.fader.FaderLoadString(levelName);
    }

    public void LoadLevelInt(int levelIndex)
    {
        FadeCanvas.fader.FaderLoadInt(levelIndex);
    }

    public void RestartLevel()
    {
        FadeCanvas.fader.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
    }
}

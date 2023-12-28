using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] levelButton;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt(EndGameManager.endManager.levelUnlock, firstLevelBuildIndex);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + firstLevelBuildIndex <= unlockedLevel)
            {
                levelButton[i].interactable = true;
                levelButton[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = levelButton[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
            }
            else
            {
                levelButton[i].interactable = false;
                levelButton[i].image.sprite = lockedIcon;
                levelButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }
}
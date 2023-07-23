using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProcess : MonoBehaviour
{
    [SerializeField] GameObject[] levelGameObjects;
    [SerializeField] Sprite[] levelSprites;
    TextMeshProUGUI warningText;

    int[] levels= { 0, 0, 0, 0 };


    private void Awake()
    {
        
        levels[0] = PlayerPrefsController.GetLevelState(1);
        levels[1] = PlayerPrefsController.GetLevelState(2);
        levels[2] = PlayerPrefsController.GetLevelState(3);
        levels[3] = PlayerPrefsController.GetLevelState(4);
        for (int i = 0; i < levelGameObjects.Length; i++)
        {
            levelGameObjects[i].GetComponent<SpriteRenderer>().sprite = levelSprites[levels[i]];
        }

    }

    public void LevelRequest(int level)
    {
        if (levels[level-1] != 0)
        {
           FindObjectOfType<LevelLoader>().LoadLevel(level);
        }
        else
        {
            StartCoroutine(WarningLevelHandler());
        }
    }
    IEnumerator WarningLevelHandler()
    {
        GameObject.Find("Warning Text").GetComponent<TextMeshProUGUI>().text = "You Don't have access this level yet...";
        yield return new WaitForSeconds(3f);
        GameObject.Find("Warning Text").GetComponent<TextMeshProUGUI>().text  = "";
    }
}
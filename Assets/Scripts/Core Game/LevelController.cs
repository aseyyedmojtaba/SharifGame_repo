using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject loseLable;
    bool triggerEndLevel=false; //this is for controll to HandelWinCondition play one time in Update method
    private int aliveItemCounts;
    private bool timerFinished = false;

    private void Start()
    {
        winLable.SetActive(false);
        loseLable.SetActive(false);
    }
    void Update()
    {
        if (timerFinished)
        {
            aliveItemCounts = FindObjectsOfType<Item>().Length;
            if (aliveItemCounts == 0 && !triggerEndLevel)
            {
                triggerEndLevel = true;
                StartCoroutine(HandleWinCondition());
            }
        }
    }

    private IEnumerator HandleWinCondition()
    {

        GetComponent<AudioSource>().Play();
        winLable.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadeNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLable.SetActive(true);
        Time.timeScale = 0f;
    }
    public void SetTimerFinished()
    {
        timerFinished = true;
    }
}

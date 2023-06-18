using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject loseLable;
    [SerializeField] GameObject continueOfWin;
    [SerializeField] GameObject retryOfLose;
    [SerializeField] GameObject mainMenuOfLose;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    bool triggerEndLevel=false; //this is for controll to HandelWinCondition play one time in Update method
    private int aliveItemCounts;
    private bool timerFinished = false;

    private void Start()
    {
        Time.timeScale = 1f;  //for starting point set time scale
        SetupStarterThings();
    }

    private void SetupStarterThings()
    {
        winLable.SetActive(false);
        loseLable.SetActive(false);
        continueOfWin.SetActive(false);
        retryOfLose.SetActive(false);
        mainMenuOfLose.SetActive(false);
        rightButton.GetComponent<multipleTouch>().enabled = true;
        leftButton.GetComponent<multipleTouch>().enabled = true;
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
        rightButton.GetComponent<multipleTouch>().enabled = false;
        leftButton.GetComponent<multipleTouch>().enabled = false;
        yield return new WaitForSeconds(waitToLoad);
        continueOfWin.SetActive(true);
    }

    public void HandleLoseCondition()
    {
        StartCoroutine(PlayLoseCanvas());
    }

    private IEnumerator PlayLoseCanvas()
    {
        loseLable.SetActive(true);
        rightButton.GetComponent<multipleTouch>().enabled = false;
        leftButton.GetComponent<multipleTouch>().enabled = false;
        yield return new WaitForSeconds(waitToLoad);
        retryOfLose.SetActive(true);
        mainMenuOfLose.SetActive(true);
    }

    public void SetTimerFinished()
    {
        timerFinished = true;
    }
}

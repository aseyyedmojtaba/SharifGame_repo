using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject loseLable;
    [SerializeField] GameObject pauseLable;
    [SerializeField] GameObject continueOfWin;
    [SerializeField] GameObject retryOfLose;
    [SerializeField] GameObject mainMenuOfLose;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] AudioClip[] playList;
    [SerializeField] int levelNumber;
    [SerializeField] ElectricLine leftElectricLine;
    [SerializeField] ElectricLine rightElectricLine;
    bool triggerEndLevel=false; //this is for controll to HandelWinCondition play one time in Update method
    private int aliveItemCounts;
    private bool timerFinished = false;
    private int stars=3;

    private void Start()
    {
        Time.timeScale = 1f;  //for starting point set time scale
        SetupStarterThings();
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetEffectVolume();
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
        PrepareForEnd(winLable, 0);
        leftElectricLine.PauseAudio();
        rightElectricLine.PauseAudio();
        PlayerPrefsController.SetLevelsState(levelNumber, stars);
        PlayerPrefsController.SetLevelsState(levelNumber+1,1);
        yield return new WaitForSeconds(waitToLoad);
        continueOfWin.SetActive(true);
    }

    public void HandleLoseCondition()
    {
        StartCoroutine(PlayLoseCanvas());
    }

    private IEnumerator PlayLoseCanvas()
    {
        PrepareForEnd(loseLable, 1);
        KillAllActions();
        yield return new WaitForSeconds(waitToLoad);
        retryOfLose.SetActive(true);
        mainMenuOfLose.SetActive(true);
        
    }

    private void KillAllActions()
    {
        
        FindObjectOfType<GameTimer>().StopSlider();
        FindObjectOfType<ObjSpawner>().StopSpawning();
        if (FindObjectOfType<Hunger>())
        { FindObjectOfType<Hunger>().StopSlider(); }

        if (FindObjectOfType<Social>())
        {
            FindObjectOfType<Social>().StopSlider();
        }
        if (FindObjectOfType<Fun>())
        {
            FindObjectOfType<Fun>().StopSlider();
        }
        if (FindObjectOfType<Rest>())
        {
            FindObjectOfType<Rest>().StopSlider();
        }
        if (FindObjectOfType<Hygiene>())
        {
            FindObjectOfType<Hygiene>().StopSlider();
        }
    }

    private void PrepareForEnd(GameObject canvasLabel, int clip)
    {
        GetComponent<AudioSource>().clip = playList[clip];
        GetComponent<AudioSource>().Play();
        canvasLabel.SetActive(true);
        rightButton.GetComponent<multipleTouch>().enabled = false;
        leftButton.GetComponent<multipleTouch>().enabled = false;
    }

    public void SetTimerFinished()
    {
        timerFinished = true;
    }

    public void IsGamePaused(bool value)
    {
        if (value)
        { 
            Time.timeScale = 0;
            pauseLable.SetActive(true);
            leftElectricLine.PauseAudio();
            rightElectricLine.PauseAudio();
        }
        else
        {
            Time.timeScale = 1;
            pauseLable.SetActive(false);
        }
    }
}

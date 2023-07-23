using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField] float decreaseTime = 5f;
    [SerializeField] float decreaseCount = 5f;
    [SerializeField] float hunger = 50f;
    bool triggerdLevelFinishd = false;

    void Start()
    {
        StartCoroutine(Decrease());
    }
    IEnumerator Decrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);
            hunger -= decreaseCount;
        }
    }

    private void Update()
    {
        if (triggerdLevelFinishd) { return; }
        if (hunger > 99 || hunger < 1)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            Debug.Log("Lose By Hunger");
            triggerdLevelFinishd=true;
        }
        else if (hunger > 80 || hunger < 20)
        {
            GetComponent<Animator>().SetBool("inDanger", true);
        }
        else { GetComponent<Animator>().SetBool("inDanger", false); }
        GetComponent<Slider>().value = hunger;
    }

    public void EffectHunger(float effectHunger)
    {
        hunger += effectHunger;
    }

    public void StopSlider()
    {
        StopAllCoroutines();
    }
}
